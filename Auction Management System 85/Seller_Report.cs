using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
namespace Auction_Management_System_85
{
    public partial class Seller_report : Form
    {
        CrystalReport2 CR;
        string adminid;
        public Seller_report(string adminid)
        {
            InitializeComponent();
            this.adminid = adminid;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport2();
            foreach(ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
                comboBox1.Items.Add(v.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CR.SetParameterValue(0, comboBox1.Text);
                crystalReportViewer1.ReportSource = CR;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminForm f = new AdminForm(adminid);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
