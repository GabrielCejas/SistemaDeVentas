using Microsoft.AspNetCore.Mvc;
using ProyectoPuntoDeVenta.Models;
using ProyectoPuntoDeVenta.Repositories;

namespace ProyectoPuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private UsuariosRepositories repository = new UsuariosRepositories();
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Usuario> lista = repository.ListarUsuarios();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody]long id)
        {
            try
            {
                bool eliminoExito = repository.eliminarUsuario(id);
                if (eliminoExito) 
                { 
                    return Ok("Usuario eliminado");
                }
                else
                {
                    return NotFound("Usuario no encontrado");
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
