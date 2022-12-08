using Microsoft.AspNetCore.Mvc;
using ProyectoPuntoDeVenta.Models;
using ProyectoPuntoDeVenta.Repositories;

namespace ProyectoPuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private VentaRepositories repository = new VentaRepositories();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Venta> lista = repository.ListarVentas();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] long id)
        {
            try
            {
                bool eliminoExito = repository.eliminarVenta(id);
                if (eliminoExito)
                {
                    return Ok("Producto eliminado");
                }
                else
                {
                    return NotFound("Producto no encontrado");
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }
}
