using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSystem
{
    public partial class ManagerDash : Form
    {
        public ManagerDash()
        {
            InitializeComponent();
        }

        private void aDDSPONSORSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterSponsor rs = new RegisterSponsor();
            this.Hide();
            rs.Show();
        }

        private void vIEWSPONSORSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sponsors sp = new Sponsors();
            this.Hide();
            sp.Show();
        }

        private void aDDSTAFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff st = new Staff();
            this.Hide();
            st.Show();
        }

        private void vIEWSTUDENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Students st = new Students();
            this.Hide();
            st.Show();
        }

        private void vIEWSTAFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStaff vs = new ViewStaff();
            this.Hide();
            vs.Show();
        }

        private void rEPORTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // //mApplications m = new mApplications();
           // this.Hide();
          //  m.Show();
               
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            label2.Text = DateTime.Now.ToLongDateString();
            label3.Text = DateTime.Now.ToLongTimeString();
        }

        private void rEPORTSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void aLLAPPLICATIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports repo = new Reports();
            this.Hide();
            repo.Show();
        }

        private void sUMMARISEDREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StepTwo reo = new StepTwo();
            this.Hide();
            reo.Show();
        }
    }
}
