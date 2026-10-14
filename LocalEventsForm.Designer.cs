namespace MunicipalServicesApp
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDateFilter = new System.Windows.Forms.DateTimePicker();
            this.chkFilterByDate = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lvEvents = new System.Windows.Forms.ListView();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colLocation = new System.Windows.Forms.ColumnHeader();
            this.lblRecommended = new System.Windows.Forms.Label();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblRecentSearches = new System.Windows.Forms.Label();
            this.btnNextAnnouncement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102);
            this.lblTitle.Location = new System.Drawing.Point(25, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Local Events and Announcements";
            //
            // lblCategory
            //
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(25, 65);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(70, 20);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category:";
            //
            // cmbCategoryFilter
            //
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(100, 62);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(220, 24);
            this.cmbCategoryFilter.TabIndex = 2;
            //
            // lblDate
            //
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(345, 65);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(45, 20);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date:";
            //
            // dtpDateFilter
            //
            this.dtpDateFilter.Enabled = false;
            this.dtpDateFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFilter.Location = new System.Drawing.Point(395, 61);
            this.dtpDateFilter.Name = "dtpDateFilter";
            this.dtpDateFilter.Size = new System.Drawing.Size(130, 24);
            this.dtpDateFilter.TabIndex = 4;
            //
            // chkFilterByDate
            //
            this.chkFilterByDate.AutoSize = true;
            this.chkFilterByDate.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkFilterByDate.Location = new System.Drawing.Point(535, 65);
            this.chkFilterByDate.Name = "chkFilterByDate";
            this.chkFilterByDate.Size = new System.Drawing.Size(60, 20);
            this.chkFilterByDate.TabIndex = 5;
            this.chkFilterByDate.Text = "Use";
            this.chkFilterByDate.UseVisualStyleBackColor = true;
            this.chkFilterByDate.CheckedChanged += new System.EventHandler(this.chkFilterByDate_CheckedChanged);
            //
            // btnSearch
            //
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(625, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 27);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // btnClearFilters
            //
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClearFilters.Location = new System.Drawing.Point(721, 60);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(90, 27);
            this.btnClearFilters.TabIndex = 7;
            this.btnClearFilters.Text = "Show All";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            //
            // lvEvents
            //
            this.lvEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle, this.colCategory, this.colDate, this.colLocation});
            this.lvEvents.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lvEvents.FullRowSelect = true;
            this.lvEvents.GridLines = true;
            this.lvEvents.HideSelection = false;
            this.lvEvents.Location = new System.Drawing.Point(25, 100);
            this.lvEvents.MultiSelect = false;
            this.lvEvents.Name = "lvEvents";
            this.lvEvents.Size = new System.Drawing.Size(786, 260);
            this.lvEvents.TabIndex = 8;
            this.lvEvents.UseCompatibleStateImageBehavior = false;
            this.lvEvents.View = System.Windows.Forms.View.Details;
            this.lvEvents.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvEvents_ItemSelectionChanged);
            //
            // colTitle
            //
            this.colTitle.Text = "Event Title";
            this.colTitle.Width = 280;
            //
            // colCategory
            //
            this.colCategory.Text = "Category";
            this.colCategory.Width = 160;
            //
            // colDate
            //
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            //
            // colLocation
            //
            this.colLocation.Text = "Location";
            this.colLocation.Width = 230;
            //
            // lblRecommended
            //
            this.lblRecommended.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblRecommended.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblRecommended.Location = new System.Drawing.Point(25, 370);
            this.lblRecommended.Name = "lblRecommended";
            this.lblRecommended.Size = new System.Drawing.Size(500, 22);
            this.lblRecommended.TabIndex = 9;
            this.lblRecommended.Text = "Recommended for you:";
            //
            // lstRecommendations
            //
            this.lstRecommendations.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 17;
            this.lstRecommendations.Location = new System.Drawing.Point(25, 396);
            this.lstRecommendations.Name = "lstRecommendations";
            this.lstRecommendations.Size = new System.Drawing.Size(786, 89);
            this.lstRecommendations.TabIndex = 10;
            //
            // lblRecentSearches
            //
            this.lblRecentSearches.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRecentSearches.ForeColor = System.Drawing.Color.DimGray;
            this.lblRecentSearches.Location = new System.Drawing.Point(25, 500);
            this.lblRecentSearches.Name = "lblRecentSearches";
            this.lblRecentSearches.Size = new System.Drawing.Size(380, 38);
            this.lblRecentSearches.TabIndex = 12;
            this.lblRecentSearches.Text = "Recent searches: none yet";
            this.lblRecentSearches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnNextAnnouncement
            //
            this.btnNextAnnouncement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextAnnouncement.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNextAnnouncement.Location = new System.Drawing.Point(411, 500);
            this.btnNextAnnouncement.Name = "btnNextAnnouncement";
            this.btnNextAnnouncement.Size = new System.Drawing.Size(200, 38);
            this.btnNextAnnouncement.TabIndex = 13;
            this.btnNextAnnouncement.Text = "Next Announcement";
            this.btnNextAnnouncement.UseVisualStyleBackColor = true;
            this.btnNextAnnouncement.Click += new System.EventHandler(this.btnNextAnnouncement_Click);
            //
            // btnBack
            //
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBack.Location = new System.Drawing.Point(621, 500);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(190, 38);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // LocalEventsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(836, 555);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNextAnnouncement);
            this.Controls.Add(this.lblRecentSearches);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.lblRecommended);
            this.Controls.Add(this.lvEvents);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.chkFilterByDate);
            this.Controls.Add(this.dtpDateFilter);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbCategoryFilter);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services Application - Local Events and Announcements";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDateFilter;
        private System.Windows.Forms.CheckBox chkFilterByDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.ListView lvEvents;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.Label lblRecommended;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblRecentSearches;
        private System.Windows.Forms.Button btnNextAnnouncement;
    }
}
