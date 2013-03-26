namespace HPA.SystemAdmin
{
    partial class ChangePassword
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
            this.xteRetypePass = new System.Windows.Forms.TextBox();
            this.xteNewPass = new System.Windows.Forms.TextBox();
            this.xteOldPass = new System.Windows.Forms.TextBox();
            this.xteUserID = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFWCommand
            // 
            this.pnlFWCommand.Location = new System.Drawing.Point(0, 138);
            this.pnlFWCommand.Size = new System.Drawing.Size(316, 38);
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWDelete.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.LookAndFeel.SkinName = "Blue";
            this.btnFWDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWDelete.Visible = false;
            // 
            // btnFWSave
            // 
            this.btnFWSave.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWSave.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWSave.Appearance.Options.UseFont = true;
            this.btnFWSave.Appearance.Options.UseForeColor = true;
            this.btnFWSave.Location = new System.Drawing.Point(4, 6);
            this.btnFWSave.LookAndFeel.SkinName = "Blue";
            this.btnFWSave.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnFWAdd
            // 
            this.btnFWAdd.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWAdd.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWAdd.Appearance.Options.UseFont = true;
            this.btnFWAdd.Appearance.Options.UseForeColor = true;
            this.btnFWAdd.LookAndFeel.SkinName = "Blue";
            this.btnFWAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWAdd.Visible = false;
            // 
            // pnlFWClose
            // 
            this.pnlFWClose.Location = new System.Drawing.Point(165, 0);
            this.pnlFWClose.Size = new System.Drawing.Size(151, 38);
            // 
            // btnFWClose
            // 
            this.btnFWClose.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWClose.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnFWClose.Appearance.Options.UseFont = true;
            this.btnFWClose.Appearance.Options.UseForeColor = true;
            this.btnFWClose.LookAndFeel.SkinName = "Blue";
            this.btnFWClose.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // lblFWDecorateingLine
            // 
            this.lblFWDecorateingLine.Location = new System.Drawing.Point(0, 176);
            this.lblFWDecorateingLine.Size = new System.Drawing.Size(316, 2);
            // 
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWReset.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            this.btnFWReset.LookAndFeel.SkinName = "Blue";
            this.btnFWReset.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWReset.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.LookAndFeel.SkinName = "Blue";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Visible = false;
            // 
            // xteRetypePass
            // 
            this.xteRetypePass.Location = new System.Drawing.Point(123, 99);
            this.xteRetypePass.MaxLength = 50;
            this.xteRetypePass.Name = "xteRetypePass";
            this.xteRetypePass.PasswordChar = '*';
            this.xteRetypePass.Size = new System.Drawing.Size(181, 21);
            this.xteRetypePass.TabIndex = 8;
            this.xteRetypePass.UseSystemPasswordChar = true;
            // 
            // xteNewPass
            // 
            this.xteNewPass.Location = new System.Drawing.Point(123, 70);
            this.xteNewPass.MaxLength = 50;
            this.xteNewPass.Name = "xteNewPass";
            this.xteNewPass.PasswordChar = '*';
            this.xteNewPass.Size = new System.Drawing.Size(181, 21);
            this.xteNewPass.TabIndex = 6;
            this.xteNewPass.UseSystemPasswordChar = true;
            // 
            // xteOldPass
            // 
            this.xteOldPass.Location = new System.Drawing.Point(123, 40);
            this.xteOldPass.MaxLength = 50;
            this.xteOldPass.Name = "xteOldPass";
            this.xteOldPass.PasswordChar = '*';
            this.xteOldPass.Size = new System.Drawing.Size(181, 21);
            this.xteOldPass.TabIndex = 4;
            this.xteOldPass.UseSystemPasswordChar = true;
            // 
            // xteUserID
            // 
            this.xteUserID.Location = new System.Drawing.Point(123, 12);
            this.xteUserID.MaxLength = 20;
            this.xteUserID.Name = "xteUserID";
            this.xteUserID.Size = new System.Drawing.Size(181, 21);
            this.xteUserID.TabIndex = 2;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblConfirmPassword.Location = new System.Drawing.Point(9, 102);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(120, 18);
            this.lblConfirmPassword.TabIndex = 7;
            this.lblConfirmPassword.Text = "Confirm password:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNewPassword.Location = new System.Drawing.Point(9, 73);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(104, 18);
            this.lblNewPassword.TabIndex = 5;
            this.lblNewPassword.Text = "New password:";
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOldPassword.Location = new System.Drawing.Point(9, 40);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(104, 18);
            this.lblOldPassword.TabIndex = 3;
            this.lblOldPassword.Text = "Old password:";
            // 
            // lblUserID
            // 
            this.lblUserID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUserID.Location = new System.Drawing.Point(9, 12);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(104, 18);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "User ID:";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 178);
            this.Controls.Add(this.xteRetypePass);
            this.Controls.Add(this.xteNewPass);
            this.Controls.Add(this.xteOldPass);
            this.Controls.Add(this.xteUserID);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.lblUserID);
            this.LookAndFeel.SkinName = "Seven";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.Controls.SetChildIndex(this.lblFWDecorateingLine, 0);
            this.Controls.SetChildIndex(this.pnlFWCommand, 0);
            this.Controls.SetChildIndex(this.lblUserID, 0);
            this.Controls.SetChildIndex(this.lblOldPassword, 0);
            this.Controls.SetChildIndex(this.lblNewPassword, 0);
            this.Controls.SetChildIndex(this.lblConfirmPassword, 0);
            this.Controls.SetChildIndex(this.xteUserID, 0);
            this.Controls.SetChildIndex(this.xteOldPass, 0);
            this.Controls.SetChildIndex(this.xteNewPass, 0);
            this.Controls.SetChildIndex(this.xteRetypePass, 0);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xteRetypePass;
        private System.Windows.Forms.TextBox xteNewPass;
        private System.Windows.Forms.TextBox xteOldPass;
        private System.Windows.Forms.TextBox xteUserID;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Label lblUserID;
    }
}