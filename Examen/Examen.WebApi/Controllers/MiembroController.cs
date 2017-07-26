using Microsoft.AspNetCore.Mvc;
using Examen.UnidadDeTrabajo;
using Examen.Modelos;

namespace Examen.WebApi.Controllers
{
    [Route("miembro")]
    public class MiembroController : BaseController
    {
        public MiembroController(IUnidadTrabajo unidad): base(unidad)
        {
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_unidad.Miembros.ListarTodo());
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Member miembro)
        {
            return Ok(_unidad.Miembros.Insertar(miembro));
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] Member miembro)
        {
            return Ok(_unidad.Miembros.Actualizar(miembro));
        }

        [HttpDelete]
        public IActionResult Eliminar([FromBody] Member miembro)
        {
            return Ok(_unidad.Miembros.Eliminar(miembro));
        }

        [HttpGet]
        [Route("ListaPaginada")]
        public IActionResult ListaPaginada(int pagina, int tamanioPagina)
        {
            int filaInicio = ((pagina - 1) * tamanioPagina) + 1;
            int filaFin = pagina * tamanioPagina;

            return Ok(_unidad.Miembros.ListaPaginada(filaInicio, filaFin));
        }
    }
}