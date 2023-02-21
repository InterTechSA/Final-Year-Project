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
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection con = new SqlConnection("Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");
                SqlCommand command = new SqlCommand("select  * from Login where Username='" + textBox1.Text + "' and Userpassword ='" + textBox2.Text + "'", con);
                SqlDataAdapter sd = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                string cmb = comboBox1.SelectedItem.ToString();


                if (dt.Rows.Count > 0)
                {
                 
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Role"].ToString() == cmb)
                        {
                         
                            if (comboBox1.SelectedIndex == 0)
                            {
                                AdDash md = new AdDash();
                                md.user = textBox1.Text;
                                this.Hide();
                                md.Show();
                                
                            }
                            else
                            {
                                ManagerDash ma = new ManagerDash();
                                this.Hide();
                                ma.Show();
                               
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Credentials", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please ensure that you select the Role!!!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit ?", "Confirm Exit", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
