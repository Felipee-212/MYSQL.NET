using Objetos;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Obligatorio2025.Objetos;

namespace Obligatorio.Datos
{
    public class ProyectoDatos
    {
        private readonly ConexionBD conexion = new ConexionBD();

        public List<Proyecto> ListarProyectos()
        {
            var lista = new List<Proyecto>();

            using (MySqlConnection con = conexion.AbrirConexion())
            using (MySqlCommand cmd = new MySqlCommand("ListarProyectos", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // ----- FIX EN TIPO -----
                            EnumeradosProyecto.TipoProyecto tipoResult =
                                reader.IsDBNull(reader.GetOrdinal("Tipo"))
                                ? EnumeradosProyecto.TipoProyecto.PorHora
                                : Enum.TryParse(reader.GetString("Tipo"), true, out EnumeradosProyecto.TipoProyecto tipoTemp)
                                    ? tipoTemp
                                    : EnumeradosProyecto.TipoProyecto.PorHora;

                            // ----- FIX EN ESTADO -----
                            EnumeradosProyecto.EstadoProyecto estadoResult =
                                reader.IsDBNull(reader.GetOrdinal("Estado"))
                                ? EnumeradosProyecto.EstadoProyecto.Planificado
                                : Enum.TryParse(reader.GetString("Estado"), true, out EnumeradosProyecto.EstadoProyecto estTemp)
                                    ? estTemp
                                    : EnumeradosProyecto.EstadoProyecto.Planificado;

                            var proyecto = new Proyecto
                            {
                                Id = reader.GetInt32("Id"),
                                IdCliente = reader.GetInt32("IdCliente"),

                                ClienteNombre = reader.IsDBNull(reader.GetOrdinal("ClienteNombre"))
                                    ? null
                                    : reader.GetString("ClienteNombre"),

                                NombreProyecto = reader.GetString("NombreProyecto"),

                                Tipo = tipoResult,
                                Estado = estadoResult,

                                FechaInicio = reader.GetDateTime("FechaInicio"),

                                PresupuestoInicial = reader.GetDouble("PresupuestoInicial"),

                                FechaFinPlanificada = reader.IsDBNull(reader.GetOrdinal("FechaFinPlanificada"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime("FechaFinPlanificada"),

                                FechaFin = reader.IsDBNull(reader.GetOrdinal("FechaFin"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime("FechaFin")
                            };

                            lista.Add(proyecto);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw new Exception("Error al listar proyectos: " + ex.Message);
                }
            }

            return lista;
        }


        public void IngresarProyecto(Proyecto proyecto)
        {
            try
            {
                using (MySqlConnection con = conexion.AbrirConexion())
                using (MySqlCommand cmd = new MySqlCommand("IngresarProyecto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pIdCliente", proyecto.IdCliente);
                    cmd.Parameters.AddWithValue("@pNombre", proyecto.NombreProyecto);
                    cmd.Parameters.AddWithValue("@pTipo", proyecto.Tipo.ToString());
                    cmd.Parameters.AddWithValue("@pFechaInicio", proyecto.FechaInicio);
                    cmd.Parameters.AddWithValue("@pPresupuesto", proyecto.PresupuestoInicial);

                    cmd.Parameters.AddWithValue("@pFechaFinPlanificada",
                        (object?)proyecto.FechaFinPlanificada ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@pFechaFin",
                        (object?)proyecto.FechaFin ?? DBNull.Value);

                    cmd.Parameters.AddWithValue("@pEstado", proyecto.Estado.ToString());

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error al ingresar proyecto: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


        public void EliminarProyecto(int id)
        {
            try
            {
                using (MySqlConnection con = conexion.AbrirConexion())
                using (MySqlCommand cmd = new MySqlCommand("EliminarProyecto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pIdProyecto", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error al eliminar proyecto: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }
}
