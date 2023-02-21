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
using System.Net.Mail;

namespace ManagementSystem
{
    public partial class RegisterSponsor : Form
    {
        public RegisterSponsor()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");
        int checker=0;
        private void button1_Click(object sender, EventArgs e)
        {
            ManagerDash md = new ManagerDash();
            this.Hide();
            md.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand command1 = new SqlCommand("insert into Sponsor values('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + textBox8.Text + "','" + int.Parse(textBox10.Text) + "','" + int.Parse(textBox5.Text)+ "','" + int.Parse(textBox7.Text) + "')", connect);
                command1.ExecuteNonQuery();
                MessageBox.Show("Successfully Registered");
                connect.Close();
                Bind_Data();
            }
            catch (Exception)
            {
                MessageBox.Show("Company already registerd on the system!!!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);

            }
        }
        void Bind_Data()
        {


            SqlCommand command1 = new SqlCommand("select * from Sponsor", connect);


            SqlDataAdapter sd1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            sd1.Fill(dt1);
            dataGridView1.DataSource = dt1;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            // {
            //if (connect.State == ConnectionState.Closed)
            //{


            connect.Open();
            SqlCommand command = new SqlCommand("update Sponsor set CompanyName = '" + textBox2.Text + "',Email='" + textBox6.Text + "',Phone='" + textBox4.Text + "',Country='" + comboBox1.Text + "',Province='" + comboBox2.Text + "',Street='" + textBox3.Text + "',Town='" + textBox8.Text + "',ZipCode='" + int.Parse(textBox10.Text)+ "',AverageMarkRequired='" + int.Parse(textBox5.Text)+ "',AvailableBursaries='" + int.Parse(textBox7.Text) + "'" + "where CompanyId=" + "'" + int.Parse(textBox1.Text) + "'", connect);
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Successfully Updated");
            Bind_Data();


            //}else
            //{
            //    connect.Close();
            //}

            //  }
            //  catch (Exception)
            // {
            //     MessageBox.Show("You Made No Changes!!!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);

            // }
        }
        public void searchData(string valueToFind)
        {
            string searchQuery = "SELECT * FROM Sponsor WHERE CONCAT(CompanyName,CompanyId) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(searchQuery, connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void RegisterSponsor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sponsorDataSet.Sponsor' table. You can move, or remove it, as needed.
            this.sponsorTableAdapter.Fill(this.sponsorDataSet.Sponsor);
            // this.finalSponsorTableAdapter.Fill(this.groupWst24DataSet9.FinalSponsor);
            Bind_Data();
        }

       

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Required");
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
                errorProvider2.SetError(textBox2, "Required");
            }
            else
            {
                IsValid(textBox2.Text);
                e.Cancel = false;
                errorProvider2.SetError(textBox2, null);
            }
        }
    

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider5.SetError(textBox4, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(textBox4, null);
            }
        }

       

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider7.SetError(textBox5, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider7.SetError(textBox5, null);
            }
        }

       
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
           
        }

       
 
       

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("Delete FinalSponsor where CompanyId= '" + textBox1.Text + "'", connect);
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Successfully Deleted");
                Bind_Data();

            }
            else
            {
                MessageBox.Show("Put ID");
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (textBox4.Text.Length > 9)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider3.SetError(textBox6, "*");
            }
            else if (!this.textBox6.Text.Contains('@') || !this.textBox6.Text.Contains('.'))
            {
                textBox6.Focus();
                errorProvider3.SetError(textBox6, "*");
            }

            else
            {
                IsValid(textBox6.Text);
                e.Cancel = false;
                errorProvider3.SetError(textBox6, null);
            }
        }

        private void textBox4_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider4.SetError(textBox4, "*");
            }
            else if (textBox4.Text[0].ToString() != "0")
            {
                textBox6.Focus();
                errorProvider4.SetError(textBox4, "*");
            }
            else
            {
                IsValid(textBox4.Text);
                e.Cancel = false;
                errorProvider4.SetError(textBox4, null);
            }
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                e.Cancel = true;
                comboBox1.Focus();
                errorProvider5.SetError(comboBox1, "*");
            }
            else
            {
                IsValid(comboBox1.Text);
                e.Cancel = false;
                errorProvider5.SetError(comboBox1, null);
            }
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                e.Cancel = true;
                comboBox2.Focus();
                errorProvider6.SetError(comboBox2, "*");
            }
            else
            {
                IsValid(comboBox2.Text);
                e.Cancel = false;
                errorProvider6.SetError(comboBox2, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider7.SetError(textBox3, "*");
            }
            else
            {
                IsValid(textBox3.Text);
                e.Cancel = false;
                errorProvider7.SetError(textBox3, null);
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox8.Text))
            {
                e.Cancel = true;
                textBox8.Focus();
                errorProvider8.SetError(textBox8, "*");
            }
            else
            {
                IsValid(textBox8.Text);
                e.Cancel = false;
                errorProvider8.SetError(textBox8, null);
            }
        }

        private void textBox10_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox10.Text))
            {
                e.Cancel = true;
                textBox10.Focus();
                errorProvider9.SetError(textBox10, "*");
            }
            else
            {
                IsValid(textBox10.Text);
                e.Cancel = false;
                errorProvider9.SetError(textBox10, null);
            }
        }

        private void textBox5_Validating_1(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider10.SetError(textBox5, "*");
            }
            else
            {
                IsValid(textBox5.Text);
                e.Cancel = false;
                errorProvider10.SetError(textBox5, null);
            }
        }

        private void textBox7_Validating_1(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox7.Text))
            {
                e.Cancel = true;
                textBox7.Focus();
                errorProvider11.SetError(textBox7, "*");
            }
            else
            {
                IsValid(textBox7.Text);
                e.Cancel = false;
                errorProvider11.SetError(textBox7, null);
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length < 6) && (textBox1.Text.Length > 0))
            {
                MessageBox.Show("Company Id must be 6 digits!");
                textBox1.Focus();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox8_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
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

                    if (textBox4.Text.Length > 9)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if ((textBox4.Text.Length < 10) && (textBox4.Text.Length > 0))
            {
                MessageBox.Show("Phone number must be 10 digits!");
                textBox4.Focus();
            }

        }

        private void textBox10_KeyPress_1(object sender, KeyPressEventArgs e)
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

                    if (textBox10.Text.Length > 3)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if ((textBox10.Text.Length < 4) && (textBox4.Text.Length > 0))
            {
                MessageBox.Show("Zip code must be 4 digits!");
                textBox10.Focus();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
           
        }

        private void textBox5_KeyPress_1(object sender, KeyPressEventArgs e)
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

                    if (textBox5.Text.Length > 1)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

                    if (textBox5.Text.Length > 15)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox9.Text);
        }

        private void dataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox6.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                comboBox1.Text = row.Cells[4].Value.ToString();
                comboBox2.Text = row.Cells[5].Value.ToString();
                textBox3.Text = row.Cells[6].Value.ToString();
                textBox8.Text = row.Cells[7].Value.ToString();
                textBox10.Text = row.Cells[8].Value.ToString();
                textBox5.Text = row.Cells[9].Value.ToString();
                textBox7.Text = row.Cells[10].Value.ToString();

            }
        }
    }
    }
   
    
    
