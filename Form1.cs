using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace ACt2_Basedatos
{
    public partial class Form1 : Form
    {
        OracleConnection conn = new OracleConnection("Data source = xe; user id = System; password=123");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnconectar_Click(object sender, EventArgs e)
        {
            
            try
            {
                conn.Open();
                MessageBox.Show("Conexion abierta");
                conn.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show("Ha oucrrido un error"+E);

            }
        }

        private void btnisertar_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand comano = new OracleCommand("addmaterial",conn);
            comano.CommandType = System.Data.CommandType.StoredProcedure;
            comano.Parameters.Add("pidmaterial", OracleType.VarChar).Value = txtidmaterial.Text;
            comano.Parameters.Add("pdescripcion", OracleType.VarChar).Value = txtdescripcion.Text;
            comano.Parameters.Add("pprecio", OracleType.VarChar).Value = txtprecio.Text;
            comano.ExecuteNonQuery();
            MessageBox.Show("Insercion completada");
            conn.Close();


        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand ora = new OracleCommand("Select * from materiales",conn);
            OracleDataAdapter adap = new OracleDataAdapter();
            adap.SelectCommand = ora;
            DataTable tabla = new DataTable();
            adap.Fill(tabla);
            dataGridView1.DataSource = tabla;
            conn.Close();
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand("actualizarm", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("pidmaterial", OracleType.VarChar).Value = txtidmaterial.Text;
            cmd.Parameters.Add("pdescripcion", OracleType.VarChar).Value = txtdescripcion.Text;
            cmd.Parameters.Add("pprecio", OracleType.VarChar).Value = txtprecio.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Actualizacion completada");
            conn.Close();

        }
    }
    }

