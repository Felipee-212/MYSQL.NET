using Objetos;
using Obligatorio.Datos;
using Obligatorio2025.Objetos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Obligatorio2025.Datos
{
    public class FacturaVentaDatos
    {
        public List<FacturaVenta> ListarFacturas()
        {
            var lista = new List<FacturaVenta>();
            var conexion = new ConexionBD();

            const string sql = @"
                SELECT IdFactura, NroFactura, IdCliente, IdProyecto, FechaInicio, SubTotal, IVA, Total, Descripcion
                FROM FacturasVenta
                ORDER BY NroFactura;";

            using (MySqlConnection con = conexion.AbrirConexion())
            using (MySqlCommand comando = new MySqlCommand(sql, con))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var factura = new FacturaVenta
                        {
                            IdFactura = reader.GetInt32("IdFactura"),
                            NroFactura = reader.GetInt32("NroFactura"),
                            IdCliente = reader.GetInt32("IdCliente"),
                            IdProyecto = reader.IsDBNull(reader.GetOrdinal("IdProyecto"))
                                ? null
                                : reader.GetInt32("IdProyecto"),
                            FechaInicio = reader.GetDateTime("FechaInicio"),
                            SubTotal = reader.GetDouble("SubTotal"),
                            IVA = reader.GetDouble("IVA"),
                            Total = reader.GetDouble("Total"),
                            Descripcion = reader.GetString("Descripcion")
                        };

                        lista.Add(factura);
                    }
                }
            }

            return lista;
        }

        public void AgregarFacturaVenta(FacturaVenta factura)
        {
            if (factura == null)
                throw new ArgumentNullException(nameof(factura));
            if (factura.Renglones == null || factura.Renglones.Count == 0)
                throw new Exception("Debe agregar al menos un renglón.");

            // Calcula totales antes de persistir
            factura.CalcularTotales();
            string descripcion = factura.Renglones.First().Descripcion;

            const string sqlInsertCab = @"
                INSERT INTO FacturasVenta
                    (NroFactura, IdCliente, IdProyecto, FechaInicio, SubTotal, IVA, Total, Descripcion)
                VALUES
                    (@NroFactura, @IdCliente, @IdProyecto, @FechaInicio, @SubTotal, @IVA, @Total, @Descripcion);
                SELECT LAST_INSERT_ID();";

            const string sqlInsertDet = @"
                INSERT INTO DetallesFactura (IdFactura, Monto, Descripcion)
                VALUES (@IdFactura, @Monto, @Descripcion);";

            var conexion = new ConexionBD();

            using (MySqlConnection con = conexion.AbrirConexion())
            using (MySqlTransaction tx = con.BeginTransaction())
            {
                try
                {
                    int nuevoIdFactura;

                    using (MySqlCommand cmd = new MySqlCommand(sqlInsertCab, con, tx))
                    {
                        cmd.Parameters.AddWithValue("@NroFactura", factura.NroFactura);
                        cmd.Parameters.AddWithValue("@IdCliente", factura.IdCliente);
                        cmd.Parameters.AddWithValue("@IdProyecto", (object?)factura.IdProyecto ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaInicio", factura.FechaInicio);
                        cmd.Parameters.AddWithValue("@SubTotal", factura.SubTotal);
                        cmd.Parameters.AddWithValue("@IVA", factura.IVA);
                        cmd.Parameters.AddWithValue("@Total", factura.Total);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                        nuevoIdFactura = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    foreach (var renglon in factura.Renglones)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sqlInsertDet, con, tx))
                        {
                            cmd.Parameters.AddWithValue("@IdFactura", nuevoIdFactura);
                            cmd.Parameters.AddWithValue("@Monto", renglon.Monto);
                            cmd.Parameters.AddWithValue("@Descripcion", renglon.Descripcion);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
                finally
                {
                    conexion.CerrarConexion(con);
                }
            }
        }
    }
}
