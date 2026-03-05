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
    public partial class Consulta_Ajuste_M : Form
    {
        public Consulta_Ajuste_M()
        {
            InitializeComponent();
        }

        private void Consulta_Ajuste_M_Load(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            string consulta = "Select * from ajuste_m";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, con.establecerConexion());

            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            string consulta = "select * from ajuste_m";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, con.establecerConexion());
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            database.conexion con = new database.conexion();
            string consulta = "SELECT * FROM ajuste_m WHERE InventarioNo= '" + txtFiltro.Text + "'";
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
