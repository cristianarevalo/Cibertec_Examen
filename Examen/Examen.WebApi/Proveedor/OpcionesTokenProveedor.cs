﻿using Microsoft.IdentityModel.Tokens;
using System;

namespace Examen.WebApi.Proveedor
{
    public class OpcionesTokenProveedor
    {
        public string Path { get; set; } = "/token";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan Expiration { get; set; } = TimeSpan.FromHours(8);
        public SigningCredentials SigningCredentials { get; set; }
    }
}
