using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Entry screen. Toggles between Login and Register on one form. On a
    /// successful login it sets DialogResult.OK and closes; Program.cs then
    /// opens the main menu. Closing this form any other way exits the app.
    /// </summary>
    public partial class LoginForm : Form
    {
        private bool _isRegisterMode = false;

        public User LoggedInUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            ApplyMode();
        }

        private void ApplyMode()
        {
            lblError.Text = string.Empty;

            if (_isRegisterMode)
            {
                lblSubtitle.Text = "Create an Account";
                lblFullName.Visible = true;
                txtFullName.Visible = true;
                btnPrimaryAction.Text = "Register";
                lnkToggleMode.Text = "Already have an account? Log in";
            }
            else
            {
                lblSubtitle.Text = "Resident Login";
                lblFullName.Visible = false;
                txtFullName.Visible = false;
                btnPrimaryAction.Text = "Log In";
                lnkToggleMode.Text = "New resident? Create an account";
            }
        }

        private void lnkToggleMode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _isRegisterMode = !_isRegisterMode;
            ApplyMode();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void btnPrimaryAction_Click(object sender, EventArgs e)
        {
            if (_isRegisterMode) HandleRegister(); else HandleLogin();
        }

        private void HandleLogin()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter both a username and password.";
                return;
            }

            User user = UserRepository.Authenticate(username, password);

            if (user == null)
            {
                lblError.Text = "Incorrect username or password. Please try again.";
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            LoggedInUser = user;
            this.DialogResult = DialogResult.OK; // closes this form and returns control to Program.cs
        }

        private void HandleRegister()
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please enter a username and password.";
                return;
            }
            if (username.Length < 3)
            {
                lblError.Text = "Username must be at least 3 characters long.";
                return;
            }
            if (password.Length < 6)
            {
                lblError.Text = "Password must be at least 6 characters long.";
                return;
            }
            if (UserRepository.UserExists(username))
            {
                lblError.Text = "That username is already taken. Please choose another.";
                return;
            }
            if (!UserRepository.Register(username, password, fullName))
            {
                lblError.Text = "Registration failed. Please try again.";
                return;
            }

            MessageBox.Show("Account created successfully! You can now log in.",
                "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _isRegisterMode = false;
            ApplyMode();
            txtUsername.Text = username;
            txtPassword.Clear();
            txtFullName.Clear();
            txtPassword.Focus();
        }
    }
}
