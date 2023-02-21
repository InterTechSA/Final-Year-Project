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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=146.230.177.46;Initial Catalog=GroupWst24;Persist Security Info=True;User ID=GroupWst24;Password=hc82b");

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerDash md = new ManagerDash();
            this.Hide();
            md.Show();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'groupWst24DataSet5.Details' table. You can move, or remove it, as needed.
            // this.detailsTableAdapter.Fill(this.groupWst24DataSet5.Details);
            // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
            //       this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
            // searchData("");

            SqlCommand slq =new SqlCommand("SELECT NAppli.ApplicationId, NAppli.CompanyId, NAppli.CompanyName, NAppli.Date, NAppli.StaffName,Students.* FROM NAppli inner join Students on NAppli.StudentNumber=Students.StudentNumber",con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = slq;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridView1.Columns[0].HeaderText = "ApplicationId";
            //dataGridView1.Columns[1].HeaderText = "CompanyId";
            //dataGridView1.Columns[2].HeaderText = "CompanyName";
            //dataGridView1.Columns[3].HeaderText = "Date";
            //dataGridView1.Columns[4].HeaderText = "StudentNumber";
            //dataGridView1.Columns[5].HeaderText = "SaffName";
            //dataGridView1.Columns[6].HeaderText = "StudentNumber";
            //dataGridView1.Columns[7].HeaderText = "FirstName";
            //dataGridView1.Columns[8].HeaderText = "LastName";
            //dataGridView1.Columns[9].HeaderText = "Id";
            //dataGridView1.Columns[10].HeaderText = "Country";
            //dataGridView1.Columns[11].HeaderText = "Province";
            //dataGridView1.Columns[12].HeaderText = "Street";
            //dataGridView1.Columns[13].HeaderText = "Town";
            //dataGridView1.Columns[14].HeaderText = "ZipCode";
            //dataGridView1.Columns[15].HeaderText = "Phone";
            //dataGridView1.Columns[16].HeaderText = "Email";
            //dataGridView1.Columns[17].HeaderText = "AverageMark";
            //dataGridView1.Columns[18].HeaderText = "LevelOfStudy";
            //dataGridView1.Columns[19].HeaderText = "Institution";
            //dataGridView1.Columns[20].HeaderText = "Degree";
            //dataGridView1.Columns[21].HeaderText = "AcademicRecord";


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //searchData(textBox1.Text);
        }
        public void searchData(string valueToFind)
        {
            //string searchQuery = "SELECT * FROM SetApplications WHERE CONCAT(ApplicationID, CompanyId, StudentNumber) LIKE '%" + valueToFind + "%'";
            //SqlDataAdapter sda = new SqlDataAdapter(searchQuery, con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //dataGridView1.DataSource = dt;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataTable1DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void detailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.detailsBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.groupWst24DataSet5);

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
