using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auction_Management_System_85
{
    public partial class ReportForm : Form
    {
        string adminid;
        public ReportForm(string adminid)
        {
            InitializeComponent();
            this.adminid = adminid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminForm f = new AdminForm(adminid);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
