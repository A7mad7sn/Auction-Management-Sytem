using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Auction_Management_System_85
{
    public partial class PendingAuctionsForm : Form
    {
        string ordb = "data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        OracleDataAdapter adapter;
        DataSet ds;
        string adminid;
        public PendingAuctionsForm(string adminid)
        {
            InitializeComponent();
            this.adminid = adminid;
        }

        private void PendingAuctionsForm_Load(object sender, EventArgs e)
        {
            Auct_id_cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select auction_id from auctions where approved_by is null";
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Auct_id_cmb.Items.Add(dr[0]);
            }
            
            
            string constr = "data source=orcl;User Id=scott; Password=tiger;";
            string cmdstr = "select * from auctions where approved_by is null";
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            PendingDGV.DataSource = ds.Tables[0];
            PendingDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminForm f = new AdminForm(adminid);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void Approve_btn_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            if(Auct_id_cmb.Text == "")
            {
                MessageBox.Show("Please select auction id from combo box!");
                return;
            }
            cmd.Parameters.Add("adminid",adminid);
            cmd.Parameters.Add("auctionid", Auct_id_cmb.Text.ToString());
            cmd.CommandText = "Update auctions set approved_by = :adminid where auction_id = :auctionid";
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                Auct_id_cmb.Items.RemoveAt(Auct_id_cmb.SelectedIndex);
                string constr = "data source=orcl;User Id=scott; Password=tiger;";
                string cmdstr = "select * from auctions where approved_by is null";
                adapter = new OracleDataAdapter(cmdstr, constr);
                ds = new DataSet();
                adapter.Fill(ds);
                PendingDGV.DataSource = ds.Tables[0];
                PendingDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                MessageBox.Show("Approved!");
            }
        }

        private void Reject_btn_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            if (Auct_id_cmb.Text == "")
            {
                MessageBox.Show("Please select auction id from combo box!");
                return;
            }
            cmd.Parameters.Add("auctionid", Auct_id_cmb.Text.ToString());
            cmd.CommandText = "delete from auctions where auction_id = :auctionid";
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                Auct_id_cmb.Items.RemoveAt(Auct_id_cmb.SelectedIndex);
                string constr = "data source=orcl;User Id=scott; Password=tiger;";
                string cmdstr = "select * from auctions where approved_by is null";
                adapter = new OracleDataAdapter(cmdstr, constr);
                ds = new DataSet();
                adapter.Fill(ds);
                PendingDGV.DataSource = ds.Tables[0];
                PendingDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                MessageBox.Show("Rejected!");
            }
        }
    }
}
