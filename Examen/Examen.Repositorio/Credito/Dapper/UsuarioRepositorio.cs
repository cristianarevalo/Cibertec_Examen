using Dapper;
using Examen.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Examen.Repositorios.Credito.Dapper
{
    public class UsuarioRepositorio: Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(string cadenaConexion) : base(cadenaConexion)
        {

        }

        public Usuario ValidarUsuario(string correo, string password)
        {
            using (var coneccion = new SqlConnection(_cadenaDeConexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@correo", correo);
                parametros.Add("@password", password);

                return coneccion.QueryFirst<Usuario>("dbo.ValidarUsuario",
                        parametros,
                        commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
