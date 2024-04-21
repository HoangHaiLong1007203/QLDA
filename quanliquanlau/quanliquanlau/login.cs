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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) !=
                System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string query = String.Format("select * from Account where Username='{0}' and Password='{1}'",
                txtName.Text,
                txtPass.Text);
            DataSet ds = kn.laydulieu(query);
            if (ds.Tables[0].Rows.Count == 1)
            {
                MessageBox.Show("Đăng nhập thành công!","Thông báo");
                Function f = new Function();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Kiểm tra lại Tên đăng nhập và mật khẩu.", "Thông báo");
            }
        }
    }
}
