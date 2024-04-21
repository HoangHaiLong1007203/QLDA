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
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            string query;
            if (FromDate.Text == ToDate.Text)
            {
                query = String.Format("SELECT * FROM Bill WHERE CheckIn = '{0}' ;",
                FromDate.Text
                );
            }
            else
            {
                query = String.Format("SELECT * FROM Bill WHERE CheckIn BETWEEN '{0}' AND '{1}';",
                FromDate.Text,
                ToDate.Text
                );
            }
            DataSet ds1 = kn.laydulieu(query);
            dgvDoanhThu.DataSource = ds1.Tables[0];
        }

        private void btnViewSurvey_Click(object sender, EventArgs e)
        {
            string query;
            if (fromDate2.Text == toDate2.Text)
            {
                query = String.Format("SELECT * FROM Survey WHERE CheckIn = '{0}' ;",
                fromDate2.Text
                );
            }
            else
            {
                query = String.Format("SELECT * FROM Survey WHERE CheckIn BETWEEN '{0}' AND '{1}';",
                fromDate2.Text,
                toDate2.Text
                );
            }
            DataSet ds1 = kn.laydulieu(query);
            dgvChatLuong.DataSource = ds1.Tables[0];
        }
        
    }
}
