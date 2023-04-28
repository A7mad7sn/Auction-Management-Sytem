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
    public partial class ManageUsersForm : Form
    {
        string adminid;
        OracleDataAdapter adapter;
        OracleDataAdapter adapter2;
        OracleCommandBuilder builder;
        OracleCommandBuilder builder2;
        DataSet ds;
        DataSet ds2;
        public ManageUsersForm(string adminid)
        {
            InitializeComponent();
            this.adminid = adminid;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminForm f = new AdminForm(adminid);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            string constr = "data source=orcl;User Id=scott; Password=tiger;";
            string cmdstr = "select * from bidders";
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            BiddersDGV.DataSource = ds.Tables[0];
            BiddersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmdstr = "select * from sellers";
            adapter2 = new OracleDataAdapter(cmdstr, constr);
            ds2 = new DataSet();
            adapter2.Fill(ds2);
            SellersDGV.DataSource = ds2.Tables[0];
            SellersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            builder2 = new OracleCommandBuilder(adapter2);
            adapter.Update(ds.Tables[0]);
            adapter2.Update(ds2.Tables[0]);
            MessageBox.Show("Data Saved Sucessfully!");
        }
    }
}
