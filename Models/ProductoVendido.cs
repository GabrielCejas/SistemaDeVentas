using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoDeVenta.Models
{
    public class ProductoVendido
    {
        public ProductoVendido() { }

        public ProductoVendido(long id, long idProducto, int stock, long idVenta) {
            Id = id;
            IdProducto = idProducto;
            Stock = stock;
            IdVenta = idVenta;
        }

        public long? Id { get; set; }
        public long? IdProducto { get; set; }
        public int? Stock { get; set; }
        public long? IdVenta { get; set; }
    }
}
