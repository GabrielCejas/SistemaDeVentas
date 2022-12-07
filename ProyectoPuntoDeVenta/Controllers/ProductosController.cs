using Microsoft.AspNetCore.Mvc;
using ProyectoPuntoDeVenta.Repositories;
using ProyectoPuntoDeVenta.Models;

namespace ProyectoPuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private ProductosRepositories repository = new ProductosRepositories();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Producto> lista = repository.listarProductos();
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
                bool eliminoExito = repository.eliminarProductos(id);
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
