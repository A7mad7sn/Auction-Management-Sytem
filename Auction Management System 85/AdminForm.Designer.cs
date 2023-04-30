namespace Auction_Management_System_85
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Mangebtn = new System.Windows.Forms.Button();
            this.PendingAuctionsBtn = new System.Windows.Forms.Button();
            this.AuctionReportBtn = new System.Windows.Forms.Button();
            this.SellerReportBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(308, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hello Admin";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(682, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 51);
            this.button2.TabIndex = 23;
            this.button2.Text = "back";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Mangebtn
            // 
            this.Mangebtn.BackColor = System.Drawing.Color.Gold;
            this.Mangebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mangebtn.Location = new System.Drawing.Point(180, 125);
            this.Mangebtn.Name = "Mangebtn";
            this.Mangebtn.Size = new System.Drawing.Size(410, 42);
            this.Mangebtn.TabIndex = 24;
            this.Mangebtn.Text = "Manage Users";
            this.Mangebtn.UseVisualStyleBackColor = false;
            this.Mangebtn.Click += new System.EventHandler(this.Mangebtn_Click);
            // 
            // PendingAuctionsBtn
            // 
            this.PendingAuctionsBtn.BackColor = System.Drawing.Color.Gold;
            this.PendingAuctionsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PendingAuctionsBtn.Location = new System.Drawing.Point(180, 208);
            this.PendingAuctionsBtn.Name = "PendingAuctionsBtn";
            this.PendingAuctionsBtn.Size = new System.Drawing.Size(410, 42);
            this.PendingAuctionsBtn.TabIndex = 25;
            this.PendingAuctionsBtn.Text = "Review Pending Auctions";
            this.PendingAuctionsBtn.UseVisualStyleBackColor = false;
            this.PendingAuctionsBtn.Click += new System.EventHandler(this.PendingAuctionsBtn_Click);
            // 
            // AuctionReportBtn
            // 
            this.AuctionReportBtn.BackColor = System.Drawing.Color.Gold;
            this.AuctionReportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuctionReportBtn.Location = new System.Drawing.Point(180, 348);
            this.AuctionReportBtn.Name = "AuctionReportBtn";
            this.AuctionReportBtn.Size = new System.Drawing.Size(410, 42);
            this.AuctionReportBtn.TabIndex = 26;
            this.AuctionReportBtn.Text = "Generate Report for all Auctions";
            this.AuctionReportBtn.UseVisualStyleBackColor = false;
            this.AuctionReportBtn.Click += new System.EventHandler(this.ReportBtn_Click);
            // 
            // SellerReportBtn
            // 
            this.SellerReportBtn.BackColor = System.Drawing.Color.Gold;
            this.SellerReportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellerReportBtn.Location = new System.Drawing.Point(180, 279);
            this.SellerReportBtn.Name = "SellerReportBtn";
            this.SellerReportBtn.Size = new System.Drawing.Size(410, 42);
            this.SellerReportBtn.TabIndex = 27;
            this.SellerReportBtn.Text = "Generate Report for all Sellers";
            this.SellerReportBtn.UseVisualStyleBackColor = false;
            this.SellerReportBtn.Click += new System.EventHandler(this.SellerReportBtn_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SellerReportBtn);
            this.Controls.Add(this.AuctionReportBtn);
            this.Controls.Add(this.PendingAuctionsBtn);
            this.Controls.Add(this.Mangebtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Form";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Mangebtn;
        private System.Windows.Forms.Button PendingAuctionsBtn;
        private System.Windows.Forms.Button AuctionReportBtn;
        private System.Windows.Forms.Button SellerReportBtn;
    }
}