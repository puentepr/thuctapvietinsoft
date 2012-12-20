namespace WindowsFormsApplication3
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame1 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame2 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame3 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.metroUIView1 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.MetroUIView(this.components);
            this.tileContainer1 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.TileContainer(this.components);
            this.pageGroup1 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.PageGroup(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Document(this.components);
            this.document2 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Document(this.components);
            this.document3 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Document(this.components);
            this.document4 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Document(this.components);
            this.document1Tile = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile(this.components);
            this.document2Tile = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile(this.components);
            this.document3Tile = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile(this.components);
            this.document4Tile = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile(this.components);
            this.document5Tile = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile(this.components);
            this.page1 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Page(this.components);
            this.document5 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Document(this.components);
            this.document6Tile = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile(this.components);
            this.page2 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Page(this.components);
            this.document6 = new DevExpress.XtraBars.Docking2010.Views.MetroUI.Document(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroUIView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.page1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document6Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.page2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document6)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.metroUIView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.metroUIView1});
            // 
            // metroUIView1
            // 
            this.metroUIView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.MetroUI.IContentContainer[] {
            this.tileContainer1,
            this.pageGroup1,
            this.page1,
            this.page2});
            this.metroUIView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1,
            this.document2,
            this.document3,
            this.document4,
            this.document5,
            this.document6});
            this.metroUIView1.Tiles.AddRange(new DevExpress.XtraBars.Docking2010.Views.MetroUI.BaseTile[] {
            this.document1Tile,
            this.document2Tile,
            this.document3Tile,
            this.document4Tile,
            this.document5Tile,
            this.document6Tile});
            this.metroUIView1.QueryControl += new DevExpress.XtraBars.Docking2010.Views.QueryControlEventHandler(this.metroUIView1_QueryControl);
            // 
            // tileContainer1
            // 
            this.tileContainer1.ActivationTarget = this.pageGroup1;
            this.tileContainer1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.MetroUI.BaseTile[] {
            this.document1Tile,
            this.document2Tile,
            this.document3Tile,
            this.document4Tile,
            this.document5Tile,
            this.document6Tile});
            // 
            // pageGroup1
            // 
            this.pageGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.MetroUI.Document[] {
            this.document1,
            this.document2,
            this.document3,
            this.document4});
            this.pageGroup1.Parent = this.tileContainer1;
            // 
            // document1
            // 
            this.document1.Caption = "document1";
            this.document1.ControlName = "document1";
            // 
            // document2
            // 
            this.document2.Caption = "document2";
            this.document2.ControlName = "document2";
            // 
            // document3
            // 
            this.document3.Caption = "document3";
            this.document3.ControlName = "document3";
            // 
            // document4
            // 
            this.document4.Caption = "document4";
            this.document4.ControlName = "document4";
            // 
            // document1Tile
            // 
            this.document1Tile.Appearances.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.document1Tile.Appearances.Normal.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.document1Tile.Appearances.Normal.Options.UseBackColor = true;
            this.document1Tile.Appearances.Normal.Options.UseFont = true;
            this.document1Tile.Document = this.document1;
            tileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.Text = "element1";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.document1Tile.Elements.Add(tileItemElement1);
            tileItemElement2.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement2.Text = "element1";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemFrame1.Elements.Add(tileItemElement2);
            tileItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement3.Text = "element1";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemElement4.Text = "element2";
            tileItemFrame2.Elements.Add(tileItemElement3);
            tileItemFrame2.Elements.Add(tileItemElement4);
            tileItemElement5.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement5.Text = "element1";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            tileItemFrame3.Elements.Add(tileItemElement5);
            this.document1Tile.Frames.Add(tileItemFrame1);
            this.document1Tile.Frames.Add(tileItemFrame2);
            this.document1Tile.Frames.Add(tileItemFrame3);
            this.document1Tile.Group = "Main";
            this.document1Tile.Properties.FrameAnimationInterval = 1000;
            this.document1Tile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.True;
            // 
            // document2Tile
            // 
            this.document2Tile.Appearances.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.document2Tile.Appearances.Normal.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.document2Tile.Appearances.Normal.Options.UseBackColor = true;
            this.document2Tile.Appearances.Normal.Options.UseFont = true;
            this.document2Tile.Document = this.document2;
            tileItemElement6.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Bottom;
            tileItemElement6.Text = "element1";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
            this.document2Tile.Elements.Add(tileItemElement6);
            this.document2Tile.Group = "Main";
            this.document2Tile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // document3Tile
            // 
            this.document3Tile.Document = this.document3;
            this.document3Tile.Group = "Main";
            this.document3Tile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // document4Tile
            // 
            this.document4Tile.Document = this.document4;
            this.document4Tile.Group = "Main";
            this.document4Tile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // document5Tile
            // 
            this.document5Tile.ActivationTarget = this.page1;
            this.document5Tile.Document = this.document5;
            this.document5Tile.Group = "Utils";
            this.document5Tile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // page1
            // 
            this.page1.Document = this.document5;
            this.page1.Parent = this.tileContainer1;
            // 
            // document5
            // 
            this.document5.Caption = "document5";
            this.document5.ControlName = "document5";
            // 
            // document6Tile
            // 
            this.document6Tile.ActivationTarget = this.page2;
            this.document6Tile.Document = this.document6;
            this.document6Tile.Group = "Utils";
            this.document6Tile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // page2
            // 
            this.page2.Document = this.document6;
            this.page2.Parent = this.tileContainer1;
            // 
            // document6
            // 
            this.document6.Caption = "document6";
            this.document6.ControlName = "document6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 528);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroUIView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document2Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document3Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document4Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.page1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document6Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.page2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.MetroUIView metroUIView1;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.TileContainer tileContainer1;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile document1Tile;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile document2Tile;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Document document2;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile document3Tile;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Document document3;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile document4Tile;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Document document4;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile document5Tile;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Document document5;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Tile document6Tile;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Document document6;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.PageGroup pageGroup1;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Page page1;
        private DevExpress.XtraBars.Docking2010.Views.MetroUI.Page page2;
    }
}

