using ProyectoPuntoDeVenta.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoPuntoDeVenta.Repositories
{
    public class ProductosRepositories
    {
        SqlConnection? sqlConnection;
        String connection = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

        public ProductosRepositories()
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
        public List<Producto> listarProductos()
        {
            List<Producto> lista = new List<Producto>();
            if(sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from Producto", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = reader.GetInt64(0);
                                producto.Descripcion = reader.GetString(1);
                                producto.Costo = reader.GetDecimal(2);
                                producto.PrecioVenta = reader.GetDecimal(3);
                                producto.Stock = reader.GetInt32(4);
                                producto.IdUsuario = reader.GetInt64(5);
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

        public bool eliminarProductos(long id)
        {
            if (sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                int filasAfectadas = 0;
                using (SqlCommand cmd = new SqlCommand("delete from Producto where Id = @id", sqlConnection))
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
