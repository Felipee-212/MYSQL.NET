using System;
using System.Drawing;
using System.Windows.Forms;

namespace Obligatorio2025.Desktop;

partial class Form1
{
    private System.ComponentModel.IContainer? components = null;

    private TabControl tabControl;
    private TabPage tabVentas;
    private TabPage tabCompras;
    private TabPage tabCalculo;
    private DataGridView gridVentas;
    private Button btnRefrescarVentas;
    private Button btnGuardarVenta;
    private Label lblVentasEstado;
    private TextBox txtVentaNumero;
    private TextBox txtVentaClienteId;
    private TextBox txtVentaProyectoId;
    private DateTimePicker dtpVentaFecha;
    private NumericUpDown numVentaMonto;
    private TextBox txtVentaDescripcion;
    private TextBox txtCompraNro;
    private TextBox txtCompraRazon;
    private TextBox txtCompraRUT;
    private TextBox txtCompraDireccion;
    private DateTimePicker dtpCompraFecha;
    private NumericUpDown numCompraSubTotal;
    private Button btnGuardarCompra;
    private Label lblCompraEstado;
    private Label lblCompraTotales;
    private NumericUpDown numMes;
    private NumericUpDown numAnio;
    private Button btnCalcular;
    private Label lblCalculoVentas;
    private Label lblCalculoCompras;
    private Label lblCalculoIVA;
    private Label lblCalculoIRAE;
    private Label lblCalculoEstado;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        tabControl = new TabControl();
        tabVentas = new TabPage();
        label1 = new Label();
        lblVentasEstado = new Label();
        btnGuardarVenta = new Button();
        txtVentaDescripcion = new TextBox();
        numVentaMonto = new NumericUpDown();
        dtpVentaFecha = new DateTimePicker();
        txtVentaProyectoId = new TextBox();
        txtVentaClienteId = new TextBox();
        txtVentaNumero = new TextBox();
        btnRefrescarVentas = new Button();
        gridVentas = new DataGridView();
        tabCompras = new TabPage();
        lblCompraTotales = new Label();
        lblCompraEstado = new Label();
        btnGuardarCompra = new Button();
        numCompraSubTotal = new NumericUpDown();
        dtpCompraFecha = new DateTimePicker();
        txtCompraDireccion = new TextBox();
        txtCompraRUT = new TextBox();
        txtCompraRazon = new TextBox();
        txtCompraNro = new TextBox();
        tabCalculo = new TabPage();
        lblCalculoEstado = new Label();
        lblCalculoIRAE = new Label();
        lblCalculoIVA = new Label();
        lblCalculoCompras = new Label();
        lblCalculoVentas = new Label();
        btnCalcular = new Button();
        numAnio = new NumericUpDown();
        numMes = new NumericUpDown();
        tabControl.SuspendLayout();
        tabVentas.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numVentaMonto).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridVentas).BeginInit();
        tabCompras.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numCompraSubTotal).BeginInit();
        tabCalculo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numAnio).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numMes).BeginInit();
        SuspendLayout();
        // 
        // tabControl
        // 
        tabControl.Controls.Add(tabVentas);
        tabControl.Controls.Add(tabCompras);
        tabControl.Controls.Add(tabCalculo);
        tabControl.Dock = DockStyle.Fill;
        tabControl.Location = new Point(0, 0);
        tabControl.Margin = new Padding(3, 2, 3, 2);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(917, 511);
        tabControl.TabIndex = 0;
        // 
        // tabVentas
        // 
        tabVentas.Controls.Add(label1);
        tabVentas.Controls.Add(lblVentasEstado);
        tabVentas.Controls.Add(btnGuardarVenta);
        tabVentas.Controls.Add(txtVentaDescripcion);
        tabVentas.Controls.Add(numVentaMonto);
        tabVentas.Controls.Add(dtpVentaFecha);
        tabVentas.Controls.Add(txtVentaProyectoId);
        tabVentas.Controls.Add(txtVentaClienteId);
        tabVentas.Controls.Add(txtVentaNumero);
        tabVentas.Controls.Add(btnRefrescarVentas);
        tabVentas.Controls.Add(gridVentas);
        tabVentas.Location = new Point(4, 24);
        tabVentas.Margin = new Padding(3, 2, 3, 2);
        tabVentas.Name = "tabVentas";
        tabVentas.Padding = new Padding(3, 2, 3, 2);
        tabVentas.Size = new Size(909, 483);
        tabVentas.TabIndex = 0;
        tabVentas.Text = "Facturas de venta";
        tabVentas.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(786, 11);
        label1.Name = "label1";
        label1.Size = new Size(109, 15);
        label1.TabIndex = 1;
        label1.Text = "Cargas realizadas: 0";
        label1.Click += label1_Click;
        // 
        // lblVentasEstado
        // 
        lblVentasEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblVentasEstado.Location = new Point(121, 11);
        lblVentasEstado.Name = "lblVentasEstado";
        lblVentasEstado.Size = new Size(774, 25);
        lblVentasEstado.TabIndex = 2;
        lblVentasEstado.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnGuardarVenta
        // 
        btnGuardarVenta.Location = new Point(787, 74);
        btnGuardarVenta.Margin = new Padding(3, 2, 3, 2);
        btnGuardarVenta.Name = "btnGuardarVenta";
        btnGuardarVenta.Size = new Size(101, 25);
        btnGuardarVenta.TabIndex = 5;
        btnGuardarVenta.Text = "Guardar";
        btnGuardarVenta.UseVisualStyleBackColor = true;
        btnGuardarVenta.Click += btnGuardarVenta_Click;
        // 
        // txtVentaDescripcion
        // 
        txtVentaDescripcion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtVentaDescripcion.Location = new Point(13, 74);
        txtVentaDescripcion.Margin = new Padding(3, 2, 3, 2);
        txtVentaDescripcion.Name = "txtVentaDescripcion";
        txtVentaDescripcion.PlaceholderText = "Descripcion";
        txtVentaDescripcion.Size = new Size(768, 23);
        txtVentaDescripcion.TabIndex = 7;
        // 
        // numVentaMonto
        // 
        numVentaMonto.DecimalPlaces = 2;
        numVentaMonto.Location = new Point(705, 45);
        numVentaMonto.Margin = new Padding(3, 2, 3, 2);
        numVentaMonto.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        numVentaMonto.Name = "numVentaMonto";
        numVentaMonto.Size = new Size(190, 23);
        numVentaMonto.TabIndex = 4;
        numVentaMonto.ThousandsSeparator = true;
        // 
        // dtpVentaFecha
        // 
        dtpVentaFecha.Location = new Point(479, 45);
        dtpVentaFecha.Margin = new Padding(3, 2, 3, 2);
        dtpVentaFecha.Name = "dtpVentaFecha";
        dtpVentaFecha.Size = new Size(210, 23);
        dtpVentaFecha.TabIndex = 3;
        // 
        // txtVentaProyectoId
        // 
        txtVentaProyectoId.Location = new Point(300, 45);
        txtVentaProyectoId.Margin = new Padding(3, 2, 3, 2);
        txtVentaProyectoId.Name = "txtVentaProyectoId";
        txtVentaProyectoId.PlaceholderText = "Id Proyecto (opcional)";
        txtVentaProyectoId.Size = new Size(167, 23);
        txtVentaProyectoId.TabIndex = 2;
        // 
        // txtVentaClienteId
        // 
        txtVentaClienteId.Location = new Point(157, 45);
        txtVentaClienteId.Margin = new Padding(3, 2, 3, 2);
        txtVentaClienteId.Name = "txtVentaClienteId";
        txtVentaClienteId.PlaceholderText = "Id Cliente";
        txtVentaClienteId.Size = new Size(132, 23);
        txtVentaClienteId.TabIndex = 1;
        // 
        // txtVentaNumero
        // 
        txtVentaNumero.Location = new Point(13, 45);
        txtVentaNumero.Margin = new Padding(3, 2, 3, 2);
        txtVentaNumero.Name = "txtVentaNumero";
        txtVentaNumero.PlaceholderText = "Nro. factura";
        txtVentaNumero.Size = new Size(132, 23);
        txtVentaNumero.TabIndex = 0;
        // 
        // btnRefrescarVentas
        // 
        btnRefrescarVentas.Location = new Point(13, 11);
        btnRefrescarVentas.Margin = new Padding(3, 2, 3, 2);
        btnRefrescarVentas.Name = "btnRefrescarVentas";
        btnRefrescarVentas.Size = new Size(94, 25);
        btnRefrescarVentas.TabIndex = 6;
        btnRefrescarVentas.Text = "Refrescar";
        btnRefrescarVentas.UseVisualStyleBackColor = true;
        btnRefrescarVentas.Click += btnRefrescarVentas_Click;
        // 
        // gridVentas
        // 
        gridVentas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        gridVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        gridVentas.Location = new Point(13, 110);
        gridVentas.Margin = new Padding(3, 2, 3, 2);
        gridVentas.Name = "gridVentas";
        gridVentas.RowHeadersWidth = 51;
        gridVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridVentas.Size = new Size(882, 356);
        gridVentas.TabIndex = 8;
        // 
        // tabCompras
        // 
        tabCompras.Controls.Add(lblCompraTotales);
        tabCompras.Controls.Add(lblCompraEstado);
        tabCompras.Controls.Add(btnGuardarCompra);
        tabCompras.Controls.Add(numCompraSubTotal);
        tabCompras.Controls.Add(dtpCompraFecha);
        tabCompras.Controls.Add(txtCompraDireccion);
        tabCompras.Controls.Add(txtCompraRUT);
        tabCompras.Controls.Add(txtCompraRazon);
        tabCompras.Controls.Add(txtCompraNro);
        tabCompras.Location = new Point(4, 24);
        tabCompras.Margin = new Padding(3, 2, 3, 2);
        tabCompras.Name = "tabCompras";
        tabCompras.Padding = new Padding(3, 2, 3, 2);
        tabCompras.Size = new Size(909, 483);
        tabCompras.TabIndex = 1;
        tabCompras.Text = "Ingresar compra";
        tabCompras.UseVisualStyleBackColor = true;
        // 
        // lblCompraTotales
        // 
        lblCompraTotales.AutoSize = true;
        lblCompraTotales.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCompraTotales.Location = new Point(19, 268);
        lblCompraTotales.Name = "lblCompraTotales";
        lblCompraTotales.Size = new Size(0, 19);
        lblCompraTotales.TabIndex = 8;
        // 
        // lblCompraEstado
        // 
        lblCompraEstado.Location = new Point(19, 297);
        lblCompraEstado.Name = "lblCompraEstado";
        lblCompraEstado.Size = new Size(584, 42);
        lblCompraEstado.TabIndex = 7;
        // 
        // btnGuardarCompra
        // 
        btnGuardarCompra.Location = new Point(19, 238);
        btnGuardarCompra.Margin = new Padding(3, 2, 3, 2);
        btnGuardarCompra.Name = "btnGuardarCompra";
        btnGuardarCompra.Size = new Size(109, 27);
        btnGuardarCompra.TabIndex = 6;
        btnGuardarCompra.Text = "Guardar";
        btnGuardarCompra.UseVisualStyleBackColor = true;
        btnGuardarCompra.Click += btnGuardarCompra_Click;
        // 
        // numCompraSubTotal
        // 
        numCompraSubTotal.DecimalPlaces = 2;
        numCompraSubTotal.Location = new Point(19, 195);
        numCompraSubTotal.Margin = new Padding(3, 2, 3, 2);
        numCompraSubTotal.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        numCompraSubTotal.Name = "numCompraSubTotal";
        numCompraSubTotal.Size = new Size(190, 23);
        numCompraSubTotal.TabIndex = 5;
        numCompraSubTotal.ThousandsSeparator = true;
        // 
        // dtpCompraFecha
        // 
        dtpCompraFecha.Location = new Point(19, 152);
        dtpCompraFecha.Margin = new Padding(3, 2, 3, 2);
        dtpCompraFecha.Name = "dtpCompraFecha";
        dtpCompraFecha.Size = new Size(190, 23);
        dtpCompraFecha.TabIndex = 4;
        // 
        // txtCompraDireccion
        // 
        txtCompraDireccion.Location = new Point(19, 116);
        txtCompraDireccion.Margin = new Padding(3, 2, 3, 2);
        txtCompraDireccion.Name = "txtCompraDireccion";
        txtCompraDireccion.PlaceholderText = "Direccion proveedor";
        txtCompraDireccion.Size = new Size(295, 23);
        txtCompraDireccion.TabIndex = 3;
        // 
        // txtCompraRUT
        // 
        txtCompraRUT.Location = new Point(19, 81);
        txtCompraRUT.Margin = new Padding(3, 2, 3, 2);
        txtCompraRUT.Name = "txtCompraRUT";
        txtCompraRUT.PlaceholderText = "RUT proveedor";
        txtCompraRUT.Size = new Size(190, 23);
        txtCompraRUT.TabIndex = 2;
        // 
        // txtCompraRazon
        // 
        txtCompraRazon.Location = new Point(19, 47);
        txtCompraRazon.Margin = new Padding(3, 2, 3, 2);
        txtCompraRazon.Name = "txtCompraRazon";
        txtCompraRazon.PlaceholderText = "Razon social proveedor";
        txtCompraRazon.Size = new Size(295, 23);
        txtCompraRazon.TabIndex = 1;
        // 
        // txtCompraNro
        // 
        txtCompraNro.Location = new Point(19, 14);
        txtCompraNro.Margin = new Padding(3, 2, 3, 2);
        txtCompraNro.Name = "txtCompraNro";
        txtCompraNro.PlaceholderText = "Nro. factura";
        txtCompraNro.Size = new Size(190, 23);
        txtCompraNro.TabIndex = 0;
        // 
        // tabCalculo
        // 
        tabCalculo.Controls.Add(lblCalculoEstado);
        tabCalculo.Controls.Add(lblCalculoIRAE);
        tabCalculo.Controls.Add(lblCalculoIVA);
        tabCalculo.Controls.Add(lblCalculoCompras);
        tabCalculo.Controls.Add(lblCalculoVentas);
        tabCalculo.Controls.Add(btnCalcular);
        tabCalculo.Controls.Add(numAnio);
        tabCalculo.Controls.Add(numMes);
        tabCalculo.Location = new Point(4, 24);
        tabCalculo.Margin = new Padding(3, 2, 3, 2);
        tabCalculo.Name = "tabCalculo";
        tabCalculo.Padding = new Padding(3, 2, 3, 2);
        tabCalculo.Size = new Size(909, 483);
        tabCalculo.TabIndex = 2;
        tabCalculo.Text = "Calculo IVA/IRAE";
        tabCalculo.UseVisualStyleBackColor = true;
        // 
        // lblCalculoEstado
        // 
        lblCalculoEstado.Location = new Point(24, 209);
        lblCalculoEstado.Name = "lblCalculoEstado";
        lblCalculoEstado.Size = new Size(474, 40);
        lblCalculoEstado.TabIndex = 7;
        // 
        // lblCalculoIRAE
        // 
        lblCalculoIRAE.AutoSize = true;
        lblCalculoIRAE.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCalculoIRAE.Location = new Point(24, 178);
        lblCalculoIRAE.Name = "lblCalculoIRAE";
        lblCalculoIRAE.Size = new Size(0, 19);
        lblCalculoIRAE.TabIndex = 6;
        // 
        // lblCalculoIVA
        // 
        lblCalculoIVA.AutoSize = true;
        lblCalculoIVA.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCalculoIVA.Location = new Point(24, 151);
        lblCalculoIVA.Name = "lblCalculoIVA";
        lblCalculoIVA.Size = new Size(0, 19);
        lblCalculoIVA.TabIndex = 5;
        // 
        // lblCalculoCompras
        // 
        lblCalculoCompras.AutoSize = true;
        lblCalculoCompras.Location = new Point(24, 124);
        lblCalculoCompras.Name = "lblCalculoCompras";
        lblCalculoCompras.Size = new Size(0, 15);
        lblCalculoCompras.TabIndex = 4;
        // 
        // lblCalculoVentas
        // 
        lblCalculoVentas.AutoSize = true;
        lblCalculoVentas.Location = new Point(24, 99);
        lblCalculoVentas.Name = "lblCalculoVentas";
        lblCalculoVentas.Size = new Size(0, 15);
        lblCalculoVentas.TabIndex = 3;
        // 
        // btnCalcular
        // 
        btnCalcular.Location = new Point(24, 62);
        btnCalcular.Margin = new Padding(3, 2, 3, 2);
        btnCalcular.Name = "btnCalcular";
        btnCalcular.Size = new Size(111, 24);
        btnCalcular.TabIndex = 2;
        btnCalcular.Text = "Calcular";
        btnCalcular.UseVisualStyleBackColor = true;
        btnCalcular.Click += btnCalcular_Click;
        // 
        // numAnio
        // 
        numAnio.Location = new Point(141, 22);
        numAnio.Margin = new Padding(3, 2, 3, 2);
        numAnio.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        numAnio.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
        numAnio.Name = "numAnio";
        numAnio.Size = new Size(105, 23);
        numAnio.TabIndex = 1;
        numAnio.Value = new decimal(new int[] { 2025, 0, 0, 0 });
        // 
        // numMes
        // 
        numMes.Location = new Point(24, 22);
        numMes.Margin = new Padding(3, 2, 3, 2);
        numMes.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
        numMes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numMes.Name = "numMes";
        numMes.Size = new Size(105, 23);
        numMes.TabIndex = 0;
        numMes.Value = new decimal(new int[] { 11, 0, 0, 0 });
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(917, 511);
        Controls.Add(tabControl);
        Margin = new Padding(3, 2, 3, 2);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestion tributaria";
        Load += Form1_Load;
        tabControl.ResumeLayout(false);
        tabVentas.ResumeLayout(false);
        tabVentas.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numVentaMonto).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridVentas).EndInit();
        tabCompras.ResumeLayout(false);
        tabCompras.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numCompraSubTotal).EndInit();
        tabCalculo.ResumeLayout(false);
        tabCalculo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numAnio).EndInit();
        ((System.ComponentModel.ISupportInitialize)numMes).EndInit();
        ResumeLayout(false);
    }
    private Label label1;
}
