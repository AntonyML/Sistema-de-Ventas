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
using static Bunifu.UI.WinForms.BunifuSnackbar;

namespace sistema_de_ventas
{
    public partial class Ajuste : Form
    {

        public DataGridView dataGridViewAjuste;
       

        public event Action<string> RegistroAgregado;

      
        public Ajuste()
        {
            InitializeComponent();

            btnEliminar.Click += btnEliminar_Click;

        }
        public void limpiar()
        {
            txtInventario_M.Clear();
            txtCosto_M.Clear();
            txtValor_M.Clear();
           


        }
        private void Ajuste_Load(object sender, EventArgs e)
        {
            txtFecha.CustomFormat = "yyyy-MM-dd";
            txtFecha.Format = DateTimePickerFormat.Custom;

            // Suscribe el manejador de eventos
            Consulta_Articulos articuloForm = new Consulta_Articulos();
            articuloForm.ArticuloSeleccionado += ArticuloForm_ArticuloSeleccionado;





            if (dataGridView2.Columns.Count == 0)
            {
                
                DataGridViewRow selectedRow = dataGridView2.CurrentRow;

               
                dataGridView2.Columns.Add("ArticuloNo", "ArticuloNo");
                dataGridView2.Columns.Add("descripcion", "descripcion");
                dataGridView2.Columns.Add("Marca", "Marca");
                dataGridView2.Columns.Add("Costo", "Costo");
                dataGridView2.Columns.Add("Cantidad", "Cantidad");
                dataGridView2.Columns.Add("valor", "valor");

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // para Insertar
            try
            {
                database.conexion con = new database.conexion();
                string consulta = "INSERT INTO ajuste_m VALUES (@InventarioNo, @Fecha, @TipoInventario, @Costo, @Valor ,@estado)";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());

                comando.Parameters.AddWithValue("@InventarioNo", txtInventario_M.Text);
                comando.Parameters.AddWithValue("@Fecha", txtFecha.Text);
                comando.Parameters.AddWithValue("@TipoInventario", txtTipo.Text);
                comando.Parameters.AddWithValue("@Costo", txtCosto_M.Text);
                comando.Parameters.AddWithValue("@Valor", txtValor_M.Text);
                comando.Parameters.AddWithValue("@estado", txtEstado.Text);




                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");

                //limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            // para Insertar
            try
            {
                database.conexion con = new database.conexion();


                foreach (DataGridViewRow fila in dataGridView2.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        string nuevoValorColumna2 = fila.Cells["ArticuloNo"].Value.ToString();
                        string valorColumna1 = fila.Cells["ArticuloNo"].Value.ToString();
                        string valorColumna2 = fila.Cells["Descripcion"].Value.ToString();
                        string valorColumna3 = fila.Cells["Marca"].Value.ToString();
                        string valorColumna4 = fila.Cells["Costo"].Value.ToString();
                        string valorColumna5 = fila.Cells["Cantidad"].Value.ToString();
                        string valorColumna6 = fila.Cells["Valor"].Value.ToString();
                        decimal cantidadInsertada = decimal.Parse(fila.Cells["Cantidad"].Value.ToString());

                        string consulta = "INSERT INTO ajuste_d VALUES (@InventarioNo, @ArticuloNo, @Cantidad,@Descripcion, @Marca, @Costo, @valor)";
                        SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());

                        comando.Parameters.AddWithValue("@InventarioNo", txtInventario_M.Text);
                        // Realiza la inserción en la base de datos
                        comando.Parameters.AddWithValue("@ArticuloNo", valorColumna1);
                        comando.Parameters.AddWithValue("@Descripcion", valorColumna2);
                        comando.Parameters.AddWithValue("@Marca", valorColumna3);
                        comando.Parameters.AddWithValue("@Costo", valorColumna4);
                        comando.Parameters.AddWithValue("@Cantidad", valorColumna5);
                        comando.Parameters.AddWithValue("@Valor", valorColumna6);


                        // Si el artículo ya está en el DataGridView, aumenta su cantidad
                        int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                        cantidadActual++;
                        fila.Cells["Cantidad"].Value = cantidadActual.ToString();


                        comando.ExecuteNonQuery();
                        con.cerrarConexion();
                        String var = txtTipo.Text;

                        if (var == "S")
                        {
                            string consultaActualizar = "UPDATE articulo SET existencia = existencia - @cantidad WHERE ArticuloNo = @ArticuloNo";
                            SqlCommand comand = new SqlCommand(consultaActualizar, con.establecerConexion());
                            string miArticuloID = fila.Cells["ArticuloNo"].Value.ToString();
                          
                            comand.Parameters.AddWithValue("@Cantidad", cantidadInsertada);
                            comand.Parameters.AddWithValue("@ArticuloNo", miArticuloID); 

                            comand.ExecuteNonQuery();
                            con.cerrarConexion();
                        }
                        else if (var == "E")
                        {
                            string consultaActualizar = "UPDATE articulo SET existencia = existencia + @cantidad WHERE ArticuloNo = @ArticuloNo";
                            SqlCommand comand = new SqlCommand(consultaActualizar, con.establecerConexion());
                            string miArticuloID = fila.Cells["ArticuloNo"].Value.ToString();
                           
                            comand.Parameters.AddWithValue("@Cantidad", cantidadInsertada);
                            comand.Parameters.AddWithValue("@ArticuloNo", miArticuloID); 

                            comand.ExecuteNonQuery();
                            con.cerrarConexion();
                        }

                    }


                }




                MessageBox.Show("Registro Agredado");

                //limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (!fila.IsNewRow)
                {
                    decimal Costo = decimal.Parse(fila.Cells["Costo"].Value.ToString());
                    int cant = int.Parse(fila.Cells["Cantidad"].Value.ToString());
                    decimal valor1 = Costo * cant;
                    fila.Cells["Valor"].Value = valor1.ToString();
                }
                if (fila.Cells["Valor"].Value != null)
                {
                    // Verifica si la celda contiene un valor numérico válido
                    if (decimal.TryParse(fila.Cells["Valor"].Value.ToString(), out decimal valor))
                    {
                        // Suma el valor de la celda al total
                        total += valor;
                    }
                }
            }
            txtValor_M.Text = total.ToString();
            txtCosto_M.Text = total.ToString();
        }
        int cantidad = 0;
        private void txtArticuloNo_DoubleClick(object sender, EventArgs e)
        {
          
            Consulta_Articulos articuloForm = new Consulta_Articulos();
            articuloForm.ArticuloSeleccionado += ArticuloForm_ArticuloSeleccionado;
            articuloForm.ShowDialog();
        }
        private void ArticuloForm_ArticuloSeleccionado(object sender, ArticuloSeleccionadoEventArgs e)
        {


          
            foreach (DataGridViewRow row in dataGridView2.Rows)
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

            dataGridView2.Rows.Add(e.Columna7, e.Columna0, e.Columna2, e.Columna3);

        }
        private bool ArticuloYaAgregado(int columna7)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                // Compara el valor de la columna 0 en cada fila del DataGridView con el valor deseado
                int valorEnFila = Convert.ToInt32(row.Cells[0].Value);
                if (valorEnFila == columna7)
                {
                    // El artículo ya está en el DataGridView
                    return true;
                }
            }
            // El artículo no se encontró en el DataGridView
            return false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        ErrorProvider errorProvider = new ErrorProvider();

        private void txtInventario_M_KeyPress(object sender, KeyPressEventArgs e)
        {

            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtArticuloNo, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }

        }

        private void txtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtArticuloNo, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtArticuloNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtArticuloNo, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtCosto_M_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtArticuloNo, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado una fila
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                    // Eliminar la fila del DataGridView
                    dataGridView2.Rows.Remove(selectedRow);
                }
               
                
            }catch (Exception ex) { MessageBox.Show("Selecciona una fila para eliminar."); }
            decimal total = 0;
            foreach (DataGridViewRow fila in dataGridView2.Rows)
            {
                if (!fila.IsNewRow)
                {
                    decimal Costo = decimal.Parse(fila.Cells["Costo"].Value.ToString());
                    int cant = int.Parse(fila.Cells["Cantidad"].Value.ToString());
                    decimal valor1 = Costo * cant;
                    fila.Cells["Valor"].Value = valor1.ToString();
                }
                if (fila.Cells["Valor"].Value != null)
                {
                    // Verifica si la celda contiene un valor numérico válido
                    if (decimal.TryParse(fila.Cells["Valor"].Value.ToString(), out decimal valor))
                    {
                        // Suma el valor de la celda al total
                        total += valor;
                    }
                }
            }
            txtValor_M.Text = total.ToString();
            txtCosto_M.Text = total.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
    }
       
