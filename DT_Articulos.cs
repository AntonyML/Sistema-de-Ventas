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
    public partial class DT_Articulos : Form
    {
        public event Action<DataRow> dt_Articulos;
        public DT_Articulos()
        {
            InitializeComponent();
        }

        private void DT_Articulos_Load(object sender, EventArgs e)
        {

            database.conexion con = new database.conexion();
            string consulta = "select * from articulo";
            SqlDataAdapter adapt = new SqlDataAdapter(consulta, con.establecerConexion());
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
            con.cerrarConexion();

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >0)
            {
                DataRow selectedRow = (dataGridView1.SelectedRows[0].DataBoundItem as DataRowView).Row;
                dt_Articulos.Invoke(selectedRow);
                this.Close();
            }
        }
    }
}
