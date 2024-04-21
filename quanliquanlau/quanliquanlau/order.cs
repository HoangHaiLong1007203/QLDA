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
    public partial class order : Form
    {
        public order()
        {
            InitializeComponent();
            cbStatus.Items.Add("Da thanh toan");
            cbStatus.Items.Add("Chua thanh toan");
            cbStatus.SelectedIndex = 1;
        }
        ketnoi kn = new ketnoi();

        private void order_Load(object sender, EventArgs e)
        {
            getdata();
        }
        public void getdata()
        {
            string query1 = "SELECT * FROM Bill WHERE (CheckIn) = CAST(GETDATE() AS date);";
            DataSet ds1 = kn.laydulieu(query1);
            dgv1.DataSource = ds1.Tables[0];

        }
        public void cleartext()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            ID.Text = "";
            dateBill.Value = DateTime.Today;
            txtTable.Text = "";
            txtNum.Text = "";
            txtDis.Text = "";
            txtTotal.Text = "";

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cleartext();
            getdata();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = String.Format("insert into Bill (CheckIn, TableID, Number, Discount,  Status) values('{0}', {1}, {2}, {3}, N'{4}')",
                            dateBill.Text,
                            int.Parse(txtTable.Text), 
                            int.Parse(txtNum.Text),
                            int.Parse(txtDis.Text),
                            cbStatus.SelectedItem.ToString()
                            );
            if (kn.thucthi(query) == true)
            {
                MessageBox.Show("thêm thành công!");
                btnRefresh.PerformClick();
            }
            else
            {
                MessageBox.Show("thêm thất bại!");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            string query = String.Format("UPDATE Bill SET CheckIn = '{1}', TableID = {2}, Number = {3}, Discount = {4},  Status = N'{5}' WHERE ID = '{0}';",
                            ID.Text,
                            dateBill.Text,
                            int.Parse(txtTable.Text),
                            int.Parse(txtNum.Text),
                            int.Parse(txtDis.Text),
                            cbStatus.SelectedItem.ToString()
                            );
            if (kn.thucthi(query) == true)
            {
                MessageBox.Show("sửa thành công!");
                btnRefresh.PerformClick();
            }
            else
            {
                MessageBox.Show("sửa thất bại!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = String.Format("delete from Bill where ID='{0}'",
                ID.Text
                );
            if (kn.thucthi(query) == true)
            {
                MessageBox.Show("xóa thành công!");
                btnRefresh.PerformClick();
            }
            else
            {
                MessageBox.Show("xóa thất bại!");
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                ID.Text = dgv1.Rows[r].Cells["ID"].Value.ToString();
                dateBill.Text = dgv1.Rows[r].Cells["CheckIn"].Value.ToString();
                txtTable.Text = dgv1.Rows[r].Cells["TableID"].Value.ToString();
                txtNum.Text = dgv1.Rows[r].Cells["Number"].Value.ToString();
                txtDis.Text = dgv1.Rows[r].Cells["Discount"].Value.ToString();
                txtTotal.Text = dgv1.Rows[r].Cells["TotalPrice"].Value.ToString();
                cbStatus.SelectedValue = dgv1.Rows[r].Cells["Status"].Value.ToString();
            }
        }
    }
}
