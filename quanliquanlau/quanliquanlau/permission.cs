using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanliquanlau
{
    class permission
    {
        // Hàm check truyền vào một form
        public void Check(Form form, string insert)
        {
            if (insert == "mabimat")
            {
                form.ShowDialog();
            }

            else
            {
                MessageBox.Show("Truy cập thất bại! Kiểm tra lại Mã bí mật.", "Thông báo");
            }
            
            
        }
    }
}
