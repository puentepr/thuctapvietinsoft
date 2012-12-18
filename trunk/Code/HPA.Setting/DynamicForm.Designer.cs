namespace HPA.Setting
{
    partial class DynamicForm
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
            // grdDynamic
            // 
            this.grdDynamic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDynamic.Location = new System.Drawing.Point(0, 0);
            this.grdDynamic.MainView = this.grvDynamic;
            this.grdDynamic.Name = "grdDynamic";
            this.grdDynamic.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpeDateTimeMask,
            this.rpeNumberMask});
            this.grdDynamic.Size = new System.Drawing.Size(984, 561);
            this.grdDynamic.TabIndex = 0;
            this.grdDynamic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDynamic});
            // 
            // grvDynamic
            // 
            this.grvDynamic.GridControl = this.grdDynamic;
            this.grvDynamic.Name = "grvDynamic";
            this.grvDynamic.OptionsFind.AlwaysVisible = true;
            this.grvDynamic.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.grvDynamic.OptionsFind.ShowCloseButton = false;
            this.grvDynamic.OptionsFind.ShowFindButton = false;
            this.grvDynamic.OptionsView.ShowFooter = true;
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
            this.rpeNumberMask.Name = "rpeNumberMask";
            // 
            // DynamicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.grdDynamic);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "DynamicForm";
            this.Text = "DynamicForm";
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