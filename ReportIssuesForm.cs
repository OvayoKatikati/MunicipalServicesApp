using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{

 
    public partial class ReportIssuesForm : Form
    {
        // Holds the file paths of any media the user attaches to this report.
        private readonly List<string> _attachedFiles = new List<string>();

        public ReportIssuesForm()
        {
            InitializeComponent();
        }

        // Opens a file dialog so the user can attach one or more images or
        // documents that support their issue report.
       
        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _attachedFiles.AddRange(openFileDialog1.FileNames);
                UpdateAttachmentLabel();
                UpdateEngagement();
            }
        }

        private void UpdateAttachmentLabel()
        {
            if (_attachedFiles.Count == 0)
            {
                lblAttachments.Text = "No files attached.";
            }
            else
            {
                lblAttachments.Text = _attachedFiles.Count + " file(s) attached: " +
                    string.Join(", ", _attachedFiles.Select(System.IO.Path.GetFileName));
            }
        }

       
        // progress bar updates live as the user completes the form.
      
        private void InputField_Changed(object sender, EventArgs e)
        {
            UpdateEngagement();
        }

        
        // Calculates how much of the report has been completed and updates
       
        private void UpdateEngagement()
        {
            int fieldsCompleted = 0;
            const int totalFields = 4; 
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) fieldsCompleted++;
            if (cmbCategory.SelectedIndex != -1) fieldsCompleted++;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) fieldsCompleted++;
            if (_attachedFiles.Count > 0) fieldsCompleted++;

            int percentage = (fieldsCompleted * 100) / totalFields;
            progressEngagement.Value = percentage;

            if (percentage == 0)
            {
                lblEngagement.Text = "Fill in the form to help us resolve issues in your community faster!";
            }
            else if (percentage < 100)
            {
                lblEngagement.Text = "Great start! You're " + percentage + "% of the way to submitting your report.";
            }
            else
            {
                lblEngagement.Text = "All set! Your report is ready to submit. Thank you for helping your community.";
            }
        }

        // Validates the form, stores the new issue in the shared repository,
        // gives the user feedback, and resets the form for the next report.
    
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            string category = cmbCategory.SelectedItem.ToString();

            IssueRepository.AddIssue(
                txtLocation.Text.Trim(),
                category,
                rtbDescription.Text.Trim(),
                new List<string>(_attachedFiles));

            MessageBox.Show(
                "Thank you! Your issue has been reported successfully.\n\nReference number: " +
                IssueRepository.Count,
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ResetForm();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return false;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category for the issue.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please provide a description of the issue.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            _attachedFiles.Clear();
            UpdateAttachmentLabel();
            UpdateEngagement();
            txtLocation.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
