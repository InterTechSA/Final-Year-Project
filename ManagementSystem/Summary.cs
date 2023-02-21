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
    public partial class Summary : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");

        public int CompId, ApplId, StuNum,offersAv,average;
        public string compName, FirstName,email;
        public  string StaffName;
        public Summary()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                SqlCommand command1 = new SqlCommand("insert into NAppli values('" + long.Parse(textBox1.Text) + "','" + textBox5.Text + "','" + int.Parse(textBox2.Text) + "','" + textBox4.Text + "','" + textBox3.Text + "','" + int.Parse(textBox7.Text) + "')", connect);
                command1.ExecuteNonQuery();

                MessageBox.Show("Apllication Sent");
                connect.Close();
              
            }
            catch (Exception)
            {
                MessageBox.Show("The application has already been made!!!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);

           }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StepOne sc = new StepOne();
            sc.mark = average.ToString();
            sc.offers = offersAv.ToString();
            sc.name = compName;
            sc.id = CompId.ToString();
            sc.textBox5.Text = StuNum.ToString();
            sc.textBox6.Text = email;
            sc.textBox7.Text = FirstName;
            sc.sname = textBox3.Text;
            
            this.Hide();
            sc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdDash ad = new AdDash();
            ad.user = textBox3.Text;
            this.Hide();
            ad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            apply ap = new apply();
            ap.user = textBox3.Text;
            this.Hide();
            ap.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Summary_Load(object sender, EventArgs e)
        {
            textBox5.Text = DateTime.Now.ToString("MM/dd/yyyy");
            textBox1.Text = StuNum.ToString() + CompId.ToString() ;
            textBox2.Text = CompId.ToString();
            textBox4.Text = compName;
            textBox3.Text = StaffName;
            textBox7.Text = StuNum.ToString();
            textBox8.Text = FirstName;
            textBox6.Text = email;
                
        }
    }
}
