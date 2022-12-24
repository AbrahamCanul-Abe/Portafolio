using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoDTO> ObtenerProyectos();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectoDTO> ObtenerProyectos()
        {
            return new List<ProyectoDTO>(){
                new ProyectoDTO
            {
                Titulo = "Amazon",
                Descripcion = "E-Commerce realizado en ASP-NET Core",
                Link = "https://amazon.com",
                ImagenURL = "/imagenes/amazon.png"
            },
                new ProyectoDTO
            {
                Titulo = "New York Times",
                Descripcion = "Página de noticias en React",
                Link = "https://nytimes.com",
                ImagenURL = "/imagenes/nyt.png"
            },
                new ProyectoDTO
            {
                Titulo = "Reddit",
                Descripcion = "Red social para compartir en comunidades",
                Link = "https://reddit.com",
                ImagenURL = "/imagenes/reddit.png"
            },
                new ProyectoDTO
            {
                Titulo = "Steam",
                Descripcion = "Tienda en línea para compra de videojuegos",
                Link = "https://store.steampowered.com",
                ImagenURL = "/imagenes/steam.png"
            },
            };
        }
    }
}
