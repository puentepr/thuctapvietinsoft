namespace HPA.FORMDESIGNER
{
    partial class FormDesigner
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
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.pnlToolBox = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.designSurfacePanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlToolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.propertyGrid.CommandsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid.Location = new System.Drawing.Point(816, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(192, 729);
            this.propertyGrid.TabIndex = 3;
            this.propertyGrid.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // pnlToolBox
            // 
            this.pnlToolBox.BackColor = System.Drawing.SystemColors.Window;
            this.pnlToolBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolBox.Controls.Add(this.labelControl1);
            this.pnlToolBox.Controls.Add(this.pictureBox1);
            this.pnlToolBox.Controls.Add(this.groupBox1);
            this.pnlToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlToolBox.Location = new System.Drawing.Point(0, 0);
            this.pnlToolBox.Name = "pnlToolBox";
            this.pnlToolBox.Size = new System.Drawing.Size(108, 455);
            this.pnlToolBox.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 77);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // designSurfacePanel
            // 
            this.designSurfacePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.designSurfacePanel.BackColor = System.Drawing.SystemColors.Window;
            this.designSurfacePanel.Location = new System.Drawing.Point(105, 0);
            this.designSurfacePanel.Name = "designSurfacePanel";
            this.designSurfacePanel.Size = new System.Drawing.Size(710, 729);
            this.designSurfacePanel.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlToolBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(108, 729);
            this.splitContainer1.SplitterDistance = 455;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "simpleButton1";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "labelControl1";
            // 
            // FormDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.designSurfacePanel);
            this.Controls.Add(this.propertyGrid);
            this.LookAndFeel.SkinName = "Seven";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "FormDesigner";
            this.Text = "FormDesigner";
            this.Load += new System.EventHandler(this.FormDesigner_Load);
            this.pnlToolBox.ResumeLayout(false);
            this.pnlToolBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Panel pnlToolBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel designSurfacePanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;


    }
}