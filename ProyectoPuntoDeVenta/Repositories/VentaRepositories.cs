using ProyectoPuntoDeVenta.Models;
using System.Data.SqlClient;

namespace ProyectoPuntoDeVenta.Repositories
{
    public class VentaRepositories
    {
        SqlConnection? sqlConnection;
        String connection = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

        public VentaRepositories()
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

        public List<Venta> ListarVentas()
        {
            List<Venta> lista = new List<Venta>();
            if (sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from Venta", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = reader.GetInt64(0);
                                venta.Comentarios = reader.GetString(1);
                                venta.IdUsuario = reader.GetInt32(2);
                                lista.Add(venta);
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
    }
}
