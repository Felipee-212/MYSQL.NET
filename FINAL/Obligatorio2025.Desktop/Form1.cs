using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Objetos;
using Obligatorio2025.Logica;
using Obligatorio2025.Datos;
using Obligatorio2025.Objetos;

namespace Obligatorio2025.Desktop;

public partial class Form1 : Form
{
    private readonly FacturaCompraDatos _facturaCompraDatos = new();
    private readonly CalculoLogica _calculoLogica = new();
    private readonly LogicaFactura _logicaFactura = new();
    private static readonly HttpClient client = new HttpClient();

    private async Task<int> IncrementarContadorAsync()
    {
        var response = await client.PostAsync("http://localhost:5092/incrementar", null);
        string content = await response.Content.ReadAsStringAsync();
        return int.Parse(content);
    }

    public Form1()
    {
        InitializeComponent();
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        _ = CargarFacturasAsync();
    }

    // Lee todas las facturas de venta desde la lógica (base de datos).
    private async Task CargarFacturasAsync()
    {
        try
        {
            var facturas = _logicaFactura.ListarFactura();
            gridVentas.AutoGenerateColumns = true;
            gridVentas.DataSource = facturas;

            if (facturas.Count == 0)
                MostrarOk(lblVentasEstado, "No hay facturas cargadas.");
            else
                MostrarOk(lblVentasEstado, $"Facturas cargadas: {facturas.Count}.");
        }
        catch (Exception ex)
        {
            MostrarError(lblVentasEstado, $"No se pudieron cargar las facturas: {ex.Message}");
        }
    }

    // Actualiza la grilla con los datos actuales.
    private async void btnRefrescarVentas_Click(object sender, EventArgs e)
    {
        await CargarFacturasAsync();
    }

    // Inserta una factura de venta después de validar los campos.
    private async void btnGuardarVenta_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtVentaNumero.Text))
                throw new Exception("Ingrese el numero de factura.");
            if (string.IsNullOrWhiteSpace(txtVentaClienteId.Text))
                throw new Exception("Ingrese el Id del cliente.");
            if (string.IsNullOrWhiteSpace(txtVentaDescripcion.Text))
                throw new Exception("Ingrese una descripcion.");
            if (numVentaMonto.Value <= 0)
                throw new Exception("El monto debe ser mayor a cero.");

            int? proyectoId = string.IsNullOrWhiteSpace(txtVentaProyectoId.Text)
                ? (int?)null
                : int.Parse(txtVentaProyectoId.Text);

            var factura = new FacturaVenta
            {
                NroFactura = int.Parse(txtVentaNumero.Text),
                IdCliente = int.Parse(txtVentaClienteId.Text),
                IdProyecto = proyectoId,
                FechaInicio = dtpVentaFecha.Value.Date,
                Renglones = new List<DetalleFactura>
            {
                new(txtVentaDescripcion.Text.Trim(), (double)numVentaMonto.Value)
            }
            };

            string resultado = _logicaFactura.AgregarFacturaVenta(factura);

            MostrarOk(lblVentasEstado, resultado);
            await CargarFacturasAsync();


            int nuevoContador = await IncrementarContadorAsync();
            label1.Text = $"Cargas realizadas: {nuevoContador}";

        }
        catch (Exception ex)
        {
            MostrarError(lblVentasEstado, ex.Message);
        }
    }


    // Inserta una factura de compra calculando IVA y total.
    private void btnGuardarCompra_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtCompraNro.Text))
                throw new Exception("Ingrese el Nro. de factura.");
            if (string.IsNullOrWhiteSpace(txtCompraRazon.Text))
                throw new Exception("Ingrese la razon social.");
            if (string.IsNullOrWhiteSpace(txtCompraRUT.Text))
                throw new Exception("Ingrese el RUT.");
            if (string.IsNullOrWhiteSpace(txtCompraDireccion.Text))
                throw new Exception("Ingrese la direccion.");

            var compra = new FacturaCompra
            {
                NroFactura = int.Parse(txtCompraNro.Text),
                ProveedorRazonSocial = txtCompraRazon.Text.Trim(),
                ProveedorRUT = txtCompraRUT.Text.Trim(),
                ProveedorDireccion = txtCompraDireccion.Text.Trim(),
                Fecha = dtpCompraFecha.Value.Date,
                SubTotal = numCompraSubTotal.Value,
            };

            compra.IVA = Math.Round(compra.SubTotal * 0.22m, 2);
            compra.Total = Math.Round(compra.SubTotal + compra.IVA, 2);

            _facturaCompraDatos.InsertarCompra(compra);

            lblCompraTotales.Text = $"IVA: {compra.IVA:C2} | Total: {compra.Total:C2}";
            lblCompraTotales.ForeColor = System.Drawing.Color.Navy;
            MostrarOk(lblCompraEstado, "Compra guardada correctamente.");
        }
        catch (Exception ex)
        {
            MostrarError(lblCompraEstado, ex.Message);
        }
    }

    // Muestra el cálculo mensual de IVA e IRAE.
    private void btnCalcular_Click(object sender, EventArgs e)
    {
        try
        {
            int mes = (int)numMes.Value;
            int anio = (int)numAnio.Value;

            Calculo resultado = _calculoLogica.ObtenerCalculoMensual(mes, anio);

            lblCalculoVentas.Text = $"Ventas: {resultado.TotalVentas:C2}";
            lblCalculoCompras.Text = $"Compras: {resultado.TotalCompras:C2}";
            lblCalculoIVA.Text = $"IVA (V-C): {resultado.IVA:C2}";
            lblCalculoIRAE.Text = $"IRAE (12% ventas): {resultado.IRAE:C2}";
            MostrarOk(lblCalculoEstado, "Calculo obtenido.");
        }
        catch (Exception ex)
        {
            MostrarError(lblCalculoEstado, ex.Message);
        }
    }

    private static void MostrarError(Label label, string mensaje)
    {
        label.Text = mensaje;
        label.ForeColor = System.Drawing.Color.DarkRed;
    }

    private static void MostrarOk(Label label, string mensaje)
    {
        label.Text = mensaje;
        label.ForeColor = System.Drawing.Color.DarkGreen;
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
}
