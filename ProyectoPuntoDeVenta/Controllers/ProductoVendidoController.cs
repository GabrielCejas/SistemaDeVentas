using Microsoft.AspNetCore.Mvc;
using ProyectoPuntoDeVenta.Models;
using ProyectoPuntoDeVenta.Repositories;

namespace ProyectoPuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoRepositories repository = new ProductoVendidoRepositories();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ProductoVendido> lista = repository.ListarProductoVendido();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
