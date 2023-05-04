using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//importar la libreria de ADO
using System.Data.OleDb;



namespace PryAccesoDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //declaracion de variables globales para este formulario
        OleDbConnection conn = null;
        OleDbCommand cmd = null;
        OleDbDataReader dr = null;


        private void btnConectar_Click(object sender, EventArgs e)
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DB.accdb;");
            conn.Open();
            MessageBox.Show("Conexion a base de datos establecida");
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.TableDirect;
            cmd.CommandText = "TITULO";

            //MessageBox.Show("Conexion a " + cmd.CommandText);

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvDatos.Rows.Add(dr[0]);
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
