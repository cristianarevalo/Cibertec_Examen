using Examen.Modelos;
using Examen.Repositorios;
using Examen.Repositorios.Credito;
using Examen.Repositorios.Credito.Dapper;

namespace Examen.UnidadDeTrabajo
{
    public class UnidadTrabajo : IUnidadTrabajo
    {

        public UnidadTrabajo(string cadenaConexion)
        {
            //Corporations = new Repositorio<Corporation>(cadenaConexion);
            //Members = new Repositorio<Member>(cadenaConexion);
            Miembros = new MiembroRepositorio(cadenaConexion);
            Corporaciones = new CorporacionRepositorio(cadenaConexion);
            Usuarios = new UsuarioRepositorio(cadenaConexion);
        }
                
        //public IRepositorio<Corporation> Corporations { get; private set; }
        //public IRepositorio<Member> Members { get; private set; }
        public IMiembroRepositorio Miembros { get; private set; }
        public ICorporacionRepositorio Corporaciones { get; private set; }
        public IUsuarioRepositorio Usuarios { get; private set; }
    }
}
