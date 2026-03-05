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
    public partial class Marca : Form
    {
        public Marca()
        {
            InitializeComponent();
        }
        public void llenar_tabla()
        {
         /*   database.conexion con = new database.conexion();
            string consulta = "select * from marca";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, con.establecerConexion());
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;*/
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validarCampo();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Marca_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;

        }
        private void validarCampo()
        {
            var vr = !string.IsNullOrEmpty(txtmarca.Text) && !string.IsNullOrEmpty(txtdescrip.Text);

            btnAgregar.Enabled = vr;
            btnModificar.Enabled = vr;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void textdescrip_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

      

       

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void txtdescrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarTxt.soloLetras(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            // para Insertar
            try
            {
                string consulta = "INSERT INTO marca  VALUES ('" + txtmarca.Text + "','" + txtdescrip.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                comando.ExecuteNonQuery();


                MessageBox.Show("Registro Agredado");
                llenar_tabla();
                //limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            database.conexion con = new database.conexion();
            //para ACTUALIZAR
            try
            {
                string consulta = "update marca set Marca=" + txtmarca.Text + ",Descripcion='" + txtdescrip.Text + "'where Marca=" + txtmarca.Text + "";
                SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
                int cant;

                cant = comando.ExecuteNonQuery();
                if (cant > 0)
                {
                    MessageBox.Show("Registro Modificado");

                }
                llenar_tabla();
                //limpiar();
                con.cerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtmarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
