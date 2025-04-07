
using System.Text;
using ASOS.DAL;
using ASOS.DAL.Context;
using ASOS.DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ASOS.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //builder.Services.AddDbContext<StoreContext>(o => o.UseSqlServer(
            //    builder.Configuration.GetConnectionString("Default")
            //));
            builder.Services.AddDataAccessServices(builder.Configuration);

            builder.Services.AddBusinessServices(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

			#region Identity
			builder.Services.AddIdentityCore<User>(options =>
			{
				options.Password.RequiredUniqueChars = 1;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 6;
				options.User.RequireUniqueEmail = true;
			})
				.AddEntityFrameworkStores<StoreContext>();
			#endregion

			#region Authentication
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					var secretKey = builder.Configuration.GetValue<string>("secretKey");
					var secretKeyInBytes = Encoding.UTF8.GetBytes(secretKey);
					var key = new SymmetricSecurityKey(secretKeyInBytes);

					options.TokenValidationParameters = new()
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						IssuerSigningKey = key
					};
				});
			#endregion

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
