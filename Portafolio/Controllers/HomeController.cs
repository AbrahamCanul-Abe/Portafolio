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

        public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos,
            ServicioDelimitado servicioDelimitado,
            ServicioTransitorio servicioTransitorio,
            ServicioUnico servicioUnico)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioUnico = servicioUnico;
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
            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos,
                EjemploGUID_1 = guiViewModel
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