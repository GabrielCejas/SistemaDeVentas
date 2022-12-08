using Microsoft.AspNetCore.Mvc;
using ProyectoPuntoDeVenta.Models;
using ProyectoPuntoDeVenta.Repositories;

namespace ProyectoPuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioRegistroController : Controller
    {
        private UsuarioRegistroRepositories repository = new UsuarioRegistroRepositories();

        [HttpGet]
        public ActionResult<Usuario> Login(Usuario usuario)
        {
            try
            {
                bool usuarioExiste = repository.ListarUsuarioRegistro(usuario);
                return usuarioExiste ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
