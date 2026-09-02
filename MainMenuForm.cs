using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    /// <summary>
    /// The application's main menu. Presents the three top-level tasks required
    /// by the specification. Only "Report Issues" is implemented in Part 1;
    /// "Local Events and Announcements" and "Service Request Status" are
    /// disabled and will be implemented in Part 2 and the PoE respectively.
    /// </summary>
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            using (var reportForm = new ReportIssuesForm())
            {
                this.Hide();
                reportForm.ShowDialog();
                this.Show();
            }
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            // Disabled for Part 1 - to be implemented in Part 2.
            MessageBox.Show(
                "This feature will be available in a future update.",
                "Coming Soon",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            // Disabled for Part 1 - to be implemented in the PoE.
            MessageBox.Show(
                "This feature will be available in a future update.",
                "Coming Soon",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
