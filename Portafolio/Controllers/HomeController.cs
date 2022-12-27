using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly ServicioDelimitado servicioDelimitado;
        private readonly ServicioTransitorio servicioTransitorio;
        private readonly ServicioUnico servicioUnico;
        private readonly ServicioTransitorio servicioTransitorio2;
        private readonly ServicioUnico servicioUnico2;
        private readonly ServicioDelimitado servicioDelimitado2;

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos,
            ServicioDelimitado servicioDelimitado,
            ServicioTransitorio servicioTransitorio,
            ServicioUnico servicioUnico,

            ServicioDelimitado servicioDelimitado2,
            ServicioTransitorio servicioTransitorio2,
            ServicioUnico servicioUnico2)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioUnico = servicioUnico;
            this.servicioTransitorio2 = servicioTransitorio2;
            this.servicioUnico2 = servicioUnico2;
            this.servicioDelimitado2 = servicioDelimitado2;
            this.servicioTransitorio = servicioTransitorio;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var guiViewModel = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado.ObtenerGuid,
                Transitorio = servicioTransitorio.ObtenerGuid,
                Unico = servicioUnico.ObtenerGuid,
            };

            var guiViewModel2 = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado2.ObtenerGuid,
                Transitorio = servicioTransitorio2.ObtenerGuid,
                Unico = servicioUnico2.ObtenerGuid,
            };

            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos,
                EjemploGUID_1 = guiViewModel,
                EjemploGUID_2 = guiViewModel2
            };
            return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}