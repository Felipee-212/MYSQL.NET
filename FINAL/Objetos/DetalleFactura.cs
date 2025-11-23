namespace Objetos
{
    public class DetalleFactura
    {
        public int IdDetalle { get; set; }   
        public int IdFactura { get; set; }   
        public string Descripcion { get; set; }
        public double Monto { get; set; }

        public DetalleFactura() { }

        public DetalleFactura(string descripcion, double monto)
        {
            Descripcion = descripcion;
            Monto = monto;
        }
    }
}
