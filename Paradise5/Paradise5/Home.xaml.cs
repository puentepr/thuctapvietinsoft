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
using Paradise5.ServiceReference1;

namespace Paradise5
{
    public partial class Home
    {
        public static string ma = "";//2 Bien nay se truyen cho Page ViewAnnouncement 
        public static string tentitle="";
        public static int countchart = 11;
        List<tblAnnouncement> dsthongbao;
        Service1Client ws = new Service1Client();
        TileLayoutControl temp;// Biến tạm dùng phân trang thông báo
        List<ChartDataChartCommon> dsbieudo= new List<ServiceReference1.ChartDataChartCommon>();
        SlideNavBarGroup nv3 = new SlideNavBarGroup() { Header = "Thống kê nhân sự" };
        public Home()
        {
            InitializeComponent();
            ws.LoadChartCompleted += ws_LoadChartCompleted;
            ws.LoadChartAsync();
        }

        public void ws_LoadChartCompleted(object sender, ServiceReference1.LoadChartCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                dsbieudo = e.Result.ToList();
                LoadChartView();
                
            }
            PageSmoothScroller.delaytime.Interval = new TimeSpan(0, 0, 3);//Set thoi gian delay cac bieu do
            PageSmoothScroller.delaytime.Start();
            ws.GetThongbaoCompleted += ws_GetThongbaoCompleted;
            ws.GetThongbaoAsync();
        }
        #region LoadBieuDo
        public void LoadChartView()
        {
            
            nv3.SetValue(SlideNavBarGroup.RadioButtonStyleProperty, DemoModuleControl.Resources["Group1RadioButtonStyle"]);
            nv3.Background = new SolidColorBrush(Color.FromArgb(255,025,025,112));
            navBar.Groups.Add(nv3);
            countchart = 0;
            foreach (ChartDataChartCommon dr in dsbieudo)
            {

                if (dr.ChartType == "Pie")
                {
                   ChartControl abc = CommonChart.CreatPieChart(new SolidColorBrush(Colors.Red), dr.ChartTitle, dr.ChartData.ToList());
                   nv3.Items.Add(abc);
                   abc.Width = navBar.Width - 200;
                   abc.Height = navBar.Height - 100;
                   countchart++;
                }
                else if (dr.ChartType == "Bar")
                {
                    ChartControl abc = CommonChart.CreatXYChart(new SolidColorBrush(Colors.Red), dr.ChartTitle, dr.ChartData.ToList());
                    nv3.Items.Add(abc);
                    abc.Width = navBar.Width - 200;
                    abc.Height = navBar.Height - 100;
                    countchart++;
                }
                
            }
        }
        #endregion

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
            foreach (ChartControl bieudo in nv3.Items)
            {
                bieudo.Width = nv3.Width - 200;
                bieudo.Height = nv3.Height - 100;
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
        #region AutoChart
        void delaytime_Tick(object sender, EventArgs e)
        {
            if (delaytime.IsEnabled == true)
            {
                //updown la bien trang thai 1 la len 0 la xuong
                if (ItemVisibleIndex == Home.countchart - 1)//Neu la bieu do cuoi cung
                { updown = 1; }
                if (ItemVisibleIndex == 0)//Neu la bieu do dau tien
                { updown = 0; }
                if (updown == 0)//Neu trang thai la cuon xuong
                { PerformScrollDownCommand(); }
                if (updown == 1)//Neu trang thai la cuon len
                { PerformScrollUpCommand(); }
            }
        }
        #endregion

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

