﻿using System;
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
    public partial class adminReport : Form
    {
        public adminReport()
        {
            InitializeComponent();
        }
        
        private void btnAccess_Click(object sender, EventArgs e)
        {
            this.Close();
            // Tạo một đối tượng của class permission
            permission per = new permission();
            report f = new report();
            per.Check(f,txtSecretCode.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
