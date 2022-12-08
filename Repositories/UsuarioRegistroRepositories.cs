using ProyectoPuntoDeVenta.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoPuntoDeVenta.Repositories
{
    public class UsuarioRegistroRepositories
    {
        SqlConnection? sqlConnection;
        String connection = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

        public UsuarioRegistroRepositories()
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

        public bool ListarUsuarioRegistro(Usuario usuario)
        {
            if (sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from Usuario where Mail = @Mail and Contraseña = @Contraseña", sqlConnection))
                {
                    sqlConnection.Open();
                    cmd.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                    cmd.Parameters.Add(new SqlParameter("Contrasenia", SqlDbType.VarChar) { Value = usuario.Contraseña });
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex}");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
