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
    public partial class Adsponsors : Form
    {
        public Adsponsors()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");

        public void searchData(string valueToFind)
        {
            string searchQuery = "SELECT * FROM Sponsor WHERE CONCAT(CompanyId, CompanyName) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(searchQuery, connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdDash ad = new AdDash();
            this.Hide();
            ad.Show();
        }

        private void Adsponsors_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'groupWst24DataSet3.Sponsor' table. You can move, or remove it, as needed.
            this.sponsorTableAdapter.Fill(this.groupWst24DataSet3.Sponsor);
            // this.finalSponsorTableAdapter.Fill(this.groupWst24DataSet7.FinalSponsor);
            searchData("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);
        }
    }
}
