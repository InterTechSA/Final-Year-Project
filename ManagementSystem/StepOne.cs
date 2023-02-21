using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem
{
    public partial class StepOne : Form
    {
        public string mark { get; set; }
        public string offers { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string sname { get; set; }
       


SqlConnection connect = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");

        public StepOne()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Summary s = new Summary();
           
            s.CompId = int.Parse(textBox4.Text);
            s.compName = textBox3.Text;
            s.StuNum = int.Parse(textBox5.Text);
            s.FirstName = textBox7.Text;
            s.email = textBox6.Text;
            s.StaffName = sname;
            s.average = int.Parse(textBox1.Text);
            s.offersAv = int.Parse(textBox2.Text);
        
            this.Hide();
            s.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            apply ap = new apply();
            ap.checker = true;
            ap.textBox2.Text = offers ;
            ap.textBox3.Text =mark ;
            ap.textBox4.Text= name;
            ap.textBox5.Text = id;


            this.Hide();

            ap.Show();
        }

        private void StepOne_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'groupWst24DataSet4.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.groupWst24DataSet4.Students);
          
            textBox1.Text = mark;
            textBox2.Text = offers;
            textBox4.Text = id;
            textBox3.Text = name;

            button2.Enabled = false;

            try
            {
                searchData(int.Parse(mark));
            }catch(ArgumentNullException)
            {
                searchData(0);
            }
            


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox5.Text = row.Cells[0].Value.ToString();
                textBox6.Text = row.Cells[10].Value.ToString();
                textBox7.Text = row.Cells[1].Value.ToString();
                //textBox8.Text = row.Cells[11].Value.ToString();
                

                



            }
        }
        public void searchData(int text1)
        {
            string searchQuery = " SELECT  * FROM Students WHERE AverageMark >=" + text1+" ORDER BY Averagemark DESC";
            SqlDataAdapter sda = new SqlDataAdapter(searchQuery, connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                button2.Enabled = true;
            }
            


        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            
        }
    }
}
