using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoDeVenta.Models
{
    public class Producto
    {
        public Producto()
        {
        }

        public Producto(long id, string descripcion, decimal costo, decimal precioVenta, int stock, long idUsuario) {
            Id = id;
            Descripcion = descripcion;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
            IdUsuario = idUsuario;
        }
        public long? Id { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Costo { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? Stock { get; set; }
        public long? IdUsuario { get; set; }
    }
}
