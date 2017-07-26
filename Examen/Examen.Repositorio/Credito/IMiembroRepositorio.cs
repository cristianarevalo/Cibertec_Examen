using System.Collections.Generic;
using Examen.Modelos;

namespace Examen.Repositorios.Credito
{
    public interface IMiembroRepositorio: IRepositorio<Member>
    {
        IEnumerable<Member> ListaPaginada(int filaInicio, int filaFin);
        int TotalFilas();
    }
}
