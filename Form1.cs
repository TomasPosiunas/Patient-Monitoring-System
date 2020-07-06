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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            string query ="Select * From Login Where Username='" + textBox1.Text.Trim() + "' and Password ='" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dt = new DataTable();
            _ = sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Main ss = new Main();
               
                this.Hide();
                
                ss.Show();
            }
            else
            {
                MessageBox.Show("Please Check Your Username and Password");
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

    }
}



