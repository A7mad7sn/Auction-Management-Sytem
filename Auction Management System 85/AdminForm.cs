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
    public partial class AdminForm : Form
    {
        string adminid;
        public AdminForm(string adminid)
        {
            InitializeComponent();
            this.adminid = adminid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminLogin f = new AdminLogin();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void PendingAuctionsBtn_Click(object sender, EventArgs e)
        {
            PendingAuctionsForm f = new PendingAuctionsForm(adminid);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void Mangebtn_Click(object sender, EventArgs e)
        {
            ManageUsersForm f = new ManageUsersForm(adminid);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void ReportBtn_Click(object sender, EventArgs e)
        {
            ReportForm f = new ReportForm(adminid);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
