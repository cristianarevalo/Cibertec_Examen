using Examen.UnidadDeTrabajo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Examen.WebApi.Proveedor
{
    public class TokenProveedorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly OpcionesTokenProveedor _opciones;
        private readonly IUnidadTrabajo _unidad;

        public TokenProveedorMiddleware(
            RequestDelegate next,
            IOptions<OpcionesTokenProveedor> opciones,
            IUnidadTrabajo unidad
            )
        {
            _next = next;
            _opciones = opciones.Value;
            _unidad = unidad;
        }

        public Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.ToString().ToLower().Contains(_opciones.Path))
            {
                return _next(context);
            }

            if (!context.Request.Method.Equals("POST")
                || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Bad request.");
            }

            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            var nombreUsuario = context.Request.Form["username"];
            var clave = context.Request.Form["password"];

            var identity = await CheckIdentity(nombreUsuario, clave);
            if (identity == null)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("El usuario o la clave son incorrectos.");

                return;
            }

            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, nombreUsuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var jwt = new JwtSecurityToken(
                issuer: _opciones.Issuer,
                audience: _opciones.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(_opciones.Expiration),
                signingCredentials: _opciones.SigningCredentials
                );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_opciones.Expiration.TotalSeconds
            };

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private Task<ClaimsIdentity> CheckIdentity(string NombreUsuario, string clave)
        {
            var usuario = _unidad.Usuarios.ValidarUsuario(NombreUsuario, clave);

            if (usuario != null)
            {
                return Task.FromResult(new ClaimsIdentity(new System.Security.Principal.GenericIdentity(NombreUsuario, "Token"), new Claim[] { }));
            }
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
