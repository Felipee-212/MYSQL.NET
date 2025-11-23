using Objetos;
using System;
using System.Collections.Generic;
using Obligatorio2025.Datos;
using Obligatorio.Datos;

namespace Logica
{
    public class LogicaClientes
    {
        ClienteDatos clientedatos = new ClienteDatos();

        public List<Cliente> ListarClientes()
        {
            try
            {
                return clientedatos.ListarClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de negocio: " + ex.Message);
            }
        }

        public string IngresarClientes(Cliente cliente)
        {
            try
            {
                clientedatos.IngresarClientes(cliente);
                return "Cliente ingresado con éxito";
            }
            catch (Exception ex)
            {
                return "Error al ingresar cliente: " + ex.Message;
            }
        }

        public string ModificarClientes(Cliente cliente)
        {
            if (cliente.IdCliente <= 0)
                throw new Exception("ID de cliente inválido");

            if (string.IsNullOrWhiteSpace(cliente.RazonSocial))
                throw new Exception("La razón social es obligatoria");

            if (string.IsNullOrWhiteSpace(cliente.RUT))
                throw new Exception("El RUT es obligatorio");

            try
            {
                clientedatos.ModificarClientes(cliente);
                return "Cliente modificado con éxito";
            }
            catch (Exception ex)
            {
                return "Error al modificar cliente: " + ex.Message;
            }
        }

        public string EliminarCliente(int id)
        {
            try
            {
                clientedatos.EliminarCliente(id);
                return "Cliente eliminado con éxito";
            }
            catch (Exception ex)
            {
                return "Error al eliminar cliente: " + ex.Message;
            }
        }

        public Cliente BuscarCliente(int id)
        {
            if (id <= 0)
                throw new Exception("ID de cliente inválido");

            try
            {
                return clientedatos.BuscarClientePorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar cliente: " + ex.Message);
            }
        }
    }
}
