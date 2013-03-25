namespace HPA.Setting
{
    partial class DynamicUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdDynamic = new DevExpress.XtraGrid.GridControl();
            this.grvDynamic = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rpeDateTimeMask = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.rpeNumberMask = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDynamic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeDateTimeMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeDateTimeMask.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeNumberMask)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseFont = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            // 
            // btnReload
            // 
            this.btnReload.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Appearance.Options.UseFont = true;
            // 
            // btnExport
            // 
            this.btnExport.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Appearance.Options.UseFont = true;
            // 
            // grdDynamic
            // 
            this.grdDynamic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDynamic.Location = new System.Drawing.Point(0, 0);
            this.grdDynamic.MainView = this.grvDynamic;
            this.grdDynamic.Name = "grdDynamic";
            this.grdDynamic.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpeDateTimeMask,
            this.rpeNumberMask});
            this.grdDynamic.Size = new System.Drawing.Size(1000, 653);
            this.grdDynamic.TabIndex = 1;
            this.grdDynamic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDynamic});
            // 
            // grvDynamic
            // 
            this.grvDynamic.GridControl = this.grdDynamic;
            this.grvDynamic.Name = "grvDynamic";
            this.grvDynamic.OptionsFind.FindDelay = 400;
            this.grvDynamic.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.grvDynamic.OptionsFind.SearchInPreview = true;
            this.grvDynamic.OptionsFind.ShowClearButton = false;
            this.grvDynamic.OptionsView.ColumnAutoWidth = false;
            this.grvDynamic.OptionsView.ShowFooter = true;
            this.grvDynamic.OptionsView.ShowGroupPanel = false;
            this.grvDynamic.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvDynamic_CellValueChanged);
            // 
            // rpeDateTimeMask
            // 
            this.rpeDateTimeMask.AutoHeight = false;
            this.rpeDateTimeMask.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpeDateTimeMask.Name = "rpeDateTimeMask";
            this.rpeDateTimeMask.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // rpeNumberMask
            // 
            this.rpeNumberMask.AutoHeight = false;
            this.rpeNumberMask.Mask.EditMask = "n";
            this.rpeNumberMask.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rpeNumberMask.Mask.UseMaskAsDisplayFormat = true;
            this.rpeNumberMask.Name = "rpeNumberMask";
            // 
            // DynamicUserControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdDynamic);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "DynamicUserControl";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Controls.SetChildIndex(this.grdDynamic, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdDynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDynamic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeDateTimeMask.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeDateTimeMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpeNumberMask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdDynamic;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDynamic;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rpeDateTimeMask;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpeNumberMask;
    }
}
