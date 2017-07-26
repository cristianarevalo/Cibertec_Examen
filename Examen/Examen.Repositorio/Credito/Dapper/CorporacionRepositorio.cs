using Dapper;
using Examen.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Examen.Repositorios.Credito.Dapper
{
    public class CorporacionRepositorio : Repositorio<Corporation>, ICorporacionRepositorio
    {
        public CorporacionRepositorio(string cadenaConexion): base(cadenaConexion)
        {

        }

        public IEnumerable<Corporation> ListaPaginada(int filaInicio, int filaFin)
        {
            using (var coneccion = new SqlConnection(_cadenaDeConexion))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@filaInicio", filaInicio);
                parameters.Add("@filaFin", filaFin);

                return coneccion.Query<Corporation>("dbo.CorporacionListaPaginada",
                        parameters,
                        commandType: System.Data.CommandType.StoredProcedure).AsList();
            }
        }

        public int TotalFilas()
        {
            using (var coneccion = new SqlConnection(_cadenaDeConexion))
            {
                return coneccion.ExecuteScalar<int>("SELECT Count(corp_no) FROM dbo.corporation");
            }
        }
    }
}
