using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace TodoApp.API.Auth
{
    public static class AuthConfigurator
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            //builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

            var issuer = builder.Configuration["Jwt:Issuer"]!;
            var audience = builder.Configuration["Jwt:Audience"]!;
            var key = builder.Configuration["Jwt:Key"]!;

            builder.Services.Configure<JwtSettings>(s  =>
            {
                s.Issuer = issuer;
                s.Audience = audience;  
                s.SecretKey = key;
            });

            builder.Services.AddTransient<TokenGenerator>();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(optoins =>
                {
                    optoins.TokenValidationParameters = tokenValidationParameters;
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(ClaimTypes.Role, "api-user"));
                options.AddPolicy("ApiAdmin", policy => policy.RequireClaim(ClaimTypes.Role, "api-admin"));
            });
        }
    }
}
