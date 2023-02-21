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
    
    public partial class AdDash : Form
    {
        public string user { get; set; }
        public AdDash()
        {
            InitializeComponent();
        }

        private void aDDSTUDENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterStudent sp = new RegisterStudent();
            this.Hide();
            sp.Show();
        }

        private void vIEWSTUDENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdStu ad = new AdStu();
            this.Hide();
            ad.Show();
        }

        private void vIEWSPONSORSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adsponsors sp = new Adsponsors();
            this.Hide();
            sp.Show();
          
        }

        private void aPPLYToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            label3.Text = DateTime.Now.ToLongDateString();
            label4.Text = DateTime.Now.ToLongTimeString();
           
        }

        private void aLLAPPLICATIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void nEWAPPLICATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            apply ad = new apply();
            ad.user = label5.Text;
            this.Hide();
            ad.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AdDash_Load(object sender, EventArgs e)
        {
            
            label5.Text = user;
        }
    }
}
