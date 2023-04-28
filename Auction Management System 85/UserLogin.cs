using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Auction_Management_System_85
{
    public partial class UserLogin : Form
    {
        string ordb = "data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        public UserLogin()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            if(SellerRadioButton.Checked)
                cmd.CommandText = "select e_mail,password,seller_id from sellers where e_mail =:email";
            else if(BidderRadioButton.Checked)
                cmd.CommandText = "select e_mail,password,bidder_id from bidders where e_mail =:email";
            else
            {
                MessageBox.Show("Please Select either bidder or sidder");
                return;
            }
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email", EmailTextBox.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString()== EmailTextBox.Text.ToString() && dr[1].ToString() == PasswordTextBox.Text.ToString())
                {
                    if (SellerRadioButton.Checked)
                    {
                        SellerForm f = new SellerForm(dr[2].ToString());
                        this.Hide();
                        f.ShowDialog();
                        this.Close();
                    }
                    else if (BidderRadioButton.Checked)
                    {
                        BidderForm f = new BidderForm(dr[2].ToString());
                        this.Hide();
                        f.ShowDialog();
                        this.Close();
                    }
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
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
