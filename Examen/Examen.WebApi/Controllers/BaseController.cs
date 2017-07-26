using Microsoft.AspNetCore.Mvc;
using Examen.UnidadDeTrabajo;
using Microsoft.AspNetCore.Authorization;

namespace Examen.WebApi.Controllers
{
    [Produces("application/json")]
    public class BaseController : Controller
    {
        protected readonly IUnidadTrabajo _unidad;
        public BaseController(IUnidadTrabajo unidad)
        {
            _unidad = unidad;
        }
    }
}