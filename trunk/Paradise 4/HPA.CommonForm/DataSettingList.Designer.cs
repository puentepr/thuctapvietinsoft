namespace HPA.CommonForm
{
    partial class DataSettingList
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
            this.grdTableEditor = new DevExpress.XtraGrid.GridControl();
            this.grvTableEditor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtFilter = new DevExpress.XtraEditors.TextEdit();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTableEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTableEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFWCommand
            // 
            this.pnlFWCommand.Size = new System.Drawing.Size(471, 38);
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
            this.btnFWSave.LookAndFeel.SkinName = "Blue";
            this.btnFWSave.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFWSave.Visible = false;
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
            this.pnlFWClose.Location = new System.Drawing.Point(320, 0);
            // 
            // btnFWClose
            // 
            this.btnFWClose.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWClose.Appearance.ForeColor = System.Drawing.SystemColors.MenuText;
            this.btnFWClose.Appearance.Options.UseFont = true;
            this.btnFWClose.Appearance.Options.UseForeColor = true;
            this.btnFWClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFWClose.LookAndFeel.SkinName = "Blue";
            this.btnFWClose.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // lblFWDecorateingLine
            // 
            this.lblFWDecorateingLine.Size = new System.Drawing.Size(471, 2);
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
            // grdTableEditor
            // 
            this.grdTableEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTableEditor.EmbeddedNavigator.Name = "";
            this.grdTableEditor.FormsUseDefaultLookAndFeel = false;
            this.grdTableEditor.Location = new System.Drawing.Point(0, 36);
            this.grdTableEditor.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdTableEditor.MainView = this.grvTableEditor;
            this.grdTableEditor.Name = "grdTableEditor";
            this.grdTableEditor.Size = new System.Drawing.Size(471, 469);
            this.grdTableEditor.TabIndex = 1;
            this.grdTableEditor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTableEditor});
            this.grdTableEditor.DoubleClick += new System.EventHandler(this.grdTableEditor_DoubleClick);
            this.grdTableEditor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdTableEditor_KeyUp);
            // 
            // grvTableEditor
            // 
            this.grvTableEditor.GridControl = this.grdTableEditor;
            this.grvTableEditor.Name = "grvTableEditor";
            this.grvTableEditor.OptionsSelection.MultiSelect = true;
            this.grvTableEditor.OptionsView.ColumnAutoWidth = false;
            this.grvTableEditor.OptionsView.ShowGroupPanel = false;
            this.grvTableEditor.GotFocus += new System.EventHandler(this.grvTableEditor_GotFocus);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(118, 10);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.MaxLength = 20;
            this.txtFilter.Size = new System.Drawing.Size(350, 20);
            this.txtFilter.TabIndex = 54;
            this.txtFilter.EditValueChanged += new System.EventHandler(this.txtFilter_EditValueChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(58, 13);
            this.lblSearch.TabIndex = 55;
            this.lblSearch.Text = "First name:";
            // 
            // DataSettingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFWClose;
            this.ClientSize = new System.Drawing.Size(471, 545);
            this.ControlBox = false;
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.grdTableEditor);
            this.Name = "DataSettingList";
            this.Text = "";
            this.Controls.SetChildIndex(this.lblFWDecorateingLine, 0);
            this.Controls.SetChildIndex(this.pnlFWCommand, 0);
            this.Controls.SetChildIndex(this.grdTableEditor, 0);
            this.Controls.SetChildIndex(this.lblSearch, 0);
            this.Controls.SetChildIndex(this.txtFilter, 0);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTableEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTableEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdTableEditor;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTableEditor;
        private DevExpress.XtraEditors.TextEdit txtFilter;
        private System.Windows.Forms.Label lblSearch;
    }
}