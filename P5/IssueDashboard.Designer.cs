namespace P5
{
    partial class IssueDashboard
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
            this.lblIssueCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.listbxMonth = new System.Windows.Forms.ListBox();
            this.listbxDiscoverer = new System.Windows.Forms.ListBox();
            this.lblTotalIssues = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Number of Issues: ";
            // 
            // lblIssueCount
            // 
            this.lblIssueCount.AutoSize = true;
            this.lblIssueCount.Location = new System.Drawing.Point(152, 47);
            this.lblIssueCount.Name = "lblIssueCount";
            this.lblIssueCount.Size = new System.Drawing.Size(0, 13);
            this.lblIssueCount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Issues by Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Issues by Discoverer";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(261, 491);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listbxMonth
            // 
            this.listbxMonth.FormattingEnabled = true;
            this.listbxMonth.Location = new System.Drawing.Point(26, 123);
            this.listbxMonth.Name = "listbxMonth";
            this.listbxMonth.Size = new System.Drawing.Size(310, 160);
            this.listbxMonth.TabIndex = 5;
            // 
            // listbxDiscoverer
            // 
            this.listbxDiscoverer.FormattingEnabled = true;
            this.listbxDiscoverer.Location = new System.Drawing.Point(26, 315);
            this.listbxDiscoverer.Name = "listbxDiscoverer";
            this.listbxDiscoverer.Size = new System.Drawing.Size(310, 160);
            this.listbxDiscoverer.TabIndex = 6;
            // 
            // lblTotalIssues
            // 
            this.lblTotalIssues.AutoSize = true;
            this.lblTotalIssues.Location = new System.Drawing.Point(158, 47);
            this.lblTotalIssues.Name = "lblTotalIssues";
            this.lblTotalIssues.Size = new System.Drawing.Size(0, 13);
            this.lblTotalIssues.TabIndex = 7;
            // 
            // IssueDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 568);
            this.Controls.Add(this.lblTotalIssues);
            this.Controls.Add(this.listbxDiscoverer);
            this.Controls.Add(this.listbxMonth);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIssueCount);
            this.Controls.Add(this.label1);
            this.Name = "IssueDashboard";
            this.Text = "Issue Dashboard";
            this.Load += new System.EventHandler(this.IssueDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIssueCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox listbxMonth;
        private System.Windows.Forms.ListBox listbxDiscoverer;
        private System.Windows.Forms.Label lblTotalIssues;
    }
}