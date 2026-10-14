using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Read-only list of every issue reported during this session, so the
    /// user can confirm their reports were captured. Built in code (no
    /// designer file) to keep it small.
    /// </summary>
    public class ReportedIssuesForm : Form
    {
        public ReportedIssuesForm()
        {
            Text = "Municipal Services Application - Reported Issues";
            ClientSize = new Size(760, 400);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.WhiteSmoke;

            var title = new Label
            {
                Text = "Reported Issues",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 51, 102),
                Location = new Point(20, 15),
                Size = new Size(400, 35)
            };

            var list = new ListView
            {
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 9.5F),
                Location = new Point(20, 60),
                Size = new Size(720, 280)
            };
            list.Columns.Add("Ref", 50);
            list.Columns.Add("Date", 130);
            list.Columns.Add("Location", 140);
            list.Columns.Add("Category", 140);
            list.Columns.Add("Description", 180);
            list.Columns.Add("Files", 50);

            foreach (var issue in IssueRepository.Issues)
            {
                var item = new ListViewItem(issue.Id.ToString());
                item.SubItems.Add(issue.DateReported.ToString("dd MMM yyyy HH:mm"));
                item.SubItems.Add(issue.Location);
                item.SubItems.Add(issue.Category);
                item.SubItems.Add(issue.Description);
                item.SubItems.Add(issue.AttachmentPaths.Count.ToString());
                list.Items.Add(item);
            }

            if (list.Items.Count == 0)
            {
                list.Items.Add(new ListViewItem("-")).SubItems.Add("No issues have been reported yet.");
            }

            var close = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 10.5F),
                Location = new Point(620, 352),
                Size = new Size(120, 36),
                FlatStyle = FlatStyle.Flat
            };
            close.Click += (s, e) => Close();

            Controls.Add(title);
            Controls.Add(list);
            Controls.Add(close);
        }
    }
}
