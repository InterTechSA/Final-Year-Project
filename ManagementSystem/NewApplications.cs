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
    public partial class NewApplications : Form
    {
        public NewApplications()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");

        private void button1_Click(object sender, EventArgs e)
        {
            AdDash ad = new AdDash();
            this.Hide();
            ad.Show();

        }

        private void NewApplications_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'groupWst24DataSet5.Details' table. You can move, or remove it, as needed.
            this.detailsTableAdapter.Fill(this.groupWst24DataSet5.Details);
            // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
            ///      this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);

            // searchData("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // searchData(textBox1.Text);
        }
        public void searchData(string valueToFind)
        {
            //string searchQuery = "SELECT * FROM SetApplications WHERE CONCAT(ApplicationID, StudentNumber, StaffId) LIKE '%" + valueToFind + "%'";
            //SqlDataAdapter sda = new SqlDataAdapter(searchQuery, con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //dataGridView1.DataSource = dt;
        }

        private void dataTable1DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
