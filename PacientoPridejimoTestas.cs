using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class PacientoPridejimoTestas : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=database-1.ckgkuzjzwkj5.eu-central-1.rds.amazonaws.com;Initial Catalog=FirstDB;Persist Security Info=True;User ID=tomas;Password=Lempa123");
        public PacientoPridejimoTestas()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into Testas1 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data inserted");
        }

        private void PacientoPridejimoTestas_Load(object sender, EventArgs e)
        {

        }
    }
}
