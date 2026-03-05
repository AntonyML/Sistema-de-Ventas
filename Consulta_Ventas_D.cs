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
    public partial class Consulta_Ventas_D : Form
    {
        public Consulta_Ventas_D()
        {
            InitializeComponent();
        }

        private void Consulta_Ventas_D_Load(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            string consulta = "Select * from ventas_d";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, con.establecerConexion());

            //Crear Tabla en memoria o Virtual

            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            string consulta = "select * from ventas_d";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, con.establecerConexion());
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            string consulta = "SELECT * FROM ventas_d WHERE VentaNo = '" + txtFiltro.Text + "'";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, con.establecerConexion());
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            con.cerrarConexion();

            dataGridView1.DataSource = dt;

            SqlCommand comando = new SqlCommand(consulta, con.establecerConexion());
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            con.cerrarConexion();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }
    }
}
