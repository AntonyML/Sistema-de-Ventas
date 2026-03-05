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
    public partial class Linea : Form
    {
        public Linea()
        {
            InitializeComponent();
        }
        public void llenar_tabla()
        {

            string consulta = "select * from linea";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }
        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");
        private void Linea_Load(object sender, EventArgs e)
        {

            string consulta = "select * from linea";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;

            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
        }
        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtLinea.Text) && !string.IsNullOrEmpty(txtDescp.Text);

            btnAgregar.Enabled = vr;
            btnModificar.Enabled = vr;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            database.conexion con = new database.conexion();

            //para Insertar
            try
            {
                string consulta = "INSERT INTO linea  VALUES ('" + txtLinea.Text + "','" + txtDescp.Text +"')";
                if (string.IsNullOrWhiteSpace(txtLinea.Text))
                {
                    MessageBox.Show("Uno o varios campos estan vacios");

                }
                else
                {
                    MessageBox.Show("Registro Agredado");
                }
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                comando.ExecuteNonQuery();

               

               
                llenar_tabla();
                //limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //para ACTUALIZAR
            try
            {
                database.conexion con = new database.conexion();
                string consulta = "update linea set LineaNo=" + txtLinea.Text + ",descripcion='" + txtDescp.Text + "'where LineaNo=" + txtLinea.Text + "";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                int cant;

                cant = comando.ExecuteNonQuery();
                if (cant > 0)
                {
                    MessageBox.Show("Registro Modificado");

                }
                llenar_tabla();
                // limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Show();
        }

        private void txtLinea_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void txtDescp_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }
        ErrorProvider errorProvider = new ErrorProvider();
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

        private void txtDescp_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLinea.Text = dataGridView1.SelectedCells[0].Value.ToString();

            txtDescp.Text = dataGridView1.SelectedCells[1].Value.ToString();
        }
    }
}
