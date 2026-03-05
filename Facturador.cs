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
using System.Windows.Media.TextFormatting;

namespace sistema_de_ventas
{
    public partial class Facturador : Form
    {
        public Facturador()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");

        public void limpiar()
        {
            txtFacturadorNo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
         
        }
        public void llenar_tabla()
        {

            string consulta = "select * from facturador";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // para Insertar
            try
            {
                database.conexion con = new database.conexion();
                string consulta = "INSERT INTO facturador  VALUES ('" + txtFacturadorNo.Text + "', '" + txtNombre.Text + "', '" + txtApellido.Text + "', '" + txtFecha.Text + "', '" + txtEstado.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");
                llenar_tabla();
                limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            // para MODIFICAR
            try
            {
                string consulta = "update facturador set FacturadorNo=" + txtFacturadorNo.Text + ",Nombre='" + txtNombre.Text + "',Apellido='" + txtApellido.Text + "',FechaEntrada='" + txtFecha.Text + "',Estado='" + txtEstado.Text + "'where FacturadorNo=" + txtFacturadorNo.Text + "";

                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void Facturador_Load(object sender, EventArgs e)
        {

            string consulta = "select * from facturador";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
            txtFecha.CustomFormat = "yyyy-MM-dd";
            txtFecha.Format = DateTimePickerFormat.Custom;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtFacturadorNo.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtFecha.Text)  && !string.IsNullOrEmpty(txtEstado.Text);

            btnAgregar.Enabled = vr;
            btnModificar.Enabled = vr;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtFacturadorNo_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
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

        private void txtAnulado_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        ErrorProvider errorProvider = new ErrorProvider();
        private void txtFacturadorNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool valida = validarTxt.soloNumeros(e);
            if (!valida)
            {
                errorProvider.SetError(txtFacturadorNo, "Solo numeros");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);

            if (e.KeyChar==Convert.ToChar(Keys.Enter))
            {
                txtApellido.Focus();   
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFacturadorNo.Text = dataGridView1.SelectedCells[0].Value.ToString();

            txtNombre.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txtApellido.Text = dataGridView1.SelectedCells[2].Value.ToString();
            txtFecha.Text = dataGridView1.SelectedCells[3].Value.ToString();
            txtEstado.Text = dataGridView1.SelectedCells[4].Value.ToString();

        }
    }
    }

