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
using System.Security.Cryptography.X509Certificates;

namespace Test
{
    public partial class PatientShow : Form
    {
        private object con;

        public PatientShow()
        {
            InitializeComponent();
        }

        SqlConnection con1 = new SqlConnection(@"Data Source=database-1.ckgkuzjzwkj5.eu-central-1.rds.amazonaws.com;Initial Catalog=FirstDB;Persist Security Info=True;User ID=tomas;Password=Lempa123");
        public int Id;


        private void PatientShow_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }

        private void GetStudentsRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=database-1.ckgkuzjzwkj5.eu-central-1.rds.amazonaws.com;Initial Catalog=FirstDB;Persist Security Info=True;User ID=tomas;Password=Lempa123");
            SqlCommand cmd = new SqlCommand("Select * from Testas1", con);
            DataTable dt = new DataTable();


            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            StudentRecordDataGridView.DataSource = dt;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {
                
                SqlCommand cmd = new SqlCommand("INSERT INTO Testas1 VALUES (@Name, @LastName, @Age, @Gender, @Address)", con1);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Age", textBox4.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox5.Text);

                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();

                MessageBox.Show("New Patient Added");

                GetStudentsRecord();
                ResetFormCondrols();

            }

        }

        private bool IsValid()
        {
            if(textBox1.Text == string.Empty)
            {

                MessageBox.Show("Patient Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            ResetFormCondrols();
        }

        private void ResetFormCondrols()
        {
            Id = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();

            textBox1.Focus();
        }

        private void StudentRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(StudentRecordDataGridView.SelectedRows[0].Cells[0].Value);
            textBox1.Text = StudentRecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = StudentRecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = StudentRecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = StudentRecordDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = StudentRecordDataGridView.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Id > 0)
            {

                SqlCommand cmd = new SqlCommand("UPDATE Testas1 SET Name = @Name, LastName = @LastName, Age = @Age, Gender= @Gender,Address = @Address WHERE Id = @Id", con1);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Age", textBox4.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox5.Text);
                cmd.Parameters.AddWithValue("@Id", this.Id);

                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();

                MessageBox.Show("Patient information updated successfully");

                GetStudentsRecord();
                ResetFormCondrols();
            }

            else
            {
                MessageBox.Show("Please select a patient to update", "Select?" , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Id > 0)
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM Testas1 WHERE Id = @Id", con1);
                cmd.CommandType = CommandType.Text;
              

                cmd.Parameters.AddWithValue("@Id", this.Id);

                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();

                MessageBox.Show("Patient information deleted successfully");

                GetStudentsRecord();
                ResetFormCondrols();
            }
            else
            {
                MessageBox.Show("Please select a patient to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
