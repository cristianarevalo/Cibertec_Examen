using Microsoft.AspNetCore.Mvc;
using Examen.UnidadDeTrabajo;
using Examen.Modelos;

namespace Examen.WebApi.Controllers
{
    [Route("corporacion")]
    public class CorporacionController : BaseController
    {
        public CorporacionController(IUnidadTrabajo unidad): base(unidad)
        {
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_unidad.Corporaciones.ListarTodo());
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Corporation corporacion)
        {
            return Ok(_unidad.Corporaciones.Insertar(corporacion));
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] Corporation corporacion)
        {
            return Ok(_unidad.Corporaciones.Actualizar(corporacion));
        }

        [HttpDelete]
        public IActionResult Eliminar([FromBody] Corporation corporacion)
        {
            return Ok(_unidad.Corporaciones.Eliminar(corporacion));
        }

        [HttpGet]
        [Route("ListaPaginada")]
        public IActionResult ListaPaginada(int pagina, int tamanioPagina)
        {
            int filaInicio = ((pagina - 1) * tamanioPagina) + 1;
            int filaFin = pagina * tamanioPagina;

            return Ok(_unidad.Corporaciones.ListaPaginada(filaInicio, filaFin));
        }
    }
}