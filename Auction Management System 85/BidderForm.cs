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
    
    public partial class BidderForm : Form
    {
        string ordb = "Data Source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        OracleDataAdapter adapter;
        DataSet ds;
        string bidderid;
        public BidderForm(string bidderid)
        {
            InitializeComponent();
            this.bidderid = bidderid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserLogin f = new UserLogin();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void loadAuctions_Click(object sender, EventArgs e)
        {
            
        }

        private void BidderForm_Load(object sender, EventArgs e)
        {
            cmb_id.DropDownStyle = ComboBoxStyle.DropDownList;
            conn = new OracleConnection(ordb);
            conn.Open();
            string connstr = "Data Source=orcl;User Id=scott;Password=tiger;";
            string cmdstr = "select * from auctions where approved_by is not null order by auction_id";
            adapter = new OracleDataAdapter(cmdstr, connstr);
            ds = new DataSet();
            adapter.Fill(ds);
            AuctionsDGV.DataSource = ds.Tables[0];
            AuctionsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select auction_id from auctions where approved_by is not null order by auction_id";
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                cmb_id.Items.Add(dr[0]);
        }

        private void place_bid_click(object sender, EventArgs e)
        {
            if (Newbidtxt.Text.ToString() == "" || Int32.Parse(Newbidtxt.Text.ToString()) < Int32.Parse(highbidtxt.Text.ToString()))
            { 
                MessageBox.Show("Invalid Bid Amount");
                return;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Update auctions set current_highest_bid = :highbid where auction_id=:auctionid";
            cmd.Parameters.Add("highbid", Newbidtxt.Text.ToString());
            cmd.Parameters.Add("auctionid", cmb_id.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into bidder_participate_auction (auction_id,bidder_id,placed_bid,Datetime) values (:auctionid,:bidderid,:placedbid,:datetime)";
            cmd.Parameters.Add("auctionid", cmb_id.SelectedItem.ToString());
            cmd.Parameters.Add("bidderid", bidderid);
            cmd.Parameters.Add("placedbid", Newbidtxt.Text.ToString());
            cmd.Parameters.Add("datetime", DateTime.Now.AddHours(3).ToString("U"));
            int r = cmd.ExecuteNonQuery();
            
            MessageBox.Show("Your Bid is placed!");
            highbidtxt.Text = Newbidtxt.Text;
            string connstr = "Data Source=orcl;User Id=scott;Password=tiger;";
            string cmdstr = "select * from auctions where approved_by is not null order by auction_id";
            adapter = new OracleDataAdapter(cmdstr, connstr);
            ds = new DataSet();
            adapter.Fill(ds);
            AuctionsDGV.DataSource = ds.Tables[0];
            AuctionsDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void cmb_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select current_highest_bid from auctions where auction_id =:auctionid";
            cmd.Parameters.Add("auctionid", cmb_id.SelectedItem.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                highbidtxt.Text = dr[0].ToString();
        }

        private void ViewHistory_click(object sender, EventArgs e)
        {
            if (cmb_id.Text == "")
            {
                MessageBox.Show("No selected Auction to view history");
                return;
            }
            AuctionHistoryForm f = new AuctionHistoryForm(cmb_id.SelectedItem.ToString(), "-999",bidderid);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
