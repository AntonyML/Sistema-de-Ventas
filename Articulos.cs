using sistema_de_ventas.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_de_ventas
{
    public partial class Articulos : Form
    {
        public Articulos()
        {

            InitializeComponent();

        }
        private string selectedValue;
        public void SetTextBox1Value(string value)
        {
            selectedValue = value;
        }

        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");

        public void llenar_tabla() {

            string consulta = "select * from articulo";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

          
        }
        public void limpiar()
        {
            txtArticulo.Clear();
            txtReferencia.Clear();
            txtMarca.Clear();
            txtProveedor.Clear();
            txtLinea.Clear();
            txtUnidad.Clear();
            txtPrecio.Clear();
            txtExistencia.Clear();
            txtCosto.Clear();
            txtItebis.Clear();
            txtUsuario.Clear();
            txtDescrip.Clear();
            txtObservacion.Clear();

        }
        private void Artuculos_Load(object sender, EventArgs e)
        {
            txtFecha.CustomFormat = "yyyy-MM-dd";
            txtFecha.Format = DateTimePickerFormat.Custom;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;

            string consulta = "select * from articulo";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

      

            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtArticulo.Text) && !string.IsNullOrEmpty(txtReferencia.Text) && !string.IsNullOrEmpty(txtMarca.Text) && !string.IsNullOrEmpty(txtProveedor.Text) && !string.IsNullOrEmpty(txtLinea.Text) && !string.IsNullOrEmpty(txtUnidad.Text) && !string.IsNullOrEmpty(txtPrecio.Text) && !string.IsNullOrEmpty(txtFecha.Text) && !string.IsNullOrEmpty(txtCosto.Text) && !string.IsNullOrEmpty(txtItebis.Text) && !string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtExistencia.Text) && !string.IsNullOrEmpty(txtDescrip.Text) && !string.IsNullOrEmpty(txtObservacion.Text);

            btnAgregar.Enabled = vr;
            btnModificar.Enabled = vr;

        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

      

        private void txtArticulo_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        

    
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

   
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          /*  txtArticulo.Text = dataGridView1.SelectedCells[0].Value.ToString();

            txtReferencia.Text = dataGridView1.SelectedCells[1].Value.ToString();

            txtDescrip.Text = dataGridView1.SelectedCells[2].Value.ToString();

            txtMarca.Text = dataGridView1.SelectedCells[3].Value.ToString();

            txtProveedor.Text = dataGridView1.SelectedCells[4].Value.ToString();

            txtLinea.Text = dataGridView1.SelectedCells[5].Value.ToString();

            txtUnidad.Text = dataGridView1.SelectedCells[6].Value.ToString();

            txtPrecio.Text = dataGridView1.SelectedCells[7].Value.ToString();

            txtExistencia.Text = dataGridView1.SelectedCells[8].Value.ToString();

            txtFecha.Text = dataGridView1.SelectedCells[9].Value.ToString();

            txtCosto.Text = dataGridView1.SelectedCells[10].Value.ToString();

            txtItebis.Text = dataGridView1.SelectedCells[11].Value.ToString();

            txtObservacion.Text = dataGridView1.SelectedCells[12].Value.ToString();

            txtUsuario.Text = dataGridView1.SelectedCells[13].Value.ToString();

            MemoryStream ms = new MemoryStream((Byte[])dataGridView1.SelectedCells[14].Value);
            Bitmap bm = new Bitmap(ms);
            pictureBox2.Image = bm;*/

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void btnModificar_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, ImageFormat.Png);
            Byte[] ConvertirByte = ms.ToArray();
            // para MODIFICAR
            try
            {
                string consulta = "update articulo set ArticuloNo=" + txtArticulo.Text + ",referencia='" + txtReferencia.Text + "',descripcion='" + txtDescrip.Text + "',Marca='" + txtMarca.Text + "',proveedorNo='" + txtProveedor.Text + "',LineaNo='" + txtLinea.Text + "',UnidadNo='" + txtUnidad.Text + "', precio1='" + txtPrecio.Text + "',existencia='" + txtExistencia.Text + "',fechaentrada='" + txtFecha.Text + "',costo='" + txtCosto.Text + "',itbis='" + txtItebis.Text + "',observaciones='" + txtObservacion.Text + "', usuario='" + txtUsuario.Text + "' ,imagen = @imagen  where ArticuloNo='" + txtArticulo.Text + "'";




                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());

                comando.Parameters.AddWithValue("@imagen", ConvertirByte);
                int cant;

                cant = comando.ExecuteNonQuery();
                if (cant > 0)
                {
                    MessageBox.Show("Registro Modificado");

                }

                llenar_tabla();
                limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            database.conexion con = new database.conexion();
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, ImageFormat.Png);
            Byte[] ConvertirByte = ms.ToArray();
            // para Insertar
            try
            {
                string consulta = "INSERT INTO articulo  VALUES ('" + txtArticulo.Text + "', '" + txtReferencia.Text + "', '" + txtDescrip.Text + "', '" + txtMarca.Text + "', '" + txtProveedor.Text + "', '" + txtLinea.Text + "', '" + txtUnidad.Text + "', '" + txtPrecio.Text + "',' " + txtExistencia.Text + "', '" + txtFecha.Text + "', '" + txtCosto.Text + "', '" + txtItebis.Text + "', '" + txtObservacion.Text + "', '" + txtUsuario.Text + "',@imagen)";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                comando.Parameters.AddWithValue("imagen", ConvertirByte);
                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");
                llenar_tabla();
                limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        { 
                this.Close();
                menu m = new menu();
                m.Visible = true;
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtArticulo_TextChanged_2(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtDescrip_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtLinea_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtUnidad_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtExistencia_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtExistenciaMin_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtExistenciaOP_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtExistenciaMax_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtVenMin_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtComMin_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtFecha_ValueChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtItebis_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtObservacion_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtMod_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtPCitebis_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMarca_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txtMarca_DoubleClick(object sender, EventArgs e)
        {
           DTmarca form2 = new DTmarca(this);
            form2.ShowDialog();

            // Cuando regresas de Form1, asigna el valor seleccionado al TextBox
            txtMarca.Text = selectedValue;
        }

        private void txtProveedor_DoubleClick(object sender, EventArgs e)
        {
            DTproveedor form2 = new DTproveedor(this);
            form2.ShowDialog();

            // Cuando regresas de Form1, asigna el valor seleccionado al TextBox
            txtProveedor.Text = selectedValue;
        }

        private void txtLinea_DoubleClick(object sender, EventArgs e)
        {
            DTlinea form2 = new DTlinea(this);
            form2.ShowDialog();
            txtLinea.Text = selectedValue;
        }

        private void txtUnidad_DoubleClick(object sender, EventArgs e)
        {
            DTunidad form2 = new DTunidad(this);
            form2.ShowDialog();
            txtUnidad.Text = selectedValue;
        }
        ErrorProvider errorProvider = new ErrorProvider();

        public object ConvertirByte { get; private set; }

        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida) { 
                errorProvider.SetError(txtArticulo, "Solo numeros");
            } else
            {
                errorProvider.Clear();
            }
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtProveedor, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtLinea, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtUnidad, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtPrecio, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtCosto, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtItebis_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtItebis, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtPCitebis_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtDescrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtArticulo_DoubleClick(object sender, EventArgs e)
        {
            DT_Articulos art = new DT_Articulos();
            art.dt_Articulos += ArticuloSeleccionado;
            art.ShowDialog();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = " Archivo de imagen (*jpg; *png;) |*jpg; *png; ";
            if (file.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.ImageLocation = file.FileName;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void ArticuloSeleccionado(DataRow selectedRow)
        {

            txtArticulo.Text = selectedRow[0].ToString();
            txtReferencia.Text = selectedRow[1].ToString();
            txtDescrip.Text = selectedRow[2].ToString();
            txtMarca.Text = selectedRow[3].ToString();
            txtProveedor.Text = selectedRow[4].ToString();
            txtLinea.Text = selectedRow[5].ToString();
            txtUnidad.Text = selectedRow[6].ToString();
            txtPrecio.Text = selectedRow[7].ToString();
            txtExistencia.Text = selectedRow[8].ToString();
            txtFecha.Text = selectedRow[9].ToString();
            txtCosto.Text = selectedRow[10].ToString();
            txtItebis.Text = selectedRow[11].ToString();
            txtObservacion.Text = selectedRow[12].ToString();
            txtUsuario.Text = selectedRow[13].ToString();
            MemoryStream ms = new MemoryStream((Byte[])selectedRow[14]);
            Bitmap bm = new Bitmap(ms);
            pictureBox2.Image = bm;


        }
        }
    }

