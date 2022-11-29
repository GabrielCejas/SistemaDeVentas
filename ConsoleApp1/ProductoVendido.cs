using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas
{
    internal class ProductoVendido
    {
        public ProductoVendido() { }

        public long Id { get; set; }
        public long IdProducto { get; set; }
        public int Stock { get; set; }
        public long IdVenta { get; set; }
    }
}
