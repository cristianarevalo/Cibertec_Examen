using Examen.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Repositorios.Credito
{
    public interface IUsuarioRepositorio
    {
        Usuario ValidarUsuario(string correo, string password);
    }
}
