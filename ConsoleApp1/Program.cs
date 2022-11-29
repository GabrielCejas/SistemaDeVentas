// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System.Collections.Generic;
using SistemaDeVentas;




static void ConsultarUsuarios()
{
    String connection = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

    try
    {
        Console.WriteLine("Creando la conexion");
        using (SqlConnection sqlConnection = new SqlConnection(connection))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Usuario", sqlConnection))
            {
                sqlConnection.Open();
                List<Usuario> lista = new List<Usuario>();
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
            sqlConnection.Close();
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void ConsultarProductos()
{
    String connection = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

    try
    {
        Console.WriteLine("Creando la conexion");
        using (SqlConnection sqlConnection = new SqlConnection(connection))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Producto", sqlConnection))
            {
                sqlConnection.Open();
                List<Producto> lista = new List<Producto>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto();
                            producto.id = reader.GetInt64(0);
                            producto.Descripcion = reader.GetString(1);
                            producto.Costo = reader.GetDecimal(2);
                            producto.PrecioVenta = reader.GetDecimal(3);
                            producto.Stock = reader.GetInt32(4);
                            producto.IdUsuario= reader.GetInt64(5);
                            lista.Add(producto);
                        }
                        Console.WriteLine("Mostrando lista de productos");
                        foreach (Producto producto in lista)
                        {
                            Console.WriteLine($"Id: {producto.id}");
                            Console.WriteLine($"Descripcion: {producto.Descripcion}");
                            Console.WriteLine($"Costo: {producto.Costo}");
                            Console.WriteLine($"Precio de Venta: {producto.PrecioVenta}");
                            Console.WriteLine($"Stock: {producto.Stock}");
                            Console.WriteLine($"Id Usuario: {producto.IdUsuario}");
                        }
                    }
                    else
                    {
                        Console.Write("Sin registros");
                    }
                }
            }
            Console.WriteLine("Cerrando la conexion");
            sqlConnection.Close();
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void ConsultarProductosVendidos()
{
    String connection = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

    try
    {
        Console.WriteLine("Creando la conexion");
        using (SqlConnection sqlConnection = new SqlConnection(connection))
        {
            using (SqlCommand cmd = new SqlCommand("select * from ProductoVendido", sqlConnection))
            {
                sqlConnection.Open();
                List<ProductoVendido> lista = new List<ProductoVendido>();
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
                        Console.WriteLine("Mostrando lista de productos vendidos");
                        foreach (ProductoVendido producto in lista)
                        {
                            Console.WriteLine($"Id: {producto.Id}");
                            Console.WriteLine($"Stock: {producto.Stock}");
                            Console.WriteLine($"Id Producto: {producto.IdProducto}");
                            Console.WriteLine($"Id Venta: {producto.IdVenta}");
                        }
                    }
                    else
                    {
                        Console.Write("Sin registros");
                    }
                }
            }
            Console.WriteLine("Cerrando la conexion");
            sqlConnection.Close();
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void ConsultarVentas()
{
    String connection = "Server=sql.bsite.net\\MSSQL2016;Database=gabrielcejas_;User Id=gabrielcejas_;Password=Informatica2021;";

    try
    {
        Console.WriteLine("Creando la conexion");
        using (SqlConnection sqlConnection = new SqlConnection(connection))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Venta", sqlConnection))
            {
                sqlConnection.Open();
                List<Venta> lista = new List<Venta>();
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
                        Console.WriteLine("Mostrando lista de ventas");
                        foreach (Venta venta in lista)
                        {
                            Console.WriteLine($"Id: {venta.Id}");
                            Console.WriteLine($"Comentarios: {venta.Comentarios}");
                            Console.WriteLine($"Id Usuario: {venta.IdUsuario}");
                        }
                    }
                    else
                    {
                        Console.Write("Sin registros");
                    }
                }
            }
            Console.WriteLine("Cerrando la conexion");
            sqlConnection.Close();
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

ConsultarUsuarios();
ConsultarProductos();
ConsultarProductosVendidos();
ConsultarVentas();