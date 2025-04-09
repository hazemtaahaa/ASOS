using System.Text;
using ASOS.APIs.Swagger;
using ASOS.DAL;
using ASOS.DAL.Context;
using ASOS.DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASOS API", Version = "v1" });
                
                // Add support for file uploads
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

                // Configure file upload support
                c.OperationFilter<SwaggerFileOperationFilter>();
            });

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

            #region Images
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider= new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),  "Images")),
                RequestPath = "/Images"
            });
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASOS API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

			app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
