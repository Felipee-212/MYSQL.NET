using Objetos;
using Obligatorio.Datos;
using Obligatorio2025.Datos;
using Obligatorio2025.Objetos;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class LogicaProyecto
    {
        private readonly ProyectoDatos proyectoDatos = new ProyectoDatos();
        private readonly ClienteDatos clienteDatos = new ClienteDatos();

        public string AgregarProyecto(Proyecto proyecto)
        {
            
            if (proyecto.IdCliente <= 0)
                throw new Exception("Debe seleccionar un cliente válido.");

            var cliente = clienteDatos.BuscarClientePorId(proyecto.IdCliente);
            if (cliente == null)
                throw new Exception("El cliente especificado no existe.");

            if (string.IsNullOrWhiteSpace(proyecto.NombreProyecto))
                throw new Exception("El nombre del proyecto es obligatorio.");

            if (!Enum.IsDefined(typeof(EnumeradosProyecto.TipoProyecto), proyecto.Tipo))
                throw new Exception("Debe indicar un tipo de proyecto válido.");

            if (proyecto.PresupuestoInicial <= 0)
                throw new Exception("El presupuesto debe ser mayor a cero.");

            if (proyecto.FechaInicio == DateTime.MinValue)
                throw new Exception("Debe especificar una fecha de inicio.");

            if (!Enum.IsDefined(typeof(EnumeradosProyecto.EstadoProyecto), proyecto.Estado))
                throw new Exception("Debe indicar un estado válido.");

            try
            {
                proyectoDatos.IngresarProyecto(proyecto);
                return "Proyecto agregado con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al agregar proyecto: " + ex.Message;
            }
        }

        public string EliminarProyecto(int idProyecto)
        {
            try
            {
                proyectoDatos.EliminarProyecto(idProyecto);
                return "Proyecto eliminado con éxito.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar proyecto: " + ex.Message;
            }
        }

        public List<Proyecto> ListarProyecto()
        {
            try
            {
                return proyectoDatos.ListarProyectos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar proyectos: " + ex.Message);
            }
        }
    }
}
