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

namespace ManagementSystem
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");
        SqlCommand cmd;



        private void button1_Click(object sender, EventArgs e)
        {
            ManagerDash md = new ManagerDash();
            this.Hide();
            md.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                SqlCommand command1 = new SqlCommand("insert into NewStaff values('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
                command1.ExecuteNonQuery();
                MessageBox.Show("Successfully Inserted");
                con.Close();
                Bind_Data();
            }
            catch (Exception)
            {
                MessageBox.Show("Please user another StaffID!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);

           }
        }
        void Bind_Data()
        {


            SqlCommand command1 = new SqlCommand("select * from NewStaff", con);


            SqlDataAdapter sd1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            sd1.Fill(dt1);
            dataGridView1.DataSource = dt1;

           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                SqlCommand command = new SqlCommand("update NewStaff set FirstName = '" + textBox2.Text + "',LastName='" + textBox3.Text + "',Id='" + textBox4.Text + "',Email='" + textBox5.Text + "',Phone='" + textBox6.Text + "',Address='" + "where StaffId=" + "'" + int.Parse(textBox1.Text) + "'", con);
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Updated");
                Bind_Data();
            }else
            {
                con.Close();
            }
        }
        public void searchData(string valueToFind)
        {
            string searchQuery = "SELECT * FROM NewStaff WHERE CONCAT(StaffId, FirstName, LastName) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(searchQuery, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void Staff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'groupWst24DataSet8.NewStaff' table. You can move, or remove it, as needed.
            this.newStaffTableAdapter.Fill(this.groupWst24DataSet8.NewStaff);
            //       this.newStaffTableAdapter.Fill(this.groupWst24DataSet11.NewStaff);

            searchData("");

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox7.Text);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
         



           }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)(Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                // is a digit or backspace - ignore digits if length is alreay 10 - allow backspace
                if (Char.IsDigit(e.KeyChar))
                {
                    if (textBox6.Text.Length > 9)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if ((textBox6.Text.Length < 10) && (textBox6.Text.Length > 0))
            {
                MessageBox.Show("Phone number must be 10 digits!");
                textBox6.Focus();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if ((textBox4.Text.Length < 13) && (textBox4.Text.Length > 0))
            {
                MessageBox.Show("ID number must be 13 digits!");
                textBox4.Focus();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)(Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                // is a digit or backspace - ignore digits if length is alreay 10 - allow backspace
                if (Char.IsDigit(e.KeyChar))
                {
                    if (textBox4.Text.Length > 12)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textBox2, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider3.SetError(textBox3, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(textBox3, null);
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider4.SetError(textBox4, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(textBox4, null);
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider5.SetError(textBox5, "*");
            }
            else if (!this.textBox5.Text.Contains('@') || !this.textBox5.Text.Contains('.'))
            {
                textBox5.Focus();
                errorProvider5.SetError(textBox5, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(textBox5, null);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider6.SetError(textBox6, "*");
            }
            else if (textBox6.Text[0].ToString() != "0")
            {
                textBox6.Focus();
                errorProvider6.SetError(textBox6, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider6.SetError(textBox6, null);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)(Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                // is a digit or backspace - ignore digits if length is alreay 10 - allow backspace
                if (Char.IsDigit(e.KeyChar))
                {

                    if (textBox1.Text.Length > 5)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }

        //private void richTextBox1_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(richTextBox1.Text))
        //    {
        //        e.Cancel = true;
        //        richTextBox1.Focus();
        //        errorProvider7.SetError(richTextBox1, "*");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider7.SetError(richTextBox1, null);
        //    }
        // }
    }

        
  }
    

