using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ASOS.BL.DTOs.User;
using ASOS.BL.DTOs.UserDto;
using ASOS.BL.Services;
using ASOS.DAL;
using ASOS.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Utilities.Collections;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
namespace ASOS.APIs.Controllers;

[ApiController]
[Route("api/users")]
public class UserController:ControllerBase
{
	private readonly IConfiguration _configuration;
	private readonly UserManager<User> _userManager;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IEmailService _emailService;

	public UserController(IConfiguration configuration,
		UserManager<User> userManager
		,IUnitOfWork unitOfWork
		,IEmailService emailService)
	{
		_configuration= configuration;
		_userManager= userManager;
		_unitOfWork= unitOfWork;
		_emailService= emailService;
	}

	[HttpPost]
	[Route("login")]
	public async Task<IActionResult> Login(LoginCredentials credentials)
	{
		var user = await _userManager.FindByEmailAsync(credentials.Email);
		if (user == null)
		{
			return Unauthorized(new
            {
                statusMsg = "fail",
                message = "Incorrect email or password"
            });
		}
		var isPasswordValid = await _userManager.CheckPasswordAsync(user, credentials.Password);
		if (!isPasswordValid)
		{
			return Unauthorized(new
            {
                statusMsg = "fail",
                message = "Incorrect email or password"
            });
		}
		var claims = await _userManager.GetClaimsAsync(user);
		var tokenDto = GenerateTokenAsync(claims.ToList());

		return Ok(new { message = "success", token = tokenDto });
	}
	//////////////////////////////////////////////////////////////////////////////////////////////
	[HttpPost]
	[Route("register")]
	public async Task<IActionResult> Register(RegisterDto registerDto)
	{
        if (registerDto == null)
        {
            return BadRequest(new { statusMsg = "fail", message = "Invalid registration data." });
        }
        var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
        if (existingUser != null)
		{
			return BadRequest(new { statusMsg = "fail", message = "Account Already Exists" });

        }

        var user = new User
		{
			UserName = registerDto.UserName,
			Email = registerDto.Email,
		};
		var creationResult = await _userManager.CreateAsync(user, registerDto.Password);
		if (!creationResult.Succeeded)
		{
			var errors = creationResult.Errors
				.Select(e => e.Description)
				.ToList();
			return BadRequest(errors);
		}

		var claims = new List<Claim>
			{
				new(ClaimTypes.NameIdentifier,user.Id),
				new(ClaimTypes.Email,user.Email),
			};

		await _userManager.AddClaimsAsync(user, claims);
		var wishList = new DAL.Models.WishList
		{
			UserId = user.Id,
		};
		var cart = new DAL.Models.Cart
		{
			UserId = user.Id,
		};

		await _unitOfWork.WishLists.AddAsync(wishList);
		await _unitOfWork.Carts.AddAsync(cart);
		await _unitOfWork.CompleteAsync();
		return Ok(new
        {
            message= "success",
        });
	}


	////////////////////////////////////////////////////////////////////////////////////////////////////
	private TokenDto GenerateTokenAsync(List<Claim> claims)
	{
		var secretKey = _configuration.GetValue<string>("secretKey");
		var secretKeyInBytes = Encoding.UTF8.GetBytes(secretKey);
		var key = new SymmetricSecurityKey(secretKeyInBytes);

		var token = new JwtSecurityToken(
			expires: DateTime.Now.AddHours(1),
			claims: claims,
			signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
			);

		var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
		return new TokenDto(tokenString, token.ValidTo);
	}
	//////////////////////////////////////////////////////////////////////////////////////////////

	[HttpGet]
	public async Task<Ok<List<UserInfoDto>>> GetAll()
	{
		var users=await _userManager.Users.ToListAsync();
		var usersInfo=users.Select(u => new UserInfoDto
		{
			Id = u.Id,
			Name = u.UserName,
			Email = u.Email,
			Phone = u.PhoneNumber,
			Address = u.Address
		}).ToList();
		return TypedResults.Ok(usersInfo);
	}

	////////////////////////////////////////////////////////////////////////////////////////////
	
	[HttpGet("logged-user")]
	[Authorize]
	public async Task<Results<Ok<UserInfoDto>,NotFound>>GetLoggedUserAsync()
	{
		var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		var user=await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
		if(user == null)
		{
			return TypedResults.NotFound();
		}
		var UserInfo = new UserInfoDto
		{
			Id = user.Id,
			Name = user.UserName,
			Email = user.Email,
			Phone = user.PhoneNumber,
			Address = user.Address
		};
		return TypedResults.Ok(UserInfo);
	}

	/////////////////////////////////////////////////////////////////////////////////////
	[HttpPost("forget-password")]
	
	public async Task<Results<Ok<string>,NotFound>>ForgetPassword(string email)
	{
		var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
		if (user == null)
		{
			return TypedResults.NotFound();
		}
		var random = new Random();
		string code = random.Next(100000, 1000000).ToString();
		var verification = new VerificationCode
		{
			Id = Guid.NewGuid(),
			UserId = user.Id,
			Code = code,
			Expiration = DateTime.UtcNow.AddMinutes(10)
		};
		await _unitOfWork.VerificationCodes.AddAsync(verification);
		await _unitOfWork.CompleteAsync();
		await _emailService.SendEmailAsync(email
		, "Your Password Reset Code (valid for 10 minutes)"
		, $"To reset your password.\nSubmit this reset password code: {code} If you did not request a change of password, please ignore this email!");
		return TypedResults.Ok("Email sent successfully.");
	}
	/////////////////////////////////////////////////////////////////////////////////////
	[HttpPost("verify")]
	public async Task<Results<Ok<TokenDto>, NotFound>>
		VerifyCodeAsync(string code, string email)
	{
		var verificationCodes = await _unitOfWork.VerificationCodes.GetAllAsync();
		var expiredCodes = verificationCodes.Where(vc => vc.Expiration < DateTime.UtcNow);
		_unitOfWork.VerificationCodes.DeleteRange(expiredCodes);
		await _unitOfWork.CompleteAsync();

		var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == email);
		if (user == null)
		{
			return TypedResults.NotFound();
		}

		var vc = verificationCodes.LastOrDefault(vc => vc.UserId == user.Id);
		if (vc == null)
		{
			return TypedResults.NotFound();
		}

		if (vc.Code != code)
		{
			return TypedResults.NotFound();
		}
		_unitOfWork.VerificationCodes.Delete(vc);
		await _unitOfWork.CompleteAsync();
		var claims = await _userManager.GetClaimsAsync(user);
		var tokenDto = GenerateTokenAsync(claims.ToList());
		return TypedResults.Ok(tokenDto);
	}
	/////////////////////////////////////////////////////////////////////////////////////
	[Authorize]
	[HttpPost("reset-password")]
	public async Task<Results<Ok<string>, NotFound>>
		ResetPasswordAsync([FromBody]string newPassword)
	{
		var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
		if (user == null)
		{
			return TypedResults.NotFound();
		}
		await _userManager.RemovePasswordAsync(user);
		var result= await _userManager.AddPasswordAsync(user, newPassword);

		if (!result.Succeeded)
		{
			return TypedResults.Ok("Failed to set new password.");
		}
		

		return TypedResults.Ok("Password reset successfully.");
	}
}
