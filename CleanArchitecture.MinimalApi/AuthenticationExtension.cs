using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.MinimalApi
{
    public static class AuthenticationExtension
    {
         public static  IServiceCollection AddTokenAuthentication(this IServiceCollection services,IConfiguration configuration)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Auth:Jwt:Key"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,
                        ValidIssuer = configuration["Auth:Jwt:Issuer"],
                        ValidAudience = configuration["Auth:Jwt:Audience"],
                        IssuerSigningKey = signingKey,
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed=context=>
                        {
                            Console.WriteLine("OnAuthenticationFailed:" + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated=context=>
                        {
                            Console.WriteLine("OnTokenValidated:" + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };

                });

            return services;
        }
    }
}
