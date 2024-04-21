using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace quanliquanlau
{
    class ketnoi
    {
        string str = @"Data Source=LAPTOP-1598GMAU\SQLEXPRESS;Initial Catalog=moonbbq;Integrated Security=True";
        SqlConnection conn;
        public ketnoi()
        {
            conn = new SqlConnection(str);
        }
        public DataSet laydulieu(string truyvan) {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(truyvan, conn);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public bool thucthi(string truyvan) {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(truyvan, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
