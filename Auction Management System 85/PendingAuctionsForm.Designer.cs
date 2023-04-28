namespace Auction_Management_System_85
{
    partial class PendingAuctionsForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.PendingDGV = new System.Windows.Forms.DataGridView();
            this.Auct_id_cmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Approve_btn = new System.Windows.Forms.Button();
            this.Reject_btn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PendingDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(282, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "Pending Auctions";
            // 
            // PendingDGV
            // 
            this.PendingDGV.AllowUserToAddRows = false;
            this.PendingDGV.AllowUserToDeleteRows = false;
            this.PendingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PendingDGV.Location = new System.Drawing.Point(12, 63);
            this.PendingDGV.Name = "PendingDGV";
            this.PendingDGV.Size = new System.Drawing.Size(776, 210);
            this.PendingDGV.TabIndex = 17;
            // 
            // comboBox1
            // 
            this.Auct_id_cmb.FormattingEnabled = true;
            this.Auct_id_cmb.Location = new System.Drawing.Point(274, 332);
            this.Auct_id_cmb.Name = "comboBox1";
            this.Auct_id_cmb.Size = new System.Drawing.Size(254, 21);
            this.Auct_id_cmb.Sorted = true;
            this.Auct_id_cmb.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(344, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "Auction ID";
            // 
            // Approve_btn
            // 
            this.Approve_btn.BackColor = System.Drawing.Color.LawnGreen;
            this.Approve_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Approve_btn.Location = new System.Drawing.Point(12, 371);
            this.Approve_btn.Name = "Approve_btn";
            this.Approve_btn.Size = new System.Drawing.Size(179, 44);
            this.Approve_btn.TabIndex = 20;
            this.Approve_btn.Text = "Approve";
            this.Approve_btn.UseVisualStyleBackColor = false;
            this.Approve_btn.Click += new System.EventHandler(this.Approve_btn_Click);
            // 
            // Reject_btn
            // 
            this.Reject_btn.BackColor = System.Drawing.Color.Crimson;
            this.Reject_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reject_btn.Location = new System.Drawing.Point(609, 371);
            this.Reject_btn.Name = "Reject_btn";
            this.Reject_btn.Size = new System.Drawing.Size(179, 44);
            this.Reject_btn.TabIndex = 21;
            this.Reject_btn.Text = "Reject";
            this.Reject_btn.UseVisualStyleBackColor = false;
            this.Reject_btn.Click += new System.EventHandler(this.Reject_btn_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DodgerBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(690, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 51);
            this.button3.TabIndex = 22;
            this.button3.Text = "back";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PendingAuctionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Reject_btn);
            this.Controls.Add(this.Approve_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Auct_id_cmb);
            this.Controls.Add(this.PendingDGV);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "PendingAuctionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Review Pending Auctions";
            this.Load += new System.EventHandler(this.PendingAuctionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PendingDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView PendingDGV;
        private System.Windows.Forms.ComboBox Auct_id_cmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Approve_btn;
        private System.Windows.Forms.Button Reject_btn;
        private System.Windows.Forms.Button button3;
    }
}