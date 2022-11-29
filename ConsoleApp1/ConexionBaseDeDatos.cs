using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas
{
    internal class ConexionBaseDeDatos
    {
        private SqlConnection conexion;
        private String cadenaConexion = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

        public ConexionBaseDeDatos()
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }

        public List<Usuario> listarUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from Usuario where id = @id", conexion))
                {
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "id";
                    sqlParameter.DbType = System.Data.DbType.Int64;
                    sqlParameter.Value = 1;
                    cmd.Connection.Open();

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.id = reader.GetInt64(0);
                                usuario.Nombre = reader.GetString(1);
                                usuario.Apellido = reader.GetString(2);
                                usuario.NombreUsuario = reader.GetString(3);
                                usuario.Contraseña = reader.GetString(4);
                                usuario.Mail = reader.GetString(5);
                                lista.Add(usuario);
                            }
                            Console.WriteLine("Mostrando lista de usuarios");
                            foreach (Usuario usuario in lista)
                            {
                                Console.WriteLine($"Id: {usuario.id}");
                                Console.WriteLine($"Nombre: {usuario.Nombre}");
                                Console.WriteLine($"Apellido: {usuario.Apellido}");
                                Console.WriteLine($"Nombre de Usuario: {usuario.NombreUsuario}");
                                Console.WriteLine($"Contraseña: {usuario.Contraseña}");
                                Console.WriteLine($"Mail: {usuario.Mail}");
                            }
                        }
                        else
                        {
                            Console.Write("Sin registros");
                        }
                    }
                }
                Console.WriteLine("Cerrando la conexion");
                conexion.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error {ex.Message}");
            }
            return lista;
        }
        public int InsertarUsuario(Usuario usuario)
        {
            int filasAfectadas = 0;
            try
            {
                string query = "insert into Usuario(Nombre, Apellido, NombreUsuario, Contraseña, Mail) values(@nombre, @apellido, @nombreUsuario, @contraseña, @email)";
                conexion.Open();
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.Add(new SqlParameter("nombre", SqlDbType.VarChar) { Value = usuario .Nombre});
                    command.Parameters.Add(new SqlParameter("apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                    command.Parameters.Add(new SqlParameter("nombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    command.Parameters.Add(new SqlParameter("contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña });
                    command.Parameters.Add(new SqlParameter("email", SqlDbType.VarChar) { Value = usuario.Mail });

                    filasAfectadas = command.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error {ex.Message}");
            }
            return filasAfectadas;
        }
    }

}
