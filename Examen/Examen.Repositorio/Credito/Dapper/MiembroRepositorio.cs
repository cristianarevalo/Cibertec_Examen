using Dapper;
using Examen.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Examen.Repositorios.Credito.Dapper
{
    public class MiembroRepositorio: Repositorio<Member>, IMiembroRepositorio
    {
        public MiembroRepositorio(string cadenaConexion): base(cadenaConexion)
        {

        }

        public IEnumerable<Member> ListaPaginada(int filaInicio, int filaFin)
        {
            using (var coneccion = new SqlConnection(_cadenaDeConexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@filaInicio", filaInicio);
                parametros.Add("@filaFin", filaFin);

                return coneccion.Query<Member>("dbo.MiembroListaPaginada",
                        parametros,
                        commandType: System.Data.CommandType.StoredProcedure).AsList();
            }
        }

        public int TotalFilas()
        {
            using (var coneccion = new SqlConnection(_cadenaDeConexion))
            {
                return coneccion.ExecuteScalar<int>("SELECT Count(member_no) FROM dbo.member");
            }
        }
    }
}
