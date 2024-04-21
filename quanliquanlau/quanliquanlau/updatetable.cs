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
    public partial class updatetable : Form
    {
        public updatetable()
        {
            InitializeComponent();
        }
        ketnoi kn = new ketnoi();
        
        public List<Table> LoadTableList()
        {
            string query = "select * from tablebbq";
            List<Table> tableList = new List<Table>();
            DataSet ds = kn.laydulieu(query);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        void LoadTable()
        {
            List<Table> tableList = LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = 95, Height = 95 }; 
                btn.Font = new Font("Arial", 10, FontStyle.Regular);

                string label = item.Name + Environment.NewLine + item.Status;
                btn.Text = label.ToUpper();
                btn.Tag = item.ID; // Lưu trữ giá trị id của item vào thuộc tính Tag của button
                switch (item.Status)
                {
                    case "null":
                        btn.BackColor = Color.LightGray;
                        break;
                    default:
                        btn.BackColor = Color.LightGreen;
                        break;
                }

                flpTableList.Controls.Add(btn);
                btn.Click += btn_Click; // Thêm sự kiện Click cho button
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button; // Ép kiểu sender thành Button
            int id = (int)btn.Tag; // Lấy ra giá trị id của item từ thuộc tính Tag của button
            string status = btn.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Last();
            switch (status)
            {
                case "NULL":
                    string query = String.Format("UPDATE tablebbq SET status = 'using' WHERE id = '{0}';", id);
                    if (kn.thucthi(query) == true)
                    {
                        RefreshList();
                    }
                    else
                    {
                        MessageBox.Show("cập nhật thất bại!");
                    }
                    break;
                default:
                    string query2 = String.Format("UPDATE tablebbq SET status = 'null' WHERE id = '{0}';", id);
                    if (kn.thucthi(query2) == true)
                    {
                        RefreshList();
                    }
                    else
                    {
                        MessageBox.Show("cập nhật thất bại!");
                    }
                    break;
            }
            
        }

        void RefreshList()
        {
            flpTableList.Controls.Clear();
            LoadTable();
        }
        private void updatetable_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tablebbq (Name) SELECT 'table' + CAST(ID+1 AS NVARCHAR(100)) FROM tablebbq WHERE ID = (SELECT MAX(ID) FROM tablebbq)";
            if (MessageBox.Show("Xác nhận thêm bàn mới?", "Thông báo", MessageBoxButtons.OKCancel) ==
                System.Windows.Forms.DialogResult.OK)
            {
                if (kn.thucthi(query) == true)
                {
                    MessageBox.Show("thêm thành công!");
                    RefreshList();
                }
                else
                {
                    MessageBox.Show("thêm thất bại!");
                }
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM tablebbq WHERE ID = (SELECT MAX(ID) FROM tablebbq);DECLARE @NewID INT; SET @NewID = (SELECT MAX(ID) FROM tablebbq); DBCC CHECKIDENT ('tablebbq', RESEED, @NewID);";
            if (MessageBox.Show("Xác nhận xóa bớt bàn?", "Thông báo", MessageBoxButtons.OKCancel) ==
                System.Windows.Forms.DialogResult.OK)
            {
                if (kn.thucthi(query) == true)
                {
                    MessageBox.Show("xóa thành công!");
                    RefreshList();
                }
                else
                {
                    MessageBox.Show("xóa thất bại!");
                }
            }
        }
    }
}
