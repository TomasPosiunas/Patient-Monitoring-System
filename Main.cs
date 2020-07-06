using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

       
        

        

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new PatientControl();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newOne = new PatientShow();
            newOne.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newOne = new PatientShow();
            newOne.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Program.f1.Show();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SIDEPANNELBUTTON1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var newTwo = new PacientoPridejimoTestas();
            newTwo.Show();
        }
    }
}
