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

        public Producto listarProductoId(int id)
        {
            if (sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from Producto where Id = @Id", sqlConnection))
                {
                    sqlConnection.Open();
                    cmd.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt) { Value = id });
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Producto producto = new Producto();
                            reader.Read();
                            producto.Id = reader.GetInt64(0);
                            producto.Descripcion = reader.GetString(1);
                            producto.Costo = reader.GetDecimal(2);
                            producto.PrecioVenta = reader.GetDecimal(3);
                            producto.Stock = reader.GetInt32(4);
                            producto.IdUsuario = reader.GetInt64(5);
                            return producto;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex}");
            }
        }

        public bool cargarProducto(Producto producto)
        {
            if (sqlConnection == null)
            {
                throw new Exception("Conexion no establecidad");
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("insert into Producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario) values(@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)", sqlConnection))
                {
                    sqlConnection.Open();
                    cmd.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripcion });
                    cmd.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                    cmd.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                    cmd.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                    cmd.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario });
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex}");
                return false;
            }
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
