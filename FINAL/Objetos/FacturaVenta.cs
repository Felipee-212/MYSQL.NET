using System;
using System.Collections.Generic;
using Objetos;

namespace Obligatorio2025.Objetos
{
    public class FacturaVenta
    {
        public int IdFactura { get; set; } 

        public int NroFactura { get; set; }
        public int IdCliente { get; set; }
        public int? IdProyecto { get; set; } 
        public DateTime FechaInicio { get; set; }

        public double SubTotal { get; set; }
        public double IVA { get; set; }
        public double Total { get; set; }
        public string Descripcion { get; set; } = string.Empty;

        public List<DetalleFactura> Renglones { get; set; }

        public FacturaVenta()
        {
            Renglones = new List<DetalleFactura>();
        }

        public void CalcularTotales()
        {
            SubTotal = 0;

            foreach (var r in Renglones)
                SubTotal += r.Monto;

            IVA = SubTotal * 0.22;
            Total = SubTotal + IVA;
        }
    }
}
