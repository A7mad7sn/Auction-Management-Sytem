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

namespace Auction_Management_System_85
{
    public partial class Registration : Form
    {
        string ordb = "data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        public Registration()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            int maxid = 0;
            if (EmailTextBox.Text.ToString() == "" || PasswordTextBox.Text.ToString() == "" || NameTextBox.Text.ToString() == "" || PhoneTextBox.Text.ToString() == "")
            {
                MessageBox.Show("Please Fill your Data");
                return;
            }
            if (SellerRadioButton.Checked)
            {
                cmd.CommandText = "GetNewsellerID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                maxid = Int32.Parse(cmd.Parameters["id"].Value.ToString()) + 1;

                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.Parameters.Add("id", maxid);
                cmd2.Parameters.Add("E_mail", EmailTextBox.Text.ToString());
                cmd2.Parameters.Add("Password", PasswordTextBox.Text.ToString());
                cmd2.Parameters.Add("Phone_number", PhoneTextBox.Text.ToString());
                cmd2.Parameters.Add("Name", NameTextBox.Text.ToString());
                cmd2.CommandText = "insert into sellers VALUES (:id,:E_mail,:Password,:Phone_number,:Name)";
                int r = cmd2.ExecuteNonQuery();
                if (r != -1)
                    MessageBox.Show("New Seller is added");
            }
            else if (BidderRadioButton.Checked)
            {
                cmd.CommandText = "GetNewBidderID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Int32, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                maxid = Int32.Parse(cmd.Parameters["id"].Value.ToString())+1;

                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.Parameters.Add("id", maxid);
                cmd2.Parameters.Add("E_mail", EmailTextBox.Text.ToString());
                cmd2.Parameters.Add("Password", PasswordTextBox.Text.ToString());
                cmd2.Parameters.Add("Phone_number", PhoneTextBox.Text.ToString());
                cmd2.Parameters.Add("Name", NameTextBox.Text.ToString());
                cmd2.CommandText = "insert into BIDDERS VALUES (:id,:E_mail,:Password,:Phone_number,:Name)";
                int r = cmd2.ExecuteNonQuery();
                if (r != -1)
                    MessageBox.Show("New Bidder is added");
            }
            else
            {
                MessageBox.Show("Please Select either Bidder or Seller");
                return;
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
