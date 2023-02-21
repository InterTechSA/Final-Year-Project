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
using System.IO;

namespace ManagementSystem
{
    public partial class StepTwo : Form
    {
        public StepTwo()
        {
            InitializeComponent();
        }


        private void StepTwo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'groupWst24DataSet6.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.groupWst24DataSet6.Students);
            button2.Enabled = false;
        }
        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
               


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFile(int.Parse(textBox1.Text));


        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        

        private void OpenFile(int id)
        {
            using (SqlConnection cnn = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b"))
            {


                string query = "Select AcademicRecord from Students where StudentNumber='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cnn.Open();
                var reader = cmd.ExecuteReader();
                var ext = ".pdf";
                if (reader.Read()) {
                    var data = (byte[])reader["AcademicRecord"];
                    var newFileName = "File"+ext;
                    File.WriteAllBytes(newFileName, data);
                    System.Diagnostics.Process.Start(newFileName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");


            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                SqlCommand cm = new SqlCommand("delete Students where StudentNumber='"+textBox1.Text+"'", con);
                con.Open();           
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
               
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
        //private void checkText()
        //{
        //    if (!string.IsNullOrEmpty(textBox1.Text)) {  } else {  }
        //}

        private void button2_MouseHover(object sender, EventArgs e)
        {
          //  checkText();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerDash Ad = new ManagerDash();
            this.Hide();
            Ad.Show();
        }
    }
}
    
        
    
