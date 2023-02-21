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
    public partial class RegisterStudent : Form
    {
        public RegisterStudent()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");
        SqlCommand cmd;
        private string filename;

        private void button1_Click(object sender, EventArgs e)
        {
            AdDash ad = new AdDash();
            this.Hide();
            ad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UploadFile(filename);
            MessageBox.Show("Successfully Updated");


        }



        void Bind_Data()
        {


            SqlCommand command1 = new SqlCommand("select * from Students", con);
            SqlDataAdapter sd1 = new SqlDataAdapter(command1);
            DataTable dt1 = new DataTable();
            sd1.Fill(dt1);
           
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
           



        }

        private void RegisterStudent_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

        }

        private void cv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dig = new OpenFileDialog() { Filter = "PDF Documents(*pdf)|*.pdf", ValidateNames = true })
            {
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to view  this PDF file?", "VIEW PDF  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        axAcroPDF1.src = dig.FileName;
                        filename = dig.FileName;
                       
                    }
                }
            }
        }
        public void UploadFile(string file)
        {
            try
            {

                con.Open();
                FileStream fstream = File.OpenRead(file);
                byte[] contents = new byte[fstream.Length];
                fstream.Read(contents, 0, (int)fstream.Length);
                fstream.Close();

                using (cmd = new SqlCommand("insert into Students(StudentNumber,Firstname,Lastname,Id,Country,Province,Street,Town,ZipCode,Phone,Email,AverageMark,LevelOfStudy,Institution,Degree,AcademicRecord) values (@StudentNumber,@Firstname,@Lastname,@Id,@Country,@Province,@Street,@Town,@ZipCode,@Phone,@Email,@AverageMark,@LevelOfStudy,@Institution,@Degree,@AcademicRecord)", con))
                {
                    cmd.Parameters.AddWithValue("@StudentNumber", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Firstname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Lastname", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Id", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Country", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@Province", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@Street", textBox11.Text);
                    cmd.Parameters.AddWithValue("@Town", textBox8.Text);
                    cmd.Parameters.AddWithValue("@ZipCode", int.Parse(textBox10.Text));
                    cmd.Parameters.AddWithValue("@Phone", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox7.Text);
                    cmd.Parameters.AddWithValue("@AverageMark", int.Parse(textBox9.Text));
                    cmd.Parameters.AddWithValue("@LevelOfStudy", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Institution", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Degree", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@AcademicRecord", contents);
                    cmd.ExecuteNonQuery();
                    
                    Bind_Data();
                }

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("Please ensure you upload all your documents.");
            }
            catch (SqlException sqlex)
            {
                if(sqlex.Message.StartsWith("Violation of PRIMARY KEY constraint"))
                MessageBox.Show("Person All ready in database."); 
            }
            finally
            {
                con.Close();
            }



        }
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

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
                errorProvider1.SetError(textBox1,null);
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
                errorProvider3.SetError(textBox3, "Required");
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
                errorProvider4.SetError(textBox4, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(textBox4, null);
            }
        }

       

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider5.SetError(textBox6, "Required");
            }
            else if (textBox6.Text[0].ToString() != "0")
            {
                textBox6.Focus();
                errorProvider5.SetError(textBox6, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(textBox6, null);
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                e.Cancel = true;
                textBox7.Focus();
                errorProvider6.SetError(textBox7, "Required");
            }
            else if (!this.textBox7.Text.Contains('@') || !this.textBox7.Text.Contains('.'))
            {
                textBox7.Focus();
                errorProvider6.SetError(textBox7, "*");
            }
            else
            {
                e.Cancel = false;
                errorProvider6.SetError(textBox7, null);
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                e.Cancel = true;
                textBox9.Focus();
                errorProvider7.SetError(textBox9, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider7.SetError(textBox9, null);
            }
        }

        

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                e.Cancel = true;
                comboBox1.Focus();
                errorProvider10.SetError(comboBox1, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider10.SetError(comboBox1, null);
            }

        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                e.Cancel = true;
                comboBox2.Focus();
                errorProvider8.SetError(comboBox2, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider8.SetError(comboBox2, null);
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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
                   
                        if (textBox9.Text.Length > 1)
                        {
                            e.Handled = true;
                        }
                    
                }
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

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if ((textBox6.Text.Length < 10) && (textBox6.Text.Length > 0))
            {
                MessageBox.Show("Phone number must be 10 digits!");
                textBox6.Focus();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
  
        private void comboBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox4.Text))
            {
                e.Cancel = true;
                comboBox4.Focus();
                errorProvider11.SetError(comboBox4, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider11.SetError(comboBox4, null);
            }
        }

        private void comboBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox3.Text))
            {
                e.Cancel = true;
                comboBox3.Focus();
                errorProvider12.SetError(comboBox3, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider12.SetError(comboBox3, null);
            }
        }

        private void textBox11_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                e.Cancel = true;
                textBox11.Focus();
                errorProvider13.SetError(textBox11, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider13.SetError(textBox11, null);
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox8.Text))
            {
                e.Cancel = true;
                textBox8.Focus();
                errorProvider14.SetError(textBox8, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider14.SetError(textBox8, null);
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

                    if (textBox1.Text.Length > 8)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);

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

                    if (textBox10.Text.Length > 3)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if ((textBox10.Text.Length < 4) && (textBox10.Text.Length > 0))
            {
                MessageBox.Show("Zip Code must be 4 digits!");
                textBox10.Focus();
            }
        }

        private void comboBox5_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(comboBox5.Text))
            {
                e.Cancel = true;
                comboBox5.Focus();
                errorProvider15.SetError(comboBox5, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider15.SetError(comboBox5, null);
            }
        }

        private void textBox10_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox10.Text))
            {
                e.Cancel = true;
                textBox10.Focus();
                errorProvider9.SetError(textBox10, "Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider9.SetError(textBox10, null);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
      
    }


