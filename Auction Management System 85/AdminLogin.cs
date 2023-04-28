using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Auction_Management_System_85
{
    public partial class AdminLogin : Form
    {
        string ordb = "data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select admin_id,password from admin where admin_id =:adminid";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("adminid", AdminIdTextBox.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString() == AdminIdTextBox.Text.ToString() && dr[1].ToString() == PasswordTextBox.Text.ToString())
                {
                    AdminForm f = new AdminForm(AdminIdTextBox.Text.ToString());
                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Data");
                }
                dr.Close();
            }
            else
            {
                MessageBox.Show("Invalid Data");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

    }
}
