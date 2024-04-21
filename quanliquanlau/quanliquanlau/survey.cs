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
    public partial class survey : Form
    {
        public survey()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = String.Format("insert into Survey values(N'{0}','{1}',N'{2}')",
                txtGuestName.Text,
                dateSurvey.Text,
                txtContent.Text
                );
            if (kn.thucthi(query) == true)
            {
                MessageBox.Show("Lưu thành công!");
                btnClear.PerformClick();
            }
            else
            {
                MessageBox.Show("Lưu thất bại!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGuestName.Text="";
            dateSurvey.Value= DateTime.Today;
            txtContent.Text = "";
        }
    }
}
