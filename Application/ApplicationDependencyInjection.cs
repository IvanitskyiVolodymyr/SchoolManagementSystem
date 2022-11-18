﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using Application.Interfaces;
using Application.Services;
using Application.Auth.Exceptions;

namespace Application
{
    public static class ApplicationDependencyInjection
    {
        public static void ConfigureMapping(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddMaps(System.Reflection.Assembly.GetAssembly(typeof(Application)));
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("JwtConfig");
            var secretKey = jwtConfig["secret"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig["validIssuer"],
                    ValidAudience = jwtConfig["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
                options.SaveToken = true;
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = OnAuthenticationFailed,
                    OnChallenge = OnChallenge
                };
            });
        }

        private static Task OnChallenge(JwtBearerChallengeContext context)
        {
            switch (context.AuthenticateFailure)
            {
                case ResponseExceptionBase:
                    return Task.FromException(context.AuthenticateFailure);
                case null:
                    return Task.FromException(new MissingAccessTokenException());
                default: return Task.FromException(new InvalidAccessTokenException());
            }
        }

        private static Task OnAuthenticationFailed(AuthenticationFailedContext context)
        {
            switch (context.Exception)
            {
                case SecurityTokenExpiredException:
                    context.Fail(new ExpiredAccessTokenException());
                    break;
                default:
                    context.Fail(new InvalidAccessTokenException());
                    break;
            }
            return Task.CompletedTask;
        }
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, JwtService>();
        }
    }
}