using Examen.UnidadDeTrabajo;
using System.Linq;
using Xunit;

namespace Examen.PruebaDatos
{
    public class MemberPruebas
    {
        private readonly IUnidadTrabajo _unidad;
        public MemberPruebas()
        {
            _unidad = new UnidadTrabajo(Configuration.ConnectionString);
        }
        [Fact(DisplayName ="[Member]Prueba Traer Todos")]
        public void Member_Prueba_TraerTodos()
        {
            var result = _unidad.Miembros.ListarTodo().ToList();
            Assert.True(result.Count>0);
        }
    }
}
