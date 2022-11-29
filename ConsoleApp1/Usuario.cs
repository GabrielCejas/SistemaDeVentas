using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas
{
    internal class Usuario
    {
        public Usuario(){}
        public long id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Mail { get; set; }
        public string Contraseña { get; set; }

    }
}
