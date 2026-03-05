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
    public partial class Consulta_Facturador : Form
    {
        public Consulta_Facturador()
        {
            InitializeComponent();
        }

        public event Action<DataRow> FacturadorSeleccionado;
        SqlConnection conexion = new SqlConnection("server=ROBINSON\\ROBINSON;database=servicio_de_ventas;integrated security=true");
        private void Consulta_Facturador_Load(object sender, EventArgs e)
        {
            string consulta = "select * from facturador";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu m = new menu();
            m.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "SELECT * FROM facturador WHERE FacturadorNo = '" + txtFiltro.Text + "'";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;

            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string consulta = "select * from facturador";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataRow selectedRow = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
                FacturadorSeleccionado.Invoke(selectedRow);
                this.Close();
            }
        }
    }
}
