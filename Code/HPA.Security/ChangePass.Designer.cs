namespace HPA.Security
{
    partial class ChangePass
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
            this.components = new System.ComponentModel.Container();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.txtMKcu = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.btnFWSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPass1
            // 
            this.txtPass1.Location = new System.Drawing.Point(140, 49);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(172, 20);
            this.txtPass1.TabIndex = 8;
            // 
            // txtMKcu
            // 
            this.txtMKcu.Location = new System.Drawing.Point(140, 17);
            this.txtMKcu.Name = "txtMKcu";
            this.txtMKcu.Size = new System.Drawing.Size(172, 20);
            this.txtMKcu.TabIndex = 7;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblNewPassword.Location = new System.Drawing.Point(7, 49);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(71, 13);
            this.lblNewPassword.TabIndex = 6;
            this.lblNewPassword.Text = "Mật khẩu mới";
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblOldPassword.Location = new System.Drawing.Point(7, 17);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(67, 13);
            this.lblOldPassword.TabIndex = 5;
            this.lblOldPassword.Text = "Mật khẩu cũ";
            // 
            // txtPass2
            // 
            this.txtPass2.Location = new System.Drawing.Point(139, 82);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(172, 20);
            this.txtPass2.TabIndex = 10;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmPassword.Location = new System.Drawing.Point(6, 82);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(119, 13);
            this.lblConfirmPassword.TabIndex = 9;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu mới";
            // 
            // btnFWSave
            // 
            this.btnFWSave.Location = new System.Drawing.Point(140, 122);
            this.btnFWSave.Name = "btnFWSave";
            this.btnFWSave.Size = new System.Drawing.Size(88, 23);
            this.btnFWSave.TabIndex = 11;
            this.btnFWSave.Text = "Đổi mật khẩu";
            this.btnFWSave.UseVisualStyleBackColor = true;
            this.btnFWSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(234, 122);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 156);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFWSave);
            this.Controls.Add(this.txtPass2);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.txtMKcu);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Name = "ChangePass";
            this.Text = "ChangePass";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPass1;
        private System.Windows.Forms.TextBox txtMKcu;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.TextBox txtPass2;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnFWSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}