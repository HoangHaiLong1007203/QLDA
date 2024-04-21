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
    public partial class sell : Form
    {
        public sell()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatetable f = new updatetable();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            order f = new order();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnSurvey_Click(object sender, EventArgs e)
        {
            survey f = new survey();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
