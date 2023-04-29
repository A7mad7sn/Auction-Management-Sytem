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
    public partial class AuctionHistoryForm : Form
    {
        OracleDataAdapter adapter;
        DataSet ds;
        string auctionid;
        string sellerid;
        string bidderid;
        public AuctionHistoryForm(string auction_id, string seller_id, string bidder_id)
        {
            InitializeComponent();
            this.auctionid = auction_id;
            this.sellerid = seller_id;
            this.bidderid = bidder_id;
        }

        private void AuctionHistoryForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTime.Now.ToString("U"));
            ID_txt.Text = auctionid;
            string constr = "data source=orcl;User Id=scott; Password=tiger;";
            string cmdstr = "select bpa.datetime,bpa.bidder_id,b.name,bpa.placed_bid from bidder_participate_auction bpa , bidders b where bpa.auction_id = " + auctionid + " and bpa.bidder_id = b.bidder_id order by bpa.PLACED_BID ";
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            HistoryDGV.DataSource = ds.Tables[0];
            HistoryDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sellerid == "-999")
            {
                BidderForm f = new BidderForm(bidderid);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                SellerForm f = new SellerForm(sellerid);
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
        }
    }
}
