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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");

        public void searchData(string valueToFind)
        {
            string searchQuery = "SELECT * FROM Students WHERE CONCAT(StudentNumber, FirstName, LastName) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(searchQuery, connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerDash md = new ManagerDash();
            this.Hide();
            md.Show();
        }

        private void Students_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'groupWst24DataSet1.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.groupWst24DataSet1.Students);
           
            searchData("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;

        }
    }
}
