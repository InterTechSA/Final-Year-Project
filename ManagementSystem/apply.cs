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
    public partial class apply : Form
    {
        public string user;
        public bool checker;

        public apply()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");

        private void button1_Click(object sender, EventArgs e)
        {
            AdDash ad = new AdDash();
            this.Hide();
            ad.Show();
        }

        private void apply_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'groupWst24DataSet2.Sponsor' table. You can move, or remove it, as needed.
            this.sponsorTableAdapter.Fill(this.groupWst24DataSet2.Sponsor);
            searchData("");
            button2.Enabled = false;
            
               
           

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
             
            StepOne st = new StepOne();
            this.Hide();
            st.name = textBox4.Text;
            st.id = textBox5.Text;
            st.mark= textBox3.Text;
            st.offers = textBox2.Text;
            st.sname = user;

            st.Show();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);
        }
        public void searchData(string valueToFind)
        {
            string searchQuery = "SELECT * FROM Sponsor WHERE CONCAT(CompanyName, CompanyId) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(searchQuery, connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells[10].Value.ToString();
                textBox3.Text = row.Cells[9].Value.ToString();
                textBox4.Text = row.Cells[1].Value.ToString();
                textBox5.Text = row.Cells[0].Value.ToString();

            }
        }

        private void button2_Validating(object sender, CancelEventArgs e)
        {

        }
        
    private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                button2.Enabled =true;
            }
            

        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
