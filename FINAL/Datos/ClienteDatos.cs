using MySql.Data.MySqlClient;
using System.Data;
using Objetos;
using Obligatorio2025.Objetos;

namespace Obligatorio.Datos
{
    public class ClienteDatos
    {
        private readonly ConexionBD conexion = new ConexionBD();

        

        public List<Cliente> ListarClientes()
        {
            var listaClientes = new List<Cliente>();

            using (MySqlConnection con = conexion.AbrirConexion())
            {
                using (MySqlCommand comando = new MySqlCommand("ListarClientes", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var cliente = new Cliente
                                {
                                    IdCliente = reader.GetInt32("IdCliente"),
                                    RazonSocial = reader.GetString("RazonSocial"),
                                    RUT = reader.GetString("RUT"),
                                    Direccion = reader.GetString("Direccion")
                                };

                                listaClientes.Add(cliente);
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception("Error al listar clientes: " + ex.Message);
                    }
                }
            }

            return listaClientes;
        }


        public void IngresarClientes(Cliente cliente)
        {
            try
            {
                using (MySqlConnection con = conexion.AbrirConexion())
                using (MySqlCommand comando = new MySqlCommand("IngresarCliente", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("pRazonSocial", cliente.RazonSocial);
                    comando.Parameters.AddWithValue("pRUT", cliente.RUT);
                    comando.Parameters.AddWithValue("pDireccion", cliente.Direccion);

                    comando.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al ingresar cliente: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


        public void EliminarCliente(int id)
        {
            try
            {
                using (MySqlConnection con = conexion.AbrirConexion())
                using (MySqlCommand comando = new MySqlCommand("EliminarCliente", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", id);

                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al eliminar cliente: " + ex.Message);
                throw;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


        public void ModificarClientes(Cliente cliente)
        {
            try
            {
                using (MySqlConnection con = conexion.AbrirConexion())
                using (MySqlCommand comando = new MySqlCommand("ModificarCliente", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    comando.Parameters.AddWithValue("@RazonSocial", cliente.RazonSocial);
                    comando.Parameters.AddWithValue("@RUT", cliente.RUT);
                    comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al modificar el cliente: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


        public Cliente BuscarClientePorId(int id)
        {
            Cliente cliente = null;

            try
            {
                using (MySqlConnection con = conexion.AbrirConexion())
                using (MySqlCommand comando = new MySqlCommand("BuscarClientePorId", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdCliente", id);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                IdCliente = reader.GetInt32("IdCliente"),
                                RazonSocial = reader.GetString("RazonSocial"),
                                RUT = reader.GetString("RUT"),
                                Direccion = reader.GetString("Direccion")
                            };
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al buscar cliente por ID: " + ex.Message);
                return null;
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return cliente;
        }
    }
}
