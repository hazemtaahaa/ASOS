using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ASOS.BL.DTOs.User;
using ASOS.BL.DTOs.UserDto;
using ASOS.DAL.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
namespace ASOS.APIs.Controllers;

[ApiController]
[Route("api/users")]
public class UserController:ControllerBase
{
	private readonly IConfiguration _configuration;
	private readonly UserManager<User> _userManager;

	public UserController(IConfiguration configuration,UserManager<User> userManager)
	{
		_configuration= configuration;
		_userManager= userManager;
	}

	[HttpPost]
	[Route("login")]
	public async Task<Results<Ok<TokenDto>, UnauthorizedHttpResult>>
			Login(LoginCredentials credentials)
	{
		var user = await _userManager.FindByNameAsync(credentials.UserName);
		if (user == null)
		{
			return TypedResults.Unauthorized();
		}
		var isPasswordValid = await _userManager.CheckPasswordAsync(user, credentials.Password);
		if (!isPasswordValid)
		{
			return TypedResults.Unauthorized();
		}
		var claims = await _userManager.GetClaimsAsync(user);
		var tokenDto = GenerateTokenAsync(claims.ToList());

		return TypedResults.Ok(tokenDto);
	}
	//////////////////////////////////////////////////////////////////////////////////////////////
	[HttpPost]
	[Route("register")]
	public async Task<Results<NoContent, BadRequest<List<string>>>>
			Register(RegisterDto registerDto)
	{
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
			return TypedResults.BadRequest(errors);
		}

		var claims = new List<Claim>
			{
				new(ClaimTypes.NameIdentifier,user.Id),
				new(ClaimTypes.Email,user.Email),
			};

		await _userManager.AddClaimsAsync(user, claims);

		return TypedResults.NoContent();
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
	
	[HttpGet("{id}")]
	public async Task<Results<Ok<UserInfoDto>,NotFound>>GetById(string id)
	{
		var user=await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
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

}
