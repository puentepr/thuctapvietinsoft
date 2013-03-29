using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using DevExpress.Xpf.DemoBase;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.Editors;
using System.Windows.Data;
using DevExpress.Xpf.Core.WPFCompatibility;
using DevExpress.Xpf.Charts;
using Paradise5.ServiceReference1;
using System.Windows.Threading;
using DevExpress.Xpf.LayoutControl;
using System.Windows.Browser;
using System.Reflection;

namespace Paradise5
{
    public partial class Home
    {
        public static string ma = "";//2 Bien nay se truyen cho Page ViewAnnouncement 
        public static string tentitle="";
        public static int countchart = 11;
        double sonhanvien;
        List<ChartView> dsnv;
        List<tblAnnouncement> dsthongbao;
        Service1Client ws = new Service1Client();
        ChartControl dotuoi = new ChartControl();
        ChartControl thamnien = new ChartControl();
        ChartControl trinhdo = new ChartControl();
        ChartControl chucdanh = new ChartControl();
        ChartControl hopdong = new ChartControl();
        ChartControl honnhan = new ChartControl();
        ChartControl tongiao = new ChartControl();
        ChartControl quocgia = new ChartControl();
        ChartControl trangthai = new ChartControl();
        ChartControl soluongnhansu = new ChartControl();
        TileLayoutControl temp;// Biến tạm dùng phân trang thông báo
        public Home()
        {
            InitializeComponent();
            //TaoKenhThongBao(); 
            ws.ChartDataCompleted += ws_ChartDataCompleted;
            ws.ChartDataAsync();

            //Start add Charts
            nv1.Items.Add(dotuoi);
            nv1.Items.Add(thamnien);
            nv1.Items.Add(chucdanh);
            nv1.Items.Add(trinhdo);
            nv1.Items.Add(hopdong);
            nv1.Items.Add(honnhan);
            nv1.Items.Add(tongiao);
            nv1.Items.Add(quocgia);
            nv1.Items.Add(trangthai);
            nv1.Items.Add(soluongnhansu);
            //End add Charts
            
            //Tao Tile cho Chart
            //Title nt = new Title();
            //nt.Content = "Giới tính";
            //nt.Foreground = new SolidColorBrush(Colors.Red);
            //abc.Titles.Add(nt);
            //End Tao Tile
            //Load1();
            /*SlideNavBarGroup snb1 = new SlideNavBarGroup();
            ChartControl c2 = new ChartControl();
            //c2.Height = 500;
            c2.Background = new SolidColorBrush(Colors.Brown);
            //Chen item vao Group
            nv1.Items.Add(c2);
            //Bat dau chen Item vao navbarControl
            snb1.Name = "snb1";
            snb1.Header = "Test3";
            snb1.Background = new SolidColorBrush(Colors.Cyan);
            //Ket thuc chen Group vao NavBarControl
            navBar.Groups.Add(snb1);
            navBar.Width = 1366;
            navBar.Height = 500;
            abc.Height = 500;
            xyz.Height = 500;*/

        }
        
