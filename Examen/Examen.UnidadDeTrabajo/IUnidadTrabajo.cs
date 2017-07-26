using Examen.Modelos;
using Examen.Repositorios;
using Examen.Repositorios.Credito;

namespace Examen.UnidadDeTrabajo
{
    public interface IUnidadTrabajo
    {
        //IRepositorio<Corporation> Corporations { get; }
        //IRepositorio<Member> Members { get; }

        IMiembroRepositorio Miembros { get; }
        ICorporacionRepositorio Corporaciones { get; }
        IUsuarioRepositorio Usuarios { get; }
    }
}
