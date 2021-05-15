using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Suprema
{
    public partial class UFE30_UserInfo : Form
    {
        public string UserID
        {
            get
            {
                return tbxUserID.Text;
            }
            set
            {
                tbxUserID.Text = value;
            }
        }
        public UFE30_UserInfo()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}