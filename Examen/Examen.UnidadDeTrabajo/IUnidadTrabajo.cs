using Examen.Modelos;
using Examen.Repositorios;

namespace Examen.UnidadDeTrabajo
{
    public interface IUnidadTrabajo
    {
        IRepositorio<Corporation> Corporations { get; }
        IRepositorio<Member> Members { get; }
    }
}
