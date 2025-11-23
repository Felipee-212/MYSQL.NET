using System;
using Obligatorio2025.Objetos;

namespace Objetos
{
    public class Proyecto
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }

        public string NombreProyecto { get; set; }

        public EnumeradosProyecto.TipoProyecto Tipo { get; set; }

        public DateTime FechaInicio { get; set; }

        public double PresupuestoInicial { get; set; }

        public DateTime? FechaFinPlanificada { get; set; }
        public DateTime? FechaFin { get; set; }

        public EnumeradosProyecto.EstadoProyecto Estado { get; set; }
        public string ClienteNombre { get; set; }

        public Proyecto() { }

        public Proyecto(
            int idCliente,
            string nombre,
            EnumeradosProyecto.TipoProyecto tipo,
            double presupuesto,
            DateTime fechaInicio
        )
        {
            IdCliente = idCliente;
            NombreProyecto = nombre;
            Tipo = tipo;
            PresupuestoInicial = presupuesto;
            FechaInicio = fechaInicio;
            Estado = EnumeradosProyecto.EstadoProyecto.Planificado;
        }
    }
}
