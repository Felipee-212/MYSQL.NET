using Objetos;
using Obligatorio.Datos;
using Obligatorio2025.Datos;
using Obligatorio2025.Objetos;
using System;
using System.Collections.Generic;

namespace Obligatorio2025.Logica
{
    public class LogicaFactura
    {
        private readonly FacturaVentaDatos facturaDatos = new();
        private readonly ClienteDatos clienteDatos = new();

        public List<FacturaVenta> ListarFactura()
        {
            try
            {
                return facturaDatos.ListarFacturas();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar facturas: " + ex.Message);
            }
        }

        public string AgregarFacturaVenta(FacturaVenta factura)
        {
            if (factura.IdCliente <= 0)
                throw new Exception("Debe especificar un cliente");

            Cliente cliente = clienteDatos.BuscarClientePorId(factura.IdCliente);
            if (cliente == null)
                throw new Exception("El cliente especificado no existe");

            if (factura.Renglones == null || factura.Renglones.Count == 0)
                throw new Exception("La factura debe tener al menos un renglón");

            foreach (var renglon in factura.Renglones)
            {
                if (renglon.Monto <= 0)
                    throw new Exception("Los montos deben ser mayores a cero");
            }

            factura.CalcularTotales();

            try
            {
                facturaDatos.AgregarFacturaVenta(factura);
                return "Factura agregada con éxito";
            }
            catch (Exception ex)
            {
                return "Error al agregar factura: " + ex.Message;
            }
        }
    }
}
