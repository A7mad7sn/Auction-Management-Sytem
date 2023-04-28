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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Auction_Management_System_85
{
    public partial class SellerForm : Form
    {
        string sellerid;
        string ordb = "data source=orcl; user id=scott; password=tiger;";
        OracleConnection conn;
        public SellerForm(string seller_id)
        {
            InitializeComponent();
            this.sellerid=seller_id;
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            cmb_ID.DropDownStyle = ComboBoxStyle.DropDownList;
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetSellerAuctions";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("sellerid", sellerid);
            cmd.Parameters.Add("Auctionsids", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_ID.Items.Add(dr[0]);
            }
            dr.Close();
        }
        private void ViewHistory_click(object sender, EventArgs e)
        {
            UserLogin f = new UserLogin();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        

        private void cmb_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ITEM, ITEM_DESCRIPTION, START_DATE,END_DATE,SELLER_ID,approved_by,lowest_bid from AUCTIONS where AUCTION_ID =: id";
            cmd.Parameters.Add("id", cmb_ID.SelectedItem.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_Item.Text = dr[0].ToString();
                txt_Description.Text = dr[1].ToString();
                txt_Seller.Text = dr[4].ToString();
                start_Date.Value = (DateTime)dr[2];
                end_Date.Value = (DateTime)dr[3];
                Txt_StartingBid.Text = dr[6].ToString();
                if (dr[5].ToString() != null)
                    Approved_CheckBox.Checked = true;
            }
            dr.Close();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (txt_Item.Text==""||txt_Description.Text==""||Txt_StartingBid.Text=="")
            {
                MessageBox.Show("Complete Your Data!");
                return;
            }
            if (DateTime.Compare(start_Date.Value.Date.AddDays(1), DateTime.Now) < 0)
            {
                MessageBox.Show("Invalid Start Date!");
                return;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            string to_be_appended = "";
            cmd.CommandText = "select Max(auction_id) from auctions";
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                to_be_appended = (Int32.Parse(dr[0].ToString())+1).ToString();
            dr.Close();
            cmb_ID.Text = to_be_appended;
            cmb_ID.Items.Add(cmb_ID.Text);
            txt_Seller.Text = sellerid;
            cmd.CommandText = "insert into AUCTIONS values(:id, :item, :itemdesc,:startdate,:enddate,:sellerid,null,:startingbid)";
            cmd.Parameters.Add("id", cmb_ID.Text);
            cmd.Parameters.Add("item", txt_Item.Text);
            cmd.Parameters.Add("itemdesc", txt_Description.Text);
            cmd.Parameters.Add("startdate", start_Date.Value.Date);
            cmd.Parameters.Add("enddate", end_Date.Value.Date);
            cmd.Parameters.Add("sellerid", txt_Seller.Text);
            cmd.Parameters.Add("startingbid", Txt_StartingBid.Text);
            Approved_CheckBox.Checked = false;

            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                cmb_ID.Items.Add(cmb_ID.Text);
                MessageBox.Show("New Auction Created!\nAuction ID : "+to_be_appended);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Item.Text == "" || txt_Description.Text == "" || Txt_StartingBid.Text == "")
            {
                MessageBox.Show("Complete Your Data!");
                return;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update AUCTIONS set ITEM = :item, ITEM_DESCRIPTION = :itemdesc,START_DATE = :startdate, END_DATE = :enddate, SELLER_ID = :sellerid where AUCTION_ID = :id";
            cmd.Parameters.Add("item", txt_Item.Text);
            cmd.Parameters.Add("itemdesc", txt_Description.Text);
            cmd.Parameters.Add("startdate", start_Date.Value.Date);
            cmd.Parameters.Add("enddate", end_Date.Value.Date);
            cmd.Parameters.Add("sellerid", txt_Seller.Text);
            cmd.Parameters.Add("id", cmb_ID.Text);
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Auction Updated!");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (cmb_ID.Text == "")
            {
                MessageBox.Show("No Rows to delete!");
                return;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from AUCTIONS where AUCTION_ID = :id";
            cmd.Parameters.Add("id", cmb_ID.Text);
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                cmb_ID.Items.RemoveAt(cmb_ID.SelectedIndex);
                txt_Item.Text = "";
                txt_Description.Text = "";
                txt_Seller.Text = "";
                Txt_StartingBid.Text = "";
                Approved_CheckBox.Checked = false;
                MessageBox.Show("Auction Deleted!");
                start_Date.Value = DateTime.Now;
                end_Date.Value = DateTime.Now;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmb_ID.Text != "")
            {
                AuctionHistoryForm f = new AuctionHistoryForm(cmb_ID.Text,sellerid,"-999");
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("No selected Auction to view history");
        }
    }
}
