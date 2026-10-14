using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Main menu shown on startup. Report Issues (Part 1) and Local Events
    /// and Announcements (Part 2) are enabled; Service Request Status is
    /// disabled until the PoE task.
    /// </summary>
    public partial class MainMenuForm : Form
    {
        private readonly User _currentUser;

        /// <summary>True when the user chose Log Out (Program.cs then shows the login screen again).</summary>
        public bool LoggedOut { get; private set; }

        public MainMenuForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            lblWelcome.Text = "Welcome, " + (_currentUser != null ? _currentUser.FullName : "Resident") + "!";
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
            using (var eventsForm = new LocalEventsForm())
            {
                this.Hide();
                eventsForm.ShowDialog();
                this.Show();
            }
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "This feature will be available in a future update.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to log out?",
                "Confirm Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                LoggedOut = true;
                this.Close();
            }
        }
    }
}
