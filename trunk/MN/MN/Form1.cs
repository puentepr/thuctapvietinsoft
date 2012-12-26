using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.MetroUI;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MN
{
    public partial class Form1 : HPA.CommonForm.BaseForm
    {

        public DocumentManager _DocManager;
        public MetroUIView _MetroUI;
        public TileContainer TileCon;
        public TileContainer ChildTileCon;
        public Tile _Tile, _Tile1;
        public Document _Doc, _Doc1;
        public TileItemElement _Element,_Element1;
        public TileItemFrame frame;
        public List<TileContainer> _listTileCon = new List<TileContainer>();
        private DataTable dtMenu;
        Random ran = new Random();
        MenuLQDataContext MenuLQ = new MenuLQDataContext();

        public Form1()
        {
            InitializeComponent();
            _DocManager = new DocumentManager();
            ((ISupportInitialize)(this._DocManager)).BeginInit();
            _MetroUI = new MetroUIView();
            _DocManager.ContainerControl = this;
            _DocManager.View = _MetroUI;
            _DocManager.ViewCollection.Add(_MetroUI);
            ((ISupportInitialize)(this._DocManager)).EndInit();
            IdMenu();
        }

        void _MetroUI_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            e.Control = new Control();
        }

        public void CreateTile(DataRow Menu)
        {     
                string element = Menu["Name"].ToString();            
            _Tile = new Tile();           
            _Doc = new Document();
            _Element = new TileItemElement() { Text = element, TextAlignment = TileItemContentAlignment.BottomLeft };

            ((ISupportInitialize)(this._MetroUI)).BeginInit();
            ((ISupportInitialize)(this._Tile)).BeginInit();
            ((ISupportInitialize)(this._Doc)).BeginInit();
            //Tim ve nha
            if (dtMenu.Select(string.Format("MenuID = '{0}'", Menu["MenuID"]))[0]["ParentMenuID"] != DBNull.Value)
            {
                foreach (TileContainer tc in _MetroUI.ContentContainers)
                {
                    if (tc.Caption.Equals(dtMenu.Select(string.Format("MenuID = '{0}'", Menu["MenuID"]))[0]["ParentMenuID"].ToString()) && Dash(tc.Caption) == false)
                    {
                        tc.Items.Add(_Tile);
                    }
                }
            }
            // xac dinh con
            if (dtMenu.Select(string.Format("ParentMenuID = '{0}'", Menu["MenuID"])).Length > 0 && Dash(Menu["MenuID"].ToString()) == false)
            {
                foreach (TileContainer tc in _MetroUI.ContentContainers)
                {
                    if (tc.Caption.Equals(Menu["MenuID"].ToString()) && Dash(tc.Caption) == false)
                    {
                        _Tile.ActivationTarget = tc;
                    }
                }
            }
            _MetroUI.Documents.Add(_Doc);
            _MetroUI.Tiles.Add(_Tile);
            _MetroUI.Documents.Add(_Doc);

            _MetroUI.QueryControl += _MetroUI_QueryControl;

            _Doc.ControlName = element;
            _Doc.Caption = element;

            _Tile.Document = _Doc;
            _Tile.Elements.Add(_Element);
            _Tile.Properties.IsLarge = DevExpress.Utils.DefaultBoolean.False;
            _Tile.Properties.FrameAnimationInterval = ran.Next(3000,8000);

            if (dtMenu.Select(string.Format("ParentMenuID = '{0}'", Menu["MenuID"])).Length > 0 && Dash(Menu["MenuID"].ToString()) == false)
            {
                foreach(DataRow dr in dtMenu.Select(string.Format("ParentMenuID = '{0}'",Menu["MenuID"])))
                {
                    
                    TileItemElement el = new TileItemElement() { Text = dr["Name"].ToString()};
                    frame = new TileItemFrame();
                    frame.Elements.Add(el);
                    frame.Elements.Add(_Element);
                    _Tile.Frames.Add(frame);              
                }
            }        
            ((ISupportInitialize)(this._Tile)).EndInit();
            ((ISupportInitialize)(this._Doc)).EndInit();
            ((ISupportInitialize)(this._MetroUI)).EndInit();
        }
        //xác định id của menu cha
        public void IdMenu()
        {
            ((ISupportInitialize)(this._MetroUI)).BeginInit();
            dtMenu = DBEngine.execReturnDataTable("sp_Menu_Load", "@LanguageID", "vn", "@LoginID",3);
            //xac dinh so containt can tao
            _MetroUI.ContentContainers.Clear();
            foreach (DataRow drContaint in DBEngine.execReturnDataTable("Select distinct ParentMenuID from MEN_MENU where IsVisible = 1").Rows)
            {
                TileContainer  tc = new TileContainer();
                if (drContaint["ParentMenuID"] != DBNull.Value)
                {
                    tc.Caption = drContaint["ParentMenuID"].ToString();
                    _MetroUI.ContentContainers.Add(tc);
                } 
            }
            // xac dinh cha con
            foreach (TileContainer tc in _MetroUI.ContentContainers)
            {
                string parentName=string.Empty;
                if(dtMenu.Select(string.Format("MenuID = '{0}'", tc.Caption)).Length >0)
                    parentName  = dtMenu.Select(string.Format("MenuID = '{0}'", tc.Caption))[0]["ParentMenuID"].ToString();
                foreach (TileContainer parent in _MetroUI.ContentContainers)
                {
                    if (parent.Caption.Equals(parentName))
                    {
                        tc.Parent = parent;
                        break;
                    }
                }
            }
            foreach (DataRow drTile in dtMenu.Rows)
            {
                CreateTile(drTile);
            }

            foreach (TileContainer tc in _MetroUI.ContentContainers)
            {
                string name = MenuName(tc.Caption); ;
                    if (tc.Caption == "Mnu")
                        tc.Caption = "Home";
                    else
                        tc.Caption = name;
            }

            ((ISupportInitialize)(this._MetroUI)).EndInit();
        }

        public string MenuName(string id)
        {
            string name = "";
            dtMenu = DBEngine.execReturnDataTable(String.Format("select Content from tblMD_Message  where MessageID='{0}'", id));
            foreach (DataRow dr in dtMenu.Rows)
            {
                name = dr["Content"].ToString();
            }
            return name;
        }

        public bool Dash(string MenuID)
        {
            //-----------------------------
            DataTable dt;
            bool b = false;
            dt = DBEngine.execReturnDataTable(String.Format("select Content from tblMD_Message  where MessageId='{0}'", MenuID));
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["Content"].ToString() == "----------------------------- ")
                    b = true;
            }
            return b;
        }
    }
}
