using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoDeVenta.Models
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(long id, string nombre, string apellido, string nombreUsuario, string mail, string contraseña)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Mail = mail;
            Contraseña = contraseña;
        }
        public long? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Mail { get; set; }
        public string? Contraseña { get; set; }

    }
}
