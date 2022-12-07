using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoDeVenta.Models
{
    public class Venta
    {
        public Venta() { }

        public Venta(long id, string comentarios, int idUsuario) 
        {
            Id = id;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }

        public long? Id { get; set; }
        public string? Comentarios { get; set; }
        public int? IdUsuario { get; set; }
    }
}
