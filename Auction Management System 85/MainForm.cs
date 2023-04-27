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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserLogin f2 = new UserLogin();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            AdminLogin f6 = new AdminLogin();
            this.Hide();
            f6.ShowDialog();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration f3 = new Registration();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
