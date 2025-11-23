using MySql.Data.MySqlClient;
using Obligatorio.Datos;
using Obligatorio2025.Objetos;
using System;
using System.Collections.Generic;
using System.Data;

namespace Obligatorio2025.Datos
{
    public class FacturaCompraDatos
    {
        ConexionBD conexion = new ConexionBD();

        public void InsertarCompra(FacturaCompra compra)
        {
            using (MySqlConnection con = conexion.AbrirConexion())
            using (MySqlCommand cmd = new MySqlCommand("InsertarCompra", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_NroFactura", compra.NroFactura);
                cmd.Parameters.AddWithValue("@p_ProveedorRazonSocial", compra.ProveedorRazonSocial);
                cmd.Parameters.AddWithValue("@p_ProveedorRUT", compra.ProveedorRUT);
                cmd.Parameters.AddWithValue("@p_ProveedorDireccion", compra.ProveedorDireccion);
                cmd.Parameters.AddWithValue("@p_Fecha", compra.Fecha);
                cmd.Parameters.AddWithValue("@p_SubTotal", compra.SubTotal);
                cmd.Parameters.AddWithValue("@p_IVA", compra.IVA);
                cmd.Parameters.AddWithValue("@p_Total", compra.Total);

                cmd.ExecuteNonQuery();
            }

            conexion.CerrarConexion();
        }


        public List<FacturaCompra> ListarCompras()
        {
            var lista = new List<FacturaCompra>();

            using (MySqlConnection con = conexion.AbrirConexion())
            using (MySqlCommand cmd = new MySqlCommand("ListarCompras", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new FacturaCompra
                        {
                            NroFactura = reader.GetInt32("NroFactura"),
                            ProveedorRazonSocial = reader.GetString("ProveedorRazonSocial"),
                            ProveedorRUT = reader.GetString("ProveedorRUT"),
                            ProveedorDireccion = reader.GetString("ProveedorDireccion"),
                            Fecha = reader.GetDateTime("Fecha"),
                            SubTotal = reader.GetDecimal("SubTotal"),
                            IVA = reader.GetDecimal("IVA"),
                            Total = reader.GetDecimal("Total")
                        });
                    }
                }
            }

            conexion.CerrarConexion();
            return lista;
        }
    }
}
