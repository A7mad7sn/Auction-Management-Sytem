﻿using System;
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
    public partial class ReportForm : Form
    {
        CrystalReport1 Cr;
        string adminid;
        public ReportForm(string adminid)
        {
            InitializeComponent();
            this.adminid = adminid;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Cr.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = Cr;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            Cr = new CrystalReport1();
            foreach (ParameterDiscreteValue v in Cr.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
