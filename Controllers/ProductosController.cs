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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Producto? producto = repository.listarProductoId(id);
                
                if (producto != null)
                {
                    return Ok(producto);
                }
                else
                {
                    return NotFound("No se encontro el producto");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
                bool exito = repository.cargarProducto(producto);
                if (producto != null)
                {
                    return Ok("Producto cargado con exito");
                }
                else
                {
                    return NotFound("No se pudo cargar el producto");
                }
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
