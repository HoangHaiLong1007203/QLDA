using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanliquanlau
{
    public partial class Function : Form
    {
        public Function()
        {
            InitializeComponent();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            sell f = new sell();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            foods f = new foods();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            adminReport f = new adminReport();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void AccountManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            adminAccount f = new adminAccount();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
