using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Examen.WebApi.Proveedor
{
    public static class AutenticacionOwin
    {
        private static readonly string secretKey = "clave_secreta_para_cifrado#2017";

        public static IApplicationBuilder UsarSimpleToken(this IApplicationBuilder app)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var opciones = new OpcionesTokenProveedor
            {
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

            app.UseMiddleware<TokenProveedorMiddleware>(Options.Create(opciones));

            var parametrosValidacionToken = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = "ExampleIssuer",
                ValidateAudience = true,
                ValidAudience = "ExampleAudience",
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = parametrosValidacionToken
            });

            return app;
        }
    }
}
