namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.panelLeft = new DevExpress.XtraEditors.PanelControl();
            this.textSearch = new DevExpress.XtraEditors.TextEdit();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.panelTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSearch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Appearance.BackColor = System.Drawing.Color.White;
            this.panelLeft.Appearance.Options.UseBackColor = true;
            this.panelLeft.Controls.Add(this.textSearch);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelLeft.Location = new System.Drawing.Point(562, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(281, 540);
            this.panelLeft.TabIndex = 2;
            this.panelLeft.Visible = false;
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(5, 32);
            this.textSearch.Name = "textSearch";
            this.textSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSearch.Properties.Appearance.Options.UseFont = true;
            this.textSearch.Size = new System.Drawing.Size(264, 26);
            this.textSearch.TabIndex = 0;
            this.textSearch.EditValueChanged += new System.EventHandler(this.textSearch_EditValueChanged);
            this.textSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSearch_KeyDown);
            // 
            // tileControl1
            // 
            this.tileControl1.AllowSelectedItem = true;
            this.tileControl1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.FocusRectColor = System.Drawing.Color.Red;
            this.tileControl1.Location = new System.Drawing.Point(0, 0);
            this.tileControl1.MaxId = 19;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.ShowGroupText = true;
            this.tileControl1.Size = new System.Drawing.Size(562, 540);
            this.tileControl1.TabIndex = 6;
            this.tileControl1.Text = "tileControl1";
            // 
            // panelTop
            // 
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(562, 70);
            this.panelTop.TabIndex = 7;
            this.panelTop.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 540);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.tileControl1);
            this.Controls.Add(this.panelLeft);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Vietinsoft";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textSearch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelLeft;
        private DevExpress.XtraEditors.TextEdit textSearch;
        private DevExpress.XtraEditors.TileControl tileControl1;
        private System.Windows.Forms.Panel panelTop;

    }
}

