using ProyectoPuntoDeVenta.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoPuntoDeVenta.Repositories
{
    public class UsuariosRepositories
    {
        SqlConnection? sqlConnection;
        String connection = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

        public UsuariosRepositories()
        {
            try
            {
                sqlConnection = new SqlConnection(connection);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex}");
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            if (sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from Usuario", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = reader.GetInt64(0);
                                usuario.Nombre = reader.GetString(1);
                                usuario.Apellido = reader.GetString(2);
                                usuario.NombreUsuario = reader.GetString(3);
                                usuario.Contraseña = reader.GetString(4);
                                usuario.Mail = reader.GetString(5);
                                lista.Add(usuario);
                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex}");
            }
            return lista;
        }
        
        public bool eliminarUsuario(long id)
        {
            if (sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                int filasAfectadas = 0;
                using (SqlCommand cmd = new SqlCommand("delete from Usuario where Id = @id", sqlConnection))
                {
                    sqlConnection.Open();
                    cmd.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) {Value = id });
                    filasAfectadas = cmd.ExecuteNonQuery();
                }
                sqlConnection.Close();
                return filasAfectadas == 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex}");
            }
        }
    }
}
