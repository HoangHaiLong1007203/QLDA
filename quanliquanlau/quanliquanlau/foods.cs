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
    public partial class foods : Form
    {
        public foods()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();

        private void food_Load(object sender, EventArgs e)
        {
            getloaisp();
            getdata();
        }
        public void getloaisp()
        {
            string query = "select * from CategoryFood";
            DataSet ds = kn.laydulieu(query);
            Category.DataSource = ds.Tables[0];
            Category.DisplayMember = "Name";
            Category.ValueMember = "ID";
        }
        public void getdata()
        {
            string query1 = "select Name from Food where CategoryID = 1";
            DataSet ds1 = kn.laydulieu(query1);
            dgv1.DataSource = ds1.Tables[0];
            string query2 = "select Name from Food where CategoryID = 2";
            DataSet ds2 = kn.laydulieu(query2);
            dgv2.DataSource = ds2.Tables[0];
            string query3 = "select Name from Food where CategoryID = 3";
            DataSet ds3 = kn.laydulieu(query3);
            dgv3.DataSource = ds3.Tables[0];
            string query4 = "select Name from Food where CategoryID = 4";
            DataSet ds4 = kn.laydulieu(query4);
            dgv4.DataSource = ds4.Tables[0];
            string query5 = "select Name from Food where CategoryID = 5";
            DataSet ds5 = kn.laydulieu(query5);
            dgv5.DataSource = ds5.Tables[0];
            string query6 = "select Name from Food where CategoryID = 6";
            DataSet ds6 = kn.laydulieu(query6);
            dgv6.DataSource = ds6.Tables[0];

        }
        public void cleartext()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            ID.Text = "";
            NameFood.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cleartext();
            getdata();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = String.Format("insert into Food values(N'{0}','{1}')",
                NameFood.Text,
                Category.SelectedValue
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
            string query = String.Format("update Food set Name='{1}',CategoryID='{2}' where ID='{0}'",
                ID.Text,
                NameFood.Text,
                Category.SelectedValue
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
            string query = String.Format("delete from Food where ID='{0}'",
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
                NameFood.Text = dgv1.Rows[r].Cells["Name"].Value.ToString();
                
                string query1 = "select * from Food where CategoryID = 1";
                DataSet ds1 = kn.laydulieu(query1);
                ID.Text = ds1.Tables[0].Rows[r]["ID"].ToString();
                Category.SelectedValue = ds1.Tables[0].Rows[r]["CategoryID"].ToString();
            }
        }

        private void dgv3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                NameFood.Text = dgv3.Rows[r].Cells["Name"].Value.ToString();

                string query1 = "select * from Food where CategoryID = 3";
                DataSet ds1 = kn.laydulieu(query1);
                ID.Text = ds1.Tables[0].Rows[r]["ID"].ToString();
                Category.SelectedValue = ds1.Tables[0].Rows[r]["CategoryID"].ToString();
            }
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                NameFood.Text = dgv2.Rows[r].Cells["Name"].Value.ToString();

                string query1 = "select * from Food where CategoryID = 2";
                DataSet ds1 = kn.laydulieu(query1);
                ID.Text = ds1.Tables[0].Rows[r]["ID"].ToString();
                Category.SelectedValue = ds1.Tables[0].Rows[r]["CategoryID"].ToString();
            }
        }

        private void dgv4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                NameFood.Text = dgv4.Rows[r].Cells["Name"].Value.ToString();

                string query1 = "select * from Food where CategoryID = 4";
                DataSet ds1 = kn.laydulieu(query1);
                ID.Text = ds1.Tables[0].Rows[r]["ID"].ToString();
                Category.SelectedValue = ds1.Tables[0].Rows[r]["CategoryID"].ToString();
            }
        }

        private void dgv5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                NameFood.Text = dgv5.Rows[r].Cells["Name"].Value.ToString();

                string query1 = "select * from Food where CategoryID = 5";
                DataSet ds1 = kn.laydulieu(query1);
                ID.Text = ds1.Tables[0].Rows[r]["ID"].ToString();
                Category.SelectedValue = ds1.Tables[0].Rows[r]["CategoryID"].ToString();
            }
        }

        private void dgv6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                NameFood.Text = dgv6.Rows[r].Cells["Name"].Value.ToString();

                string query1 = "select * from Food where CategoryID = 6";
                DataSet ds1 = kn.laydulieu(query1);
                ID.Text = ds1.Tables[0].Rows[r]["ID"].ToString();
                Category.SelectedValue = ds1.Tables[0].Rows[r]["CategoryID"].ToString();
            }
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
