using MySql.Data.MySqlClient;
using Obligatorio.Datos;
using Obligatorio2025.Datos;
using Obligatorio2025.Objetos;
using System;

namespace Obligatorio2025.Logica
{
    public class CalculoLogica
    {
        public Calculo ObtenerCalculoMensual(int mes, int año)
        {
            
            Calculo calculo = new Calculo { Mes = mes, Año = año };

            
            if (mes < 1 || mes > 12)
                throw new Exception("El mes debe estar entre 1 y 12.");

            if (año < 2000 || año > DateTime.Now.Year)
                throw new Exception("Año inválido.");

            ConexionBD conexion = new ConexionBD();

            try
            {
                using (MySqlConnection con = conexion.AbrirConexion())
                {
                    double totalVentas = 0;
                    double totalCompras = 0;

                    
                    using (MySqlCommand cmd = new MySqlCommand("ObtenerVentaMensual", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", año);  

                        object resultado = cmd.ExecuteScalar();

                        totalVentas =
                            (resultado == null || resultado == DBNull.Value)
                            ? 0
                            : Convert.ToDouble(resultado);
                    }

                    
                    using (MySqlCommand cmd = new MySqlCommand("ObtenerCompraMensual", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", año);

                        object resultado = cmd.ExecuteScalar();

                        totalCompras =
                            (resultado == null || resultado == DBNull.Value)
                            ? 0
                            : Convert.ToDouble(resultado);
                    }

                    
                    calculo.Calcular(totalVentas, totalCompras);
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error al obtener cálculo mensual: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return calculo;
        }
    }
}
