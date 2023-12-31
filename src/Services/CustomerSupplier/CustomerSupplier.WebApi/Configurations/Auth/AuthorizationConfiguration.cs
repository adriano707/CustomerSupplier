﻿using System.Text;
using CustomerSupplier.WebApi.Configurations.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace CustomerSupplier.WebApi.Configurations.Auth;

public static class AuthorizationConfiguration
{
    public static void AddAuthorizationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        JwtSettings jwtSettings = GetJwtSettings(configuration);

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
        services.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build());
        });
    }

    private static JwtSettings GetJwtSettings(IConfiguration configuration)
    {
        return configuration.GetSection(nameof(JwtSettings))
            .Get<JwtSettings>();
    }
}