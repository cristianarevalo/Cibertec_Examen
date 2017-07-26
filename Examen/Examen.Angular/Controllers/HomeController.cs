using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Examen.Angular.Codigo;
using Microsoft.Extensions.Options;

namespace Examen.Angular.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArchivoConfiguracion _config;
        public HomeController(IOptions<ArchivoConfiguracion> config)
        {
            _config = config.Value;
        }


        public IActionResult Index()
        {
            ViewBag.WebApiUrl = _config.WebApiUrl;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
