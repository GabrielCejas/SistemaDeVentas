using ProyectoPuntoDeVenta.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoPuntoDeVenta.Repositories
{
    public class ProductoVendidoRepositories
    {
        SqlConnection? sqlConnection;
        String connection = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

        public ProductoVendidoRepositories()
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

        public List<ProductoVendido> ListarProductoVendido()
        {
            List<ProductoVendido> lista = new List<ProductoVendido>();
            if (sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProductoVendido producto = new ProductoVendido();
                                producto.Id = reader.GetInt64(0);
                                producto.Stock = reader.GetInt32(1);
                                producto.IdProducto = reader.GetInt64(2);
                                producto.IdVenta = reader.GetInt64(3);
                                lista.Add(producto);
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
        public bool eliminarProductoVendido(long id)
        {
            if (sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                int filasAfectadas = 0;
                using (SqlCommand cmd = new SqlCommand("delete from ProductoVendido where Id = @id", sqlConnection))
                {
                    sqlConnection.Open();
                    cmd.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = id });
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
