using System;

namespace Obligatorio2025.Objetos
{
    public class FacturaCompra
    {
        public int IdCompra { get; set; } 

        public int NroFactura { get; set; }
        public string ProveedorRazonSocial { get; set; }
        public string ProveedorRUT { get; set; }
        public string ProveedorDireccion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }

        public FacturaCompra() { }

        public FacturaCompra(int idCompra, int nroFactura, string razon, string rut,
                             string direccion, DateTime fecha,
                             decimal subt, decimal iva, decimal total)
        {
            IdCompra = idCompra;
            NroFactura = nroFactura;
            ProveedorRazonSocial = razon;
            ProveedorRUT = rut;
            ProveedorDireccion = direccion;
            Fecha = fecha;
            SubTotal = subt;
            IVA = iva;
            Total = total;
        }
    }
}
