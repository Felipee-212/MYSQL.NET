namespace Obligatorio2025.Objetos
{
    public class Calculo
    {
        public int Año { get; set; }
        public int Mes { get; set; }
        public double TotalVentas { get; set; }
        public double TotalCompras { get; set; }
        public double IVA { get; set; }

        
        public double IRAE { get; set; }

        
        public DateTime FechaDelCalculo { get; set; } = DateTime.Now;

        public void Calcular(double ventas, double compras)
        {
            TotalVentas = ventas;
            TotalCompras = compras;

            
            IVA = (ventas * 0.22) - (compras * 0.22);

            
            IRAE = ventas * 0.12;
        }
    }
}
