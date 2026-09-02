namespace MunicipalServicesApp
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnReportIssues = new System.Windows.Forms.Button();
            this.btnLocalEvents = new System.Windows.Forms.Button();
            this.btnServiceStatus = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102);
            this.lblTitle.Location = new System.Drawing.Point(40, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Municipal Services Application";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblSubtitle
            //
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubtitle.Location = new System.Drawing.Point(40, 75);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(520, 30);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Please select a service below";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnReportIssues
            //
            this.btnReportIssues.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnReportIssues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportIssues.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportIssues.ForeColor = System.Drawing.Color.White;
            this.btnReportIssues.Location = new System.Drawing.Point(80, 130);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new System.Drawing.Size(440, 55);
            this.btnReportIssues.TabIndex = 2;
            this.btnReportIssues.Text = "Report Issues";
            this.btnReportIssues.UseVisualStyleBackColor = false;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);
            //
            // btnLocalEvents
            //
            this.btnLocalEvents.Enabled = false;
            this.btnLocalEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalEvents.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLocalEvents.Location = new System.Drawing.Point(80, 200);
            this.btnLocalEvents.Name = "btnLocalEvents";
            this.btnLocalEvents.Size = new System.Drawing.Size(440, 55);
            this.btnLocalEvents.TabIndex = 3;
            this.btnLocalEvents.Text = "Local Events and Announcements (Coming Soon)";
            this.btnLocalEvents.UseVisualStyleBackColor = true;
            this.btnLocalEvents.Click += new System.EventHandler(this.btnLocalEvents_Click);
            //
            // btnServiceStatus
            //
            this.btnServiceStatus.Enabled = false;
            this.btnServiceStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnServiceStatus.Location = new System.Drawing.Point(80, 270);
            this.btnServiceStatus.Name = "btnServiceStatus";
            this.btnServiceStatus.Size = new System.Drawing.Size(440, 55);
            this.btnServiceStatus.TabIndex = 4;
            this.btnServiceStatus.Text = "Service Request Status (Coming Soon)";
            this.btnServiceStatus.UseVisualStyleBackColor = true;
            this.btnServiceStatus.Click += new System.EventHandler(this.btnServiceStatus_Click);
            //
            // lblFooter
            //
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblFooter.ForeColor = System.Drawing.Color.Gray;
            this.lblFooter.Location = new System.Drawing.Point(40, 350);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(520, 30);
            this.lblFooter.TabIndex = 5;
            this.lblFooter.Text = "Serving our community, one request at a time.";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // MainMenuForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.btnServiceStatus);
            this.Controls.Add(this.btnLocalEvents);
            this.Controls.Add(this.btnReportIssues);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(616, 439);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services Application - Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnLocalEvents;
        private System.Windows.Forms.Button btnServiceStatus;
        private System.Windows.Forms.Label lblFooter;
    }
}
