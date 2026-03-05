using sistema_de_ventas.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_de_ventas
{
    public partial class Mov_Ventas : Form
    {
        public Mov_Ventas()
        {
            InitializeComponent();
        }

        private void Mov_Ventas_Load(object sender, EventArgs e)

        {

            VentasArticulos venta = new VentasArticulos();
            venta.ArticuloSeleccionado += ArticuloForm_ArticuloSeleccionado;

            database.conexion con = new database.conexion();
            string consulta = "select * from ventas_d";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, con.establecerConexion());
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
            con.cerrarConexion();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // para Insertar
            try
            {
                database.conexion con = new database.conexion();
                string consulta = "INSERT INTO ventas_m VALUES (@VentaNo, @TipoVentas, @ClienteNo, @ClienteNombre , @CondicionPagoNo, @VendedorNo,@FacturadorNo,@Fecha,@ValorBruto,@Descuento,@Impuesto,@ITBIS,@Costo,@ValorNeto,@Nota,@AuxiliarNo,@TurnoNo,@Estado)";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());

                comando.Parameters.AddWithValue("@VentaNo", txtVentaNo_M.Text);
                comando.Parameters.AddWithValue("@TipoVentas", txtTipo_VentaM.Text);
                comando.Parameters.AddWithValue("@ClienteNo", txtClienteNo_M.Text);
                comando.Parameters.AddWithValue("@ClienteNombre", txtNombre_Cliente_M.Text);
                comando.Parameters.AddWithValue("@CondicionPagoNo", txtCondi_pago_M.Text);
                comando.Parameters.AddWithValue("@VendedorNo", txtVendedorNo_M.Text);
                comando.Parameters.AddWithValue("@FacturadorNo", txtFacturadorNo_M.Text);
                comando.Parameters.AddWithValue("@Fecha", txtFecha_M.Text);
                comando.Parameters.AddWithValue("@ValorBruto", txtValorBruto_M.Text);
                comando.Parameters.AddWithValue("@Descuento", txtDesc_M.Text);
                comando.Parameters.AddWithValue("@Impuesto", txtImpuestos_M.Text);
                comando.Parameters.AddWithValue("@ITBIS", txtITBIS_M.Text);
                comando.Parameters.AddWithValue("@Costo", txtCosto_M.Text);
                comando.Parameters.AddWithValue("@ValorNeto", txtValorNETO_M.Text);
                comando.Parameters.AddWithValue("@Nota", txtNota_M.Text);
                comando.Parameters.AddWithValue("@AuxiliarNo", txtAuxiliar_M.Text);
                comando.Parameters.AddWithValue("@TurnoNo", txtTurno_M.Text);



                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");

                //  limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            //_______________________________________________________________________________________________
            // para Insertar
            try
            {
                database.conexion con = new database.conexion();




                // Recorremos las filas del DataGridView

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {

                    if (!fila.IsNewRow)
                    {
                        string nuevoValorColumna2 = fila.Cells["ArticuloNo"].Value.ToString();
                        string valorColumna1 = fila.Cells["ArticuloNo"].Value.ToString();
                        string valorColumna2 = fila.Cells["Descripcion"].Value.ToString();
                        string valorColumna3 = fila.Cells["Cantidad"].Value.ToString();
                        string valorColumna4 = fila.Cells["Precio"].Value.ToString();
                        string valorColumna5 = fila.Cells["Descuento"].Value.ToString();
                        string valorColumna6 = fila.Cells["PctDescuento"].Value.ToString();
                        string valorColumna7 = fila.Cells["Costo"].Value.ToString();
                        string valorColumna8 = fila.Cells["Impuesto"].Value.ToString();
                        string valorColumna9 = fila.Cells["PctImpuesto"].Value.ToString();
                        string valorColumna10 = fila.Cells["ITBIS"].Value.ToString();
                        string valorColumna11 = fila.Cells["Valor"].Value.ToString();
                        decimal valorColumna12 = decimal.Parse(fila.Cells["CantidadFactor"].Value.ToString());
                        string valorColumna13 = fila.Cells["UnidadNO"].Value.ToString();
                        string valorColumna14 = fila.Cells["TipoDescuento"].Value.ToString();
                        decimal cantidadInsertada = decimal.Parse(fila.Cells["Cantidad"].Value.ToString());

                        string consulta = "INSERT INTO ventas_d VALUES (@VentaNo, @Tipo, @TipoVentas, @ArticuloNo, @DescripcionArt, @Cantidad , @CantDevuelta, @CantDevolver,@Precio,@Descuento,@PctDescuento,@Costo,@Impuesto,@PctImpuesto,@ITBIS,@Valor,@CantidadFactor,@UnidadNo,@TipoDescuento)";
                        SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());

                        comando.Parameters.AddWithValue("@VentaNo", txtVendedorNo_M.Text);
                        comando.Parameters.AddWithValue("@Tipo", txtTipo_VentaM.Text);
                        comando.Parameters.AddWithValue("@TipoVentas", txtTipo_VentaM.Text);
                        // Realiza la inserción en la base de datos
                        comando.Parameters.AddWithValue("@ArticuloNo", valorColumna1);
                        comando.Parameters.AddWithValue("@DescripcionArt", valorColumna2);
                        comando.Parameters.AddWithValue("@Cantidad", valorColumna3);
                        comando.Parameters.AddWithValue("@CantDevuelta", txtCant_Devuelta_D.Text);
                        comando.Parameters.AddWithValue("@CantDevolver", txtCant_Devolver_D.Text);
                        comando.Parameters.AddWithValue("@Precio", valorColumna4);
                        comando.Parameters.AddWithValue("@Descuento", valorColumna5);
                        comando.Parameters.AddWithValue("@PctDescuento", valorColumna6);
                        comando.Parameters.AddWithValue("@Costo", valorColumna7);
                        comando.Parameters.AddWithValue("@Impuesto", valorColumna8);
                        comando.Parameters.AddWithValue("@PctImpuesto", valorColumna9);
                        comando.Parameters.AddWithValue("@ITBIS", valorColumna10);
                        comando.Parameters.AddWithValue("@Valor", valorColumna11);
                        comando.Parameters.AddWithValue("@CantidadFactor", valorColumna12);
                        comando.Parameters.AddWithValue("@UnidadNO", valorColumna13);
                        comando.Parameters.AddWithValue("@TipoDescuento", valorColumna14);

                        comando.ExecuteNonQuery();
                        con.cerrarConexion();





                        string consultaActualizar = "UPDATE articulo SET existencia = existencia - @cantidad WHERE ArticuloNo = @ArticuloNo";
                        SqlCommand comand = new SqlCommand(consultaActualizar, con.establecerConexion());
                        string miArticuloID = fila.Cells["ArticuloNo"].Value.ToString();
                        comand.Parameters.AddWithValue("@Cantidad", cantidadInsertada);
                        comand.Parameters.AddWithValue("@ArticuloNo", miArticuloID);
                        comand.ExecuteNonQuery();
                        con.cerrarConexion();



                        int ultimoCodigo = 0;
                        string consultaUltimoCodigo = "SELECT MAX(Codigo) FROM transacxc";

                        string Factura = "Factura";
                        string s = "s";


                        SqlCommand comandcodigo = new SqlCommand(consultaUltimoCodigo, con.establecerConexion());

                        object resultado = comandcodigo.ExecuteScalar();

                        if (resultado != DBNull.Value)
                        {
                            ultimoCodigo = Convert.ToInt32(resultado);
                        }
                        int nuevoCodigo = ultimoCodigo + 1;
                        con.cerrarConexion();
                        MessageBox.Show("Transaccion");


                        string consultaInsertTransaccionCXC = "INSERT INTO transacxc VALUES (@Codigo, @DocumentoNo, @ClienteNo, @tipotrx , @TipoVentas, @trxndoc,@docaplicado,@valor,@fecha,@FechaVence,@saldoacum,@concepto,@estado)";

                        SqlCommand comandInsert = new SqlCommand(consultaInsertTransaccionCXC, con.establecerConexion());
                        comandInsert.Parameters.AddWithValue("@Codigo", nuevoCodigo);
                        comandInsert.Parameters.AddWithValue("@DocumentoNo", nuevoCodigo);
                        comandInsert.Parameters.AddWithValue("@ClienteNo", txtNombre_Cliente_M.Text);
                        comandInsert.Parameters.AddWithValue("@tipotrx", txtTipo_VentaM.Text);
                        comandInsert.Parameters.AddWithValue("@TipoVentas", txtTipo_VentaM.Text);
                        comandInsert.Parameters.AddWithValue("@trxndoc", txtVentaNo_M.Text);
                        comandInsert.Parameters.AddWithValue("@docaplicado", Factura);
                        comandInsert.Parameters.AddWithValue("@valor", txtValorNETO_M.Text);
                        comandInsert.Parameters.AddWithValue("@Fecha", txtFecha_M.Text);
                        comandInsert.Parameters.AddWithValue("@FechaVence", txtFecha_M.Text);
                        comandInsert.Parameters.AddWithValue("@saldoacum", txtValorNETO_M.Text);
                        comandInsert.Parameters.AddWithValue("@concepto", Factura);
                        comandInsert.Parameters.AddWithValue("@estado", s);


                        comandInsert.ExecuteNonQuery();
                        MessageBox.Show("Registro Agredado Transaccion");

                        con.cerrarConexion();


                        string consultaUltimoCod = "SELECT MAX(ReciboNo) FROM recibos_m";

                        
                        string es = "a";


                        SqlCommand comandcod = new SqlCommand(consultaUltimoCodigo, con.establecerConexion());

                        object final = comandcod.ExecuteScalar();

                        if (final != DBNull.Value)
                        {
                            ultimoCodigo = Convert.ToInt32(final);
                        }
                        
                        con.cerrarConexion();


                        string ReciboD = "INSERT INTO recibos_m VALUES (@ReciboNo, @ClienteNo, @Fecha, @Monto , @Descuento, @MontoNeto,@Nota,@Estado)";

                        SqlCommand comanddd = new SqlCommand(ReciboD, con.establecerConexion());
                        comanddd.Parameters.AddWithValue("@ReciboNo", nuevoCodigo);
                        comanddd.Parameters.AddWithValue("@ClienteNo", txtClienteNo_M.Text);
                        comanddd.Parameters.AddWithValue("@Fecha", txtFecha_M.Text);
                        comanddd.Parameters.AddWithValue("@Monto", txtValorBruto_M.Text);
                        comanddd.Parameters.AddWithValue("@Descuento", txtDesc_M.Text);
                        comanddd.Parameters.AddWithValue("@MontoNeto", txtValorNETO_M.Text);
                        comanddd.Parameters.AddWithValue("@Nota", Factura);
                        comanddd.Parameters.AddWithValue("@Estado", es);



                        comanddd.ExecuteNonQuery();

                        con.cerrarConexion();



                        //______________________________Recibo Detalle________________________________________________________________



                        string Recibom = "INSERT INTO recibos_d VALUES (@ReciboNo, @AuxiliarNo, @DocAplicado, @Valor , @Descuento, @RetencionITBIS,@Concepto,@Nosecuencia)";

                        SqlCommand comandInser = new SqlCommand(Recibom, con.establecerConexion());
                        comandInser.Parameters.AddWithValue("@ReciboNo", nuevoCodigo);
                        comandInser.Parameters.AddWithValue("@AuxiliarNo", txtAuxiliar_M.Text);
                        comandInser.Parameters.AddWithValue("@DocAplicado", Factura);
                        comandInser.Parameters.AddWithValue("@Valor", txtValorNETO_M.Text);
                        comandInser.Parameters.AddWithValue("@Descuento", txtDesc_M.Text);
                        comandInser.Parameters.AddWithValue("@RetencionITBIS", txtITBIS_M.Text);
                        comandInser.Parameters.AddWithValue("@Concepto", Factura);
                        comandInser.Parameters.AddWithValue("@Nosecuencia", nuevoCodigo);



                        comandInser.ExecuteNonQuery();

                        con.cerrarConexion();


                    }


                }




                MessageBox.Show("Registro Agredado");

                //limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void limpiar()
        {
            txtVendedorNo_M.Clear();
            txtTipo_VentaM.Clear();
            txtClienteNo_M.Clear();
            txtNombre_Cliente_M.Clear();
            txtCondi_pago_M.Clear();
            txtVendedorNo_M.Clear();
            txtFacturadorNo_M.Clear();
            txtFecha_M.Clear();
            txtValorBruto_M.Clear();
            txtDesc_M.Clear();
            txtImpuestos_M.Clear();
            txtITBIS_M.Clear();
            txtCosto_M.Clear();
            txtValorNETO_M.Clear();
            txtNota_M.Clear();
            txtAuxiliar_M.Clear();
            txtTurno_M.Clear();

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        public void limpiar2()
        {
            txtArticuloNo_D.Clear();
            txtCant_Devuelta_D.Clear();
            txtCant_Devolver_D.Clear();




        }
        private void button1_Click(object sender, EventArgs e)
        {
            limpiar2();


        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal total = 0;
            decimal tot1 = 0;
            decimal BrutoTotal = 0;
            //  decimal descuentoTotal = 0;
            decimal descuentoTot = 0;
            decimal ValorNeto = 0;
            decimal totalcost = 0;
            decimal varcost = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (!fila.IsNewRow)
                {

                    // Verifica si la celda en la columna "Cantidad" no es null y si no está vacía
                    if (fila.Cells["Cantidad"].Value != null && !string.IsNullOrWhiteSpace(fila.Cells["Cantidad"].Value.ToString()))
                    {
                        decimal Costo = decimal.Parse(fila.Cells["Costo"].Value.ToString());
                        decimal precio = decimal.Parse(fila.Cells["Precio"].Value.ToString());
                        decimal itbis = precio * 0.18m;
                        int cant = int.Parse(fila.Cells["Cantidad"].Value.ToString());
                        decimal valor1 = precio * cant;
                        decimal tot = itbis * cant;
                        decimal descuento = precio * 0.05m;
                        decimal descuentoTotal = descuento * cant;
                        varcost = Costo;
                        fila.Cells["Valor"].Value = valor1.ToString();
                        // fila.Cells["ITBIS"].Value = itbis.ToString("N2");
                        fila.Cells["PctImpuesto"].Value = 18;
                        fila.Cells["PctDescuento"].Value = 5;
                        fila.Cells["Impuesto"].Value = itbis.ToString("N2");



                        if (decimal.TryParse(fila.Cells["Valor"].Value.ToString(), out decimal valor))
                        {
                            total += valor;
                            tot1 += tot;
                            BrutoTotal = total + tot1;
                            descuentoTot = descuento;
                            ValorNeto = BrutoTotal - descuentoTotal;
                            totalcost += varcost;

                        }

                    }

                    decimal costoAux = decimal.Parse(totalcost.ToString("N2"));
                    decimal valorBrutoAux = decimal.Parse(BrutoTotal.ToString("N2"));
                    decimal impuestosAux = decimal.Parse(tot1.ToString("N2"));
                    decimal valorNetoAux = decimal.Parse(ValorNeto.ToString("N2"));
                    decimal itbisAux = decimal.Parse(tot1.ToString("N2"));
                    decimal ImpuestoAux = decimal.Parse(tot1.ToString("N2"));

                    txtValorBruto_M.Text = valorBrutoAux.ToString().Replace(",", "");
                    txtImpuestos_M.Text = impuestosAux.ToString().Replace(",", "");
                    txtValorNETO_M.Text = valorBrutoAux.ToString().Replace(",", "");
                    fila.Cells["Descuento"].Value = descuentoTot.ToString("N2");
                    txtITBIS_M.Text = ImpuestoAux.ToString().Replace(",", "");

                }
            }
        }

        private void txtVentaNo_D_DoubleClick(object sender, EventArgs e)
        {
            Consulta_vendedor vendedor = new Consulta_vendedor();
            vendedor.VendedorSeleccionado += VendedorSeleccionado;
            vendedor.ShowDialog();
        }
        private void VendedorSeleccionado(DataRow selectedRow)
        {

            txtVendedorNo_M.Text = selectedRow[0].ToString();
        }

        private void txtFacturadorNo_M_DoubleClick(object sender, EventArgs e)
        {
            Consulta_Facturador facturador = new Consulta_Facturador();
            facturador.FacturadorSeleccionado += FacturadorSeleccionado;
            facturador.ShowDialog();
        }
        private void FacturadorSeleccionado(DataRow selectedRow)
        {

            txtFacturadorNo_M.Text = selectedRow[0].ToString();
        }

        private void txtClienteNo_M_DoubleClick(object sender, EventArgs e)
        {
            Consulta_clientes cliente = new Consulta_clientes();
            cliente.ClienteSeleccionado += ClientesSeleccionado;
            cliente.ShowDialog();
        }
        private void ClientesSeleccionado(DataRow selectedRow)
        {

            txtClienteNo_M.Text = selectedRow[0].ToString();
            txtNombre_Cliente_M.Text = selectedRow[2].ToString();
        }
        private void textClientesNo_TextChanged(object sender, EventArgs e)
        {
            string valor = txtClienteNo_M.Text;
            txtAuxiliar_M.Text = valor;
            if (valor == string.Empty)
            {
                txtNombre_Cliente_M.Clear();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtArticuloNo_D_DoubleClick(object sender, EventArgs e)
        {

            VentasArticulos formArticulo = new VentasArticulos();

            formArticulo.ArticuloSeleccionado += ArticuloForm_ArticuloSeleccionado;
            formArticulo.ShowDialog();
        }
        private void Form2_RowSelected(string valorColumna1, string valorColumna2, string valorColumna3, string valorColumna4)
        {
            txtArticuloNo_D.Text = valorColumna1;

        }

        private void ArticuloForm_ArticuloSeleccionado(object sender, ArticuloSeleccionadoEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                int columna0EnFila = Convert.ToInt32(row.Cells[0].Value);

                if (columna0EnFila == e.Columna7)
                {
                    int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    cantidadActual++;
                    row.Cells["Cantidad"].Value = cantidadActual.ToString();

                    return;
                }
            }


            object[] Row = new object[dataGridView1.Columns.Count];

            Row[0] = e.Columna7;
            Row[1] = e.Columna0;
            Row[3] = e.Columna2;
            Row[6] = e.Columna3;
           // Row[12] = e.Columna4;
         //   Row[9] = e.Columna5;

            dataGridView1.Rows.Add(Row);


        }
    }
}
