namespace MunicipalServicesApp
{
    partial class LoginForm
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
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btnPrimaryAction = new System.Windows.Forms.Button();
            this.lnkToggleMode = new System.Windows.Forms.LinkLabel();
            this.lblError = new System.Windows.Forms.Label();
            this.lblDemoHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102);
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(380, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Municipal Services Application";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.lblSubtitle.Location = new System.Drawing.Point(30, 70);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(380, 28);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Resident Login";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFullName.Location = new System.Drawing.Point(40, 115);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(120, 20);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Full Name:";
            this.lblFullName.Visible = false;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(40, 137);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(340, 25);
            this.txtFullName.TabIndex = 3;
            this.txtFullName.Visible = false;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(40, 170);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(120, 20);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username:";
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(40, 192);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(340, 25);
            this.txtUsername.TabIndex = 5;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(40, 228);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(120, 20);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(40, 250);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(340, 25);
            this.txtPassword.TabIndex = 7;
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkShowPassword.Location = new System.Drawing.Point(40, 282);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(107, 19);
            this.chkShowPassword.TabIndex = 8;
            this.chkShowPassword.Text = "Show password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            this.btnPrimaryAction.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnPrimaryAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimaryAction.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrimaryAction.ForeColor = System.Drawing.Color.White;
            this.btnPrimaryAction.Location = new System.Drawing.Point(40, 315);
            this.btnPrimaryAction.Name = "btnPrimaryAction";
            this.btnPrimaryAction.Size = new System.Drawing.Size(340, 42);
            this.btnPrimaryAction.TabIndex = 9;
            this.btnPrimaryAction.Text = "Log In";
            this.btnPrimaryAction.UseVisualStyleBackColor = false;
            this.btnPrimaryAction.Click += new System.EventHandler(this.btnPrimaryAction_Click);
            this.lnkToggleMode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lnkToggleMode.Location = new System.Drawing.Point(40, 368);
            this.lnkToggleMode.Name = "lnkToggleMode";
            this.lnkToggleMode.Size = new System.Drawing.Size(340, 22);
            this.lnkToggleMode.TabIndex = 10;
            this.lnkToggleMode.TabStop = true;
            this.lnkToggleMode.Text = "New resident? Create an account";
            this.lnkToggleMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkToggleMode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkToggleMode_LinkClicked);
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.Location = new System.Drawing.Point(40, 396);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(340, 40);
            this.lblError.TabIndex = 11;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDemoHint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblDemoHint.ForeColor = System.Drawing.Color.Gray;
            this.lblDemoHint.Location = new System.Drawing.Point(40, 438);
            this.lblDemoHint.Name = "lblDemoHint";
            this.lblDemoHint.Size = new System.Drawing.Size(340, 36);
            this.lblDemoHint.TabIndex = 12;
            this.lblDemoHint.Text = "Demo account - Username: resident   Password: Password1";
            this.lblDemoHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AcceptButton = this.btnPrimaryAction;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(440, 490);
            this.Controls.Add(this.lblDemoHint);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lnkToggleMode);
            this.Controls.Add(this.btnPrimaryAction);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services Application - Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnPrimaryAction;
        private System.Windows.Forms.LinkLabel lnkToggleMode;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblDemoHint;
    }
}