        #region LoadBieudo
        void LoadBieudo()
        {
            //Tao bieu do Gioi tinh
            SimpleDiagram2D dg1 = new SimpleDiagram2D();
            PieSeries2D dgs1 = new PieSeries2D();
            List<string> Agrument = new List<string>();
            List<double> Value = new List<double>();
            double nam = (double)(from p in dsnv where p.Sex == true select p).Count();
            double nu = (double)(from p in dsnv where p.Sex == false select p).Count();
            Value.Add(nam / sonhanvien);//Phai ep kieu double neu ko he thong se hieu la kieu int
            Value.Add(nu / sonhanvien);
            Agrument.Add("Nam : " + nam.ToString());
            Agrument.Add("Nữ : " + nu.ToString());
            CommonChart.CreatPieChar(gioitinh, dg1, dgs1, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo giới tính", Agrument, Value);
            //End tao bieu do Gioi tinh

            //Tao bieu do Phan bo cac chi nhanh
            SimpleDiagram2D dg2 = new SimpleDiagram2D();
            PieSeries2D dgs2 = new PieSeries2D();
            List<string> dvid = (from p in dsnv select p.DivisionID.ToString()).Distinct().ToList();
            Agrument.Clear();
            Value.Clear();
            foreach (var i in dvid)
            {
                double temp = (double)(from p in dsnv where p.DivisionID.ToString() == i select p).Count();
                Agrument.Add(i + " : " + temp.ToString());
                Value.Add(temp / sonhanvien);
            }
            CommonChart.CreatPieChar(chinhanh, dg2, dgs2, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo chi nhánh", Agrument, Value);
            //End tao bieu do Phan bo cac chi nhanh

            //Tao bieu do tuoi
            SimpleDiagram2D dg3 = new SimpleDiagram2D();
            PieSeries2D dgs3 = new PieSeries2D();
            Agrument.Clear();
            Value.Clear();
            double duoi30 = (double)(from p in dsnv where DateTime.Now.Year - p.Birthday.Value.Year < 30 select p).Count();
            double from30to50 = (double)(from p in dsnv where DateTime.Now.Year - p.Birthday.Value.Year >= 30 && DateTime.Now.Year - p.Birthday.Value.Year <= 50 select p).Count();
            double tren50 = (double)(sonhanvien - duoi30 - from30to50);
            Value.Add(duoi30 / sonhanvien);
            Value.Add(from30to50 / sonhanvien);
            Value.Add(tren50 / sonhanvien);
            Agrument.Add("Dưới 30 : " + duoi30.ToString());
            Agrument.Add("Từ 30-50 : " + from30to50.ToString());
            Agrument.Add("Trên 50 : " + tren50.ToString());
            CommonChart.CreatPieChar(dotuoi, dg3, dgs3, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo độ tuổi", Agrument, Value);
            //End tao bieu do tuoi

            //Tao bieu do tham nien
            SimpleDiagram2D dg4 = new SimpleDiagram2D();
            PieSeries2D dgs4 = new PieSeries2D();
            Agrument.Clear();
            Value.Clear();
            double from1to3 = ((double)(from p in dsnv where DateTime.Now.Year - p.HireDate.Value.Year >= 1 && DateTime.Now.Year - p.HireDate.Value.Year <= 3 select p).Count());
            double from3to5 = ((double)(from p in dsnv where DateTime.Now.Year - p.HireDate.Value.Year >= 3 && DateTime.Now.Year - p.HireDate.Value.Year <= 5 select p).Count());
            double tren5 = (double)(sonhanvien - from1to3 - from3to5);
            Agrument.Add("Từ 1 đến 3 năm : " + from1to3.ToString());
            Agrument.Add("Từ 3 đến 5 năm : " + from3to5.ToString());
            Agrument.Add("Từ 5 năm trở lên : " + tren5.ToString());
            Value.Add(from1to3 / sonhanvien);
            Value.Add(from3to5 / sonhanvien);
            Value.Add(tren5 / sonhanvien);
            CommonChart.CreatPieChar(thamnien, dg4, dgs4, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo thâm niên công tác", Agrument, Value);
            //End tao bieu do tham nien

            //Tao bieu do Chucdanh
            SimpleDiagram2D dg5 = new SimpleDiagram2D();
            PieSeries2D dgs5 = new PieSeries2D();
            List<string> chucdanhid = (from p in dsnv select p.PositionName).Distinct().ToList();
            Agrument.Clear();
            Value.Clear();
            foreach (var i in chucdanhid)
            {
                double temp = (double)(from p in dsnv where p.PositionName == i select p).Count();
                Agrument.Add(i + " : " + temp.ToString());
                Value.Add(temp / sonhanvien);
            }
            CommonChart.CreatPieChar(chucdanh, dg5, dgs5, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo chức danh", Agrument, Value);
            //End tao bieu do Chucdanh

            //Tao bieu do Trinhdo
            SimpleDiagram2D dg6 = new SimpleDiagram2D();
            PieSeries2D dgs6 = new PieSeries2D();
            List<string> trinhdoid = (from p in dsnv select p.TypeSchool).Distinct().ToList();
            Agrument.Clear();
            Value.Clear();
            foreach (var i in trinhdoid)
            {
                double temp = (double)(from p in dsnv where p.TypeSchool == i select p).Count();
                Agrument.Add(i + " : " + temp.ToString());
                Value.Add(temp / sonhanvien);
            }
            CommonChart.CreatPieChar(trinhdo, dg6, dgs6, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo trình độ", Agrument, Value);
            //End tao bieu do Trinhdo

            //Tao bieu do Hopdong
            SimpleDiagram2D dg7 = new SimpleDiagram2D();
            PieSeries2D dgs7 = new PieSeries2D();
            List<string> hopdongid = (from p in dsnv select p.ContractName).Distinct().ToList();
            Agrument.Clear();
            Value.Clear();
            foreach (var i in hopdongid)
            {
                double temp = (double)(from p in dsnv where p.ContractName == i select p).Count();
                Agrument.Add(i + " : " + temp.ToString());
                Value.Add(temp / sonhanvien);
            }
            CommonChart.CreatPieChar(hopdong, dg7, dgs7, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo hợp đồng", Agrument, Value);
            //End tao bieu do Hopdong

            //Tao bieu do honnhan
            SimpleDiagram2D dg8 = new SimpleDiagram2D();
            PieSeries2D dgs8 = new PieSeries2D();
            Agrument.Clear();
            Value.Clear();
            double dakh = ((double)(from p in dsnv where p.Marital == true select p).Count());
            double chuakh = (double)(sonhanvien - dakh);
            Value.Add(dakh / sonhanvien);
            Value.Add(chuakh / sonhanvien);
            Agrument.Add("Đã kết hôn : " + dakh.ToString());
            Agrument.Add("Chưa kết hôn : " + chuakh.ToString());
            CommonChart.CreatPieChar(honnhan, dg8, dgs8, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo tình trạng hôn nhân", Agrument, Value);
            //End tao bieu do hon nhan
            
            //Tao bieu do Tongiao
            SimpleDiagram2D dg9 = new SimpleDiagram2D();
            PieSeries2D dgs9 = new PieSeries2D();
            List<string> tongiaoid = (from p in dsnv select p.Religion).Distinct().ToList();
            Agrument.Clear();
            Value.Clear();
            foreach (var i in tongiaoid)
            {
                double temp = (double)(from p in dsnv where p.Religion == i select p).Count();
                Agrument.Add(i + " : " + temp.ToString());
                Value.Add(temp / sonhanvien);
            }
            CommonChart.CreatPieChar(tongiao, dg9, dgs9, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo tôn giáo", Agrument, Value);
            //End tao bieu do Tongiao

            //Tao bieu do Quoctich
            SimpleDiagram2D dg10 = new SimpleDiagram2D();
            PieSeries2D dgs10 = new PieSeries2D();
            List<string> quoctichid = (from p in dsnv select p.Nationality).Distinct().ToList();
            Agrument.Clear();
            Value.Clear();
            foreach (var i in quoctichid)
            {
                double temp = (double)(from p in dsnv where p.Nationality == i select p).Count();
                Agrument.Add(i + " : " + temp.ToString());
                Value.Add(temp / sonhanvien);
            }
            CommonChart.CreatPieChar(quocgia, dg10, dgs10, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo quốc tịch", Agrument, Value);
            //End tao bieu do Quoctich

            //Tao bieu do Trangthai
            SimpleDiagram2D dg11 = new SimpleDiagram2D();
            PieSeries2D dgs11 = new PieSeries2D();
            List<string> trangthaiid = (from p in dsnv select p.EmployeeStatus).Distinct().ToList();
            Agrument.Clear();
            Value.Clear();
            foreach (var i in trangthaiid)
            {
                double temp = (double)(from p in dsnv where p.EmployeeStatus == i select p).Count();
                Agrument.Add(i + " : " + temp.ToString());
                Value.Add(temp / sonhanvien);
            }
            CommonChart.CreatPieChar(trangthai, dg11, dgs11, new SolidColorBrush(Colors.Red), "Thống kê nhân viên theo trạng thái", Agrument, Value);
            //End tao bieu do Trangthai

            #region Tao bieu do so luong nhan su

            XYDiagram2D dg12 = new XYDiagram2D();
            ////Set tieu de
            //AxisTitle tieudex = new AxisTitle();
            //tieudex.Content="Số nhân viên";
            //dg12.AxisX.Title.Content = tieudex;

            ////End set tieu de
            int startyear = int.Parse(dsnv.Min(u => u.HireDate.Value.Year).ToString());
            double slnv = 0;
            //Tao bieu do so luong nhan vien tuyen dung
            BarSideBySideSeries2D dgs13 = new BarSideBySideSeries2D();
            dgs13.DisplayName = "Số nhân viên tuyển dụng";
            Agrument.Clear();
            Value.Clear();
            for (int i = startyear; i < int.Parse((DateTime.Now.Year).ToString()); i++)
            {
                slnv = (double)(from p in dsnv where p.HireDate.Value.Year.ToString() == i.ToString() && p.TerminateDate == null select p).Count();
                Agrument.Add(i.ToString());
                Value.Add(slnv);
            }
            CommonChart.CreatXYChar(soluongnhansu, dg12, dgs13, new SolidColorBrush(Colors.Red), "Thống kê số lượng nhân sự", Agrument, Value);
            //End tao bieu do so luong tong nhan vien tuyen dung

            //Tao bieu do so luong nhan vien nghi viec
            BarSideBySideSeries2D dgs14 = new BarSideBySideSeries2D();
            slnv = 0;
            dgs14.DisplayName = "Số nhân viên nghỉ việc";
            Agrument.Clear();
            Value.Clear();
            for (int i = startyear; i < int.Parse((DateTime.Now.Year).ToString()); i++)
            {
                slnv = (double)(from p in dsnv where p.TerminateDate != null && p.TerminateDate.Value.Year.ToString() == i.ToString() select p).Count();
                Agrument.Add(i.ToString());
                Value.Add(slnv);
            }
            CommonChart.CreatXYChar(soluongnhansu, dg12, dgs14, new SolidColorBrush(Colors.Red), "Thống kê số lượng nhân sự", Agrument, Value);
            //End tao bieu do so luong tong nhan vien nghi viec

            //Tao bieu do so luong tong nhan vien
            BarSideBySideSeries2D dgs12 = new BarSideBySideSeries2D();
            dgs12.DisplayName = "Tổng nhân viên";
            Agrument.Clear();
            Value.Clear();
            slnv = 0;
            for (int i = startyear; i < int.Parse((DateTime.Now.Year).ToString()); i++)
            {
                slnv += (double)(from p in dsnv where p.HireDate.Value.Year.ToString() == i.ToString() && p.TerminateDate == null select p).Count();
                Agrument.Add(i.ToString());
                Value.Add(slnv);
            }
            CommonChart.CreatXYChar(soluongnhansu, dg12, dgs12, new SolidColorBrush(Colors.Red), "Thống kê số lượng nhân sự", Agrument, Value);
            //Tao chu thich
            soluongnhansu.Legend = new Legend();
            soluongnhansu.Legend.Visibility = Visibility.Visible;
            soluongnhansu.Legend.HorizontalPosition = HorizontalPosition.Center;
            soluongnhansu.Legend.VerticalPosition = VerticalPosition.BottomOutside;
            soluongnhansu.Legend.Orientation = Orientation.Horizontal;
            //End tao bieu do so luong tong nhan vien
            #endregion
        }
        #endregion

        void ws_ChartDataCompleted(object sender, ChartDataCompletedEventArgs e)
        {
            dsnv = e.Result.ToList();
            sonhanvien = dsnv.Count();
            LoadBieudo();
            PageSmoothScroller.delaytime.Interval = new TimeSpan(0, 0, 3);//Set thoi gian delay cac bieu do
            PageSmoothScroller.delaytime.Start();
            ws.GetThongbaoCompleted += ws_GetThongbaoCompleted;
            ws.GetThongbaoAsync();
        }
        #region LoadThongBao
        void ws_GetThongbaoCompleted(object sender, GetThongbaoCompletedEventArgs e)
        {
            if(e.Result!=null)
            {
                dsthongbao = e.Result.ToList();
                LoadThongBao();//Tạo kênh thông báo
            }
        }

        void LoadThongBao()
        {
            SlideNavBarGroup nv2 = new SlideNavBarGroup() { Header = "Thông báo mới nhất" };
            nv2.SetValue(SlideNavBarGroup.RadioButtonStyleProperty, DemoModuleControl.Resources["Group2RadioButtonStyle"]);
            nv2.Background = new SolidColorBrush(Colors.Brown);
            navBar.Groups.Add(nv2);
            for (int i = 0; i < dsthongbao.Count; i++)
            {
                string ten = dsthongbao.ElementAt(i).Title;
                string ma = dsthongbao.ElementAt(i).ID.ToString();
                if (i % 6 == 0)//Phân trang thông báo bằng cách cứ 6 thông báo thì tạo một TileLayoutControl mới
                {
                    TileLayoutControl temp1 = new TileLayoutControl();
                    temp = temp1;
                    temp1.TileClick += TLYC1_TileClick;
                    temp1.ScrollBars = ScrollBars.Auto;
                    temp1.Orientation = Orientation.Horizontal;
                    temp1.HorizontalAlignment = HorizontalAlignment.Center;
                    temp1.VerticalAlignment = VerticalAlignment.Center;
                    nv2.Items.Add(temp1);
                    CreateTile1(ma,ten);
                }
                else
                {
                    CreateTile1(ma,ten); 
                }
            }
        }
        void CreateTile1(string ma,string ten)//Tao tile
        {
            Tile til = new Tile();
            til.Name = ma;
            til.Header = ten;
            til.HorizontalHeaderAlignment = HorizontalAlignment.Center;
            til.VerticalHeaderAlignment = VerticalAlignment.Center;
            temp.Children.Add(til);
        }
        #endregion
        #region AutoRun and CustomRunChart
        private void navBar_MouseEnter(object sender, MouseEventArgs e)
        {
            PageSmoothScroller.delaytime.Stop();
        }

        private void navBar_MouseLeave(object sender, MouseEventArgs e)
        {
            PageSmoothScroller.delaytime.Start();
        }
        #endregion

        private void navBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (SlideNavBarGroup element in navBar.Groups)
            {
                element.Width = e.NewSize.Width;
                element.Height = e.NewSize.Height;
            }
            foreach (ChartControl bieudo in nv1.Items)
            {
                bieudo.Width = nv1.Width - 200;
                bieudo.Height = nv1.Height - 100;
            }
        }

        private void NavBarDemoModule_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            navBar.Width = e.NewSize.Width - 20;
            navBar.Height = e.NewSize.Height - 20;
        }

        void TLYC1_TileClick(object sender, TileClickEventArgs e)
        {
            ma = e.Tile.Name.ToString();
            tentitle = e.Tile.Header.ToString();
            var WbClnt = new WebClient();//Tao WebClient
            WbClnt.OpenReadCompleted += (a, b) =>
            {
                if (b.Error == null)
                {
                    AssemblyPart assmbpart = new AssemblyPart();
                    Assembly assembly = assmbpart.Load(b.Result);
                    Object Obj = assembly.CreateInstance("HPA.Announcement" + "." + "ViewAnnouncement");//Truy xuat file dll
                    if (Obj != null)//Neu co file dll thi tao ChildWindow
                    {
                        ChildWindow child = (ChildWindow)assembly.CreateInstance("HPA.Announcement" + "." + "ViewAnnouncement");
                        child.Width = (double)HtmlPage.Window.Eval("screen.availWidth") - 100;
                        child.Height = (double)HtmlPage.Window.Eval("screen.availHeight") - 100;
                        child.Show();
                    }
                    else { MessageBox.Show("Page not exist"); }//Khong ton tai page thi bao loi
                }
                else { MessageBox.Show("Page not exist"); }//Khong ton tai file dll thi bao loi
            };
            WbClnt.OpenReadAsync(new Uri("http://localhost:10511/Control/" + "HPA.Announcement" + ".dll", UriKind.Absolute));
        }

    }
    public class NavBarDemoModule : DemoModule
    {
        private static bool IsDarkTheme()
        {
            return ThemeManager.ApplicationThemeName == "Office2010Black" || ThemeManager.ApplicationThemeName == "MetropolisDark" || ThemeManager.ApplicationThemeName == "VS2010";
        }
        private static bool IsDarkBackgroundTheme()
        {
            return ThemeManager.ApplicationThemeName == "MetropolisDark" || ThemeManager.ApplicationThemeName == "Office2010Black";
        }

        protected internal NavBarControl navBarControl { get; set; }

        protected virtual ExplorerBarView GetExplorerBarView()
        {
            return new ExplorerBarView();
        }
        protected virtual NavigationPaneView GetNavigationPaneView()
        {
            return new NavigationPaneView();
        }
        protected virtual SideBarView GetSideBarView()
        {
            return new SideBarView();
        }
        protected virtual void SelectView(object sender, RoutedEventArgs e)
        {
            if (navBarControl == null)
                return;
            string name = (string)((ListBoxEdit)sender).SelectedItem;
            switch (name)
            {
                case "Explorer Bar":
                    navBarControl.View = GetExplorerBarView();
                    break;
                case "Navigation Pane":
                    navBarControl.View = GetNavigationPaneView();
                    break;
                case "Side Bar":
                    navBarControl.View = GetSideBarView();
                    break;
                default:
                    throw new ArgumentException("Could not find specified view.");
            }
        }
    }
    public class SlideNavBarGroup : NavBarGroup
    {
        public static readonly DependencyProperty ItemVisibleIndexProperty;
        public static readonly DependencyProperty RadioButtonStyleProperty;
        static SlideNavBarGroup()
        {
            ItemVisibleIndexProperty = DependencyProperty.Register("ItemVisibleIndex", typeof(int), typeof(SlideNavBarGroup), new PropertyMetadata(0));
            RadioButtonStyleProperty = DependencyProperty.Register("RadioButtonStyle", typeof(Style), typeof(SlideNavBarGroup), new PropertyMetadata(null));
        }
        public int ItemVisibleIndex
        {
            get { return (int)GetValue(ItemVisibleIndexProperty); }
            set { SetValue(ItemVisibleIndexProperty, value); }
        }
        public Style RadioButtonStyle
        {
            get { return (Style)GetValue(RadioButtonStyleProperty); }
            set { SetValue(RadioButtonStyleProperty, value); }
        }
    }
    public class PageSmoothScroller : NavBarSmoothScroller
    {
        #region static
        public static DispatcherTimer delaytime = new DispatcherTimer();
        public static readonly DependencyProperty ItemVisibleIndexProperty;
        int updown = 0;
        static PageSmoothScroller()
        {
            ItemVisibleIndexProperty = DependencyProperty.Register("ItemVisibleIndex", typeof(int), typeof(PageSmoothScroller), new PropertyMetadata(2, new PropertyChangedCallback(OnCurrentVisibleItemPropertyChanged)));
        }

        protected static void OnCurrentVisibleItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PageSmoothScroller)d).OnCurrentVisibleItemChanged();
        }
        #endregion
        public PageSmoothScroller()
        {
            Loaded += new RoutedEventHandler(OnLoaded);
            delaytime.Tick += delaytime_Tick;
        }
        //Su kien AutoChart
        void delaytime_Tick(object sender, EventArgs e)
        {
            if (delaytime.IsEnabled == true)
            {
                if (ItemVisibleIndex == Home.countchart)
                { updown = 1; }
                if (ItemVisibleIndex == 0)
                { updown = 0; }
                if (updown == 0)
                { PerformScrollDownCommand(); }
                if (updown == 1)
                { PerformScrollUpCommand(); }
            }
        }
        //End su kien AutoChart

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            SetBinding(ItemVisibleIndexProperty, new Binding("ItemVisibleIndex") { Mode = BindingMode.TwoWay });
        }
        public int ItemVisibleIndex
        {
            get { return (int)GetValue(ItemVisibleIndexProperty); }
            set { SetValue(ItemVisibleIndexProperty, value); }
        }
        protected internal double NextChildOffset
        {
            get
            {
                double height = 0;
                StackPanel itemsPanel = (StackPanel)GetItemsPanel(this);
                if (itemsPanel == null)
                    return height;
                if (ItemVisibleIndex == itemsPanel.Children.Count - 1)
                    return ContentHeight - ((FrameworkElement)itemsPanel.Children[ItemVisibleIndex]).ActualHeight + 15;
                for (int i = 0; i < ItemVisibleIndex; i++)
                {
                    height += ((FrameworkElement)itemsPanel.Children[i]).ActualHeight;
                }
                return height;
            }
        }
        protected override void OnMouseWheel(System.Windows.Input.MouseWheelEventArgs e) { }
        protected override void PerformScrollDownCommand()
        {
            int visibleIndex = ItemVisibleIndex + 1;
            if (ActualHeight * visibleIndex > ContentHeight)
                return;
            ItemVisibleIndex += 1;
        }
        protected override void PerformScrollUpCommand()
        {
            int visibleIndex = ItemVisibleIndex - 1;
            if (visibleIndex < 0)
                return;
            ItemVisibleIndex -= 1;
        }
        protected internal void OnCurrentVisibleItemChanged()
        {
            StartAnimation();
        }
        FrameworkElement GetItemsPanel(DependencyObject reference)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(reference);
            if (childrenCount > 0)
            {
                FrameworkElement child = (FrameworkElement)VisualTreeHelper.GetChild(reference, 0);
                if (child.Name == "itemsPanel")
                    return child;
                else
                    return GetItemsPanel(child);
            }
            return null;
        }
        void StartAnimation()
        {
            Storyboard storyBoard = new Storyboard();
            Storyboard.SetTargetProperty(storyBoard, new PropertyPath(ChildOffsetProperty));
            DoubleAnimation scrollAnimation = new DoubleAnimation();

            scrollAnimation.From = ChildOffset;
            scrollAnimation.To = NextChildOffset;
            scrollAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            DoubleAnimationUsingKeyFrames opacityAnimation = new DoubleAnimationUsingKeyFrames();
            opacityAnimation.KeyFrames.Add(new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 200)), Value = 0.5 });
            opacityAnimation.KeyFrames.Add(new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 500)), Value = 0.5 });
            opacityAnimation.KeyFrames.Add(new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 600)), Value = 1 });
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
            Storyboard.SetTarget(opacityAnimation, Child);

            storyBoard.Children.Add(scrollAnimation);
            storyBoard.Children.Add(opacityAnimation);
            storyBoard.Begin(this, true);
        }
    }
    public class RadioButtonsPanel : StackPanel
    {
        public static readonly DependencyProperty RadioButtonStyleProperty;
        public static readonly DependencyProperty SelectedItemIndexProperty;

        static RadioButtonsPanel()
        {
            RadioButtonStyleProperty = DependencyProperty.Register("RadioButtonStyle", typeof(Style), typeof(RadioButtonsPanel), new PropertyMetadata(null));
            SelectedItemIndexProperty = DependencyProperty.Register("SelectedItemIndex", typeof(int), typeof(RadioButtonsPanel), new PropertyMetadata(0, new PropertyChangedCallback(OnSelectedItemIndexPropertyChanged)));
        }

        public RadioButtonsPanel()
        {
            Loaded += new RoutedEventHandler(OnLoaded);
        }

        public Style RadioButtonStyle
        {
            get { return (Style)GetValue(RadioButtonStyleProperty); }
            set { SetValue(RadioButtonStyleProperty, value); }
        }
        public int SelectedItemIndex
        {
            get { return (int)GetValue(SelectedItemIndexProperty); }
            set { SetValue(SelectedItemIndexProperty, value); }
        }

        public static void OnSelectedItemIndexPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((RadioButtonsPanel)d).UpdateSelectedItemIndex();
        }
        void GenerateContent()
        {
            if (DataContext == null || Children.Count == ((NavBarGroup)DataContext).Items.Count)
                return;
            int itemsCount = ((NavBarGroup)DataContext).Items.Count;
            for (int i = itemsCount - 1; i >= 0; i--)
            {
                RadioButton rb = new RadioButton() { Style = RadioButtonStyle, Content = i };
                if (i == 0)
                    rb.Margin = new Thickness(2, 2, 4, 2);
                if (i == itemsCount - 1)
                    rb.Margin = new Thickness(4, 2, 2, 2);
                rb.Click += new RoutedEventHandler(OnRadioButtonClick);
                Children.Add(rb);
            }
        }
        void OnInitialized()
        {
            SetBinding(SelectedItemIndexProperty, new Binding("ItemVisibleIndex"));
            GenerateContent();
            UpdateSelectedItemIndex();
        }
        void OnLoaded(object sender, RoutedEventArgs e)
        {
            OnInitialized();
        }
        void OnRadioButtonClick(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.IsChecked.HasValue && rb.IsChecked.Value)
                ((SlideNavBarGroup)DataContext).ItemVisibleIndex = Int32.Parse((rb).Content.ToString());

        }
        void UpdateSelectedItemIndex()
        {
            if (SelectedItemIndex >= Children.Count)
                return;
            ((RadioButton)Children[Children.Count - SelectedItemIndex - 1]).IsChecked = true;
        }
    }
}

