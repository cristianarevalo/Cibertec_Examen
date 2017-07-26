using Examen.Modelos;
using System.Collections.Generic;

namespace Examen.Repositorios.Credito
{
    public interface ICorporacionRepositorio: IRepositorio<Corporation>
    {
        IEnumerable<Corporation> ListaPaginada(int filaInicio, int filaFin);
        int TotalFilas();
    }
}
