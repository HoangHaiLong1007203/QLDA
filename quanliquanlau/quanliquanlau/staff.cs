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
    public partial class staff : Form
    {
        public staff()
        {
            InitializeComponent();
            cbAccountType.Items.Add("Admin");
            cbAccountType.Items.Add("Staff");
            cbAccountType.SelectedIndex = 1;
        }
        ketnoi kn = new ketnoi();

        private void cbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cleartext();
            getdata();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = String.Format("insert into Account values('{0}', N'{1}', '{2}', '{3}')",
                            txtUserName.Text,
                            txtDisplayName.Text,
                            txtPassWord.Text,
                            cbAccountType.SelectedItem.ToString()
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
            string query = String.Format("update Account set DisplayName=N'{1}', PassWord='{2}', Type='{3}' where UserName='{0}';",
                            txtUserName.Text,
                            txtDisplayName.Text,
                            txtPassWord.Text,
                            cbAccountType.SelectedItem.ToString()
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
            string query = String.Format("delete from Account where UserName='{0}'",
                txtUserName.Text
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
        public void getdata()
        {
            string query1 = "select * from Account";
            DataSet ds1 = kn.laydulieu(query1);
            dgv1.DataSource = ds1.Tables[0];

        }
        public void cleartext()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            txtUserName.Text = "";
            txtDisplayName.Text = "";
            txtPassWord.Text = "";

        }

        private void staff_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtUserName.Enabled = false;
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                txtUserName.Text = dgv1.Rows[r].Cells["UserName"].Value.ToString();
                txtDisplayName.Text = dgv1.Rows[r].Cells["DisplayName"].Value.ToString();
                txtPassWord.Text = dgv1.Rows[r].Cells["PassWord"].Value.ToString();
                cbAccountType.SelectedValue = dgv1.Rows[r].Cells["Type"].Value.ToString();
            }
        }
    }
}
