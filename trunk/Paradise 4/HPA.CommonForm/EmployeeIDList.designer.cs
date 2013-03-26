namespace HPA.CommonForm
{
    partial class EmployeeIDList
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
            this.cbxEmployeeStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.lblEmployeeStatus = new System.Windows.Forms.Label();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.lblFullName = new System.Windows.Forms.Label();
            this.grvEmployeeID = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdEmployeeIDList = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlFWCommand.SuspendLayout();
            this.pnlFWClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxEmployeeStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeIDList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFWCommand
            // 
            this.pnlFWCommand.Location = new System.Drawing.Point(0, 502);
            this.pnlFWCommand.Size = new System.Drawing.Size(350, 38);
            // 
            // btnFWDelete
            // 
            this.btnFWDelete.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWDelete.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWDelete.Appearance.Options.UseFont = true;
            this.btnFWDelete.Appearance.Options.UseForeColor = true;
            this.btnFWDelete.LookAndFeel.SkinName = "Blue";
            this.btnFWDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnFWSave
            // 
            this.btnFWSave.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWSave.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWSave.Appearance.Options.UseFont = true;
            this.btnFWSave.Appearance.Options.UseForeColor = true;
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
            // 
            // pnlFWClose
            // 
            this.pnlFWClose.Location = new System.Drawing.Point(199, 0);
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
            this.lblFWDecorateingLine.Location = new System.Drawing.Point(0, 540);
            this.lblFWDecorateingLine.Size = new System.Drawing.Size(350, 2);
            // 
            // btnFWReset
            // 
            this.btnFWReset.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFWReset.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFWReset.Appearance.Options.UseFont = true;
            this.btnFWReset.Appearance.Options.UseForeColor = true;
            this.btnFWReset.Location = new System.Drawing.Point(151, 8);
            this.btnFWReset.LookAndFeel.SkinName = "Blue";
            this.btnFWReset.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Location = new System.Drawing.Point(86, 8);
            this.btnExport.LookAndFeel.SkinName = "Blue";
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // cbxEmployeeStatus
            // 
            this.cbxEmployeeStatus.Location = new System.Drawing.Point(100, 34);
            this.cbxEmployeeStatus.Name = "cbxEmployeeStatus";
            this.cbxEmployeeStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxEmployeeStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeStatusID", "EmployeeStatusID", 50),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeStatus", "Status", 120)});
            this.cbxEmployeeStatus.Properties.DisplayMember = "EmployeeStatus";
            this.cbxEmployeeStatus.Properties.LookAndFeel.SkinName = "Blue";
            this.cbxEmployeeStatus.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cbxEmployeeStatus.Properties.NullText = "";
            this.cbxEmployeeStatus.Properties.ValueMember = "EmployeeStatusID";
            this.cbxEmployeeStatus.Size = new System.Drawing.Size(248, 20);
            this.cbxEmployeeStatus.TabIndex = 3;
            this.cbxEmployeeStatus.EditValueChanged += new System.EventHandler(this.cbxEmployeeStatus_EditValueChanged);
            // 
            // lblEmployeeStatus
            // 
            this.lblEmployeeStatus.AutoSize = true;
            this.lblEmployeeStatus.Location = new System.Drawing.Point(5, 37);
            this.lblEmployeeStatus.Name = "lblEmployeeStatus";
            this.lblEmployeeStatus.Size = new System.Drawing.Size(48, 13);
            this.lblEmployeeStatus.TabIndex = 13;
            this.lblEmployeeStatus.Text = "StatusID";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(100, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.MaxLength = 50;
            this.txtSearch.Size = new System.Drawing.Size(247, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.EditValueChanged += new System.EventHandler(this.txtFullName_EditValueChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(5, 11);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(58, 13);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "First name:";
            // 
            // grvEmployeeID
            // 
            this.grvEmployeeID.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeID,
            this.colLastName,
            this.colFirstName,
            this.colTitle});
            this.grvEmployeeID.GridControl = this.grdEmployeeIDList;
            this.grvEmployeeID.Name = "grvEmployeeID";
            this.grvEmployeeID.OptionsBehavior.AllowIncrementalSearch = true;
            this.grvEmployeeID.OptionsView.ShowGroupPanel = false;
            // 
            // colEmployeeID
            // 
            this.colEmployeeID.Caption = "Employee ID";
            this.colEmployeeID.FieldName = "EmployeeID";
            this.colEmployeeID.Name = "colEmployeeID";
            this.colEmployeeID.OptionsColumn.AllowEdit = false;
            this.colEmployeeID.OptionsColumn.AllowMove = false;
            this.colEmployeeID.OptionsColumn.ReadOnly = true;
            this.colEmployeeID.Visible = true;
            this.colEmployeeID.VisibleIndex = 0;
            this.colEmployeeID.Width = 66;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "LastName";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.OptionsColumn.AllowEdit = false;
            this.colLastName.OptionsColumn.ReadOnly = true;
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 1;
            this.colLastName.Width = 125;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "FirstName";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 2;
            this.colFirstName.Width = 45;
            // 
            // colTitle
            // 
            this.colTitle.Caption = "gridColumn2";
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 3;
            this.colTitle.Width = 94;
            // 
            // grdEmployeeIDList
            // 
            this.grdEmployeeIDList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEmployeeIDList.EmbeddedNavigator.Name = "";
            this.grdEmployeeIDList.FormsUseDefaultLookAndFeel = false;
            this.grdEmployeeIDList.Location = new System.Drawing.Point(-1, 60);
            this.grdEmployeeIDList.LookAndFeel.SkinName = "Blue";
            this.grdEmployeeIDList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdEmployeeIDList.MainView = this.grvEmployeeID;
            this.grdEmployeeIDList.Name = "grdEmployeeIDList";
            this.grdEmployeeIDList.Size = new System.Drawing.Size(351, 482);
            this.grdEmployeeIDList.TabIndex = 30;
            this.grdEmployeeIDList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEmployeeID,
            this.gridView2});
            this.grdEmployeeIDList.DoubleClick += new System.EventHandler(this.grdEmployeeIDList_DoubleClick);
            this.grdEmployeeIDList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdEmployeeIDList_KeyUp);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridView2.GridControl = this.grdEmployeeIDList;
            this.gridView2.Name = "gridView2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // EmployeeIDList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 542);
            this.Controls.Add(this.grdEmployeeIDList);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbxEmployeeStatus);
            this.Controls.Add(this.lblEmployeeStatus);
            this.Name = "EmployeeIDList";
            this.Text = "";
            this.Controls.SetChildIndex(this.lblEmployeeStatus, 0);
            this.Controls.SetChildIndex(this.cbxEmployeeStatus, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.lblFullName, 0);
            this.Controls.SetChildIndex(this.lblFWDecorateingLine, 0);
            this.Controls.SetChildIndex(this.pnlFWCommand, 0);
            this.Controls.SetChildIndex(this.grdEmployeeIDList, 0);
            this.pnlFWCommand.ResumeLayout(false);
            this.pnlFWClose.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbxEmployeeStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEmployeeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmployeeIDList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cbxEmployeeStatus;
        private System.Windows.Forms.Label lblEmployeeStatus;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private System.Windows.Forms.Label lblFullName;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.GridControl grdEmployeeIDList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
    }
}