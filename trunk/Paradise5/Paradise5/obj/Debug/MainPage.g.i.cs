﻿#pragma checksum "C:\Users\Dumspiro Spero\Desktop\Thuc tap\Paradise5\Paradise5\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C889445581D1B17BE8FE593A227805FC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Paradise5.ControlEXT;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Paradise5 {
    
    
    public partial class MainPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.UserControl Home;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.VisualStateGroup AppBarStates;
        
        internal System.Windows.VisualState Hide;
        
        internal System.Windows.VisualState Show;
        
        internal System.Windows.Controls.StackPanel appBar;
        
        internal System.Windows.Controls.Grid GridStack;
        
        internal System.Windows.Controls.TextBox txtName;
        
        internal System.Windows.Controls.PasswordBox txtPass;
        
        internal System.Windows.Controls.Button btnLogin;
        
        internal System.Windows.Controls.HyperlinkButton HpLogout;
        
        internal System.Windows.Controls.HyperlinkButton HPL1;
        
        internal System.Windows.Controls.HyperlinkButton btnBack;
        
        internal System.Windows.Controls.ScrollViewer TLYCScroll;
        
        internal DevExpress.Xpf.LayoutControl.TileLayoutControl TLYC;
        
        internal Paradise5.ControlEXT.TextBoxEX TxtTest;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Paradise5;component/MainPage.xaml", System.UriKind.Relative));
            this.Home = ((System.Windows.Controls.UserControl)(this.FindName("Home")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.AppBarStates = ((System.Windows.VisualStateGroup)(this.FindName("AppBarStates")));
            this.Hide = ((System.Windows.VisualState)(this.FindName("Hide")));
            this.Show = ((System.Windows.VisualState)(this.FindName("Show")));
            this.appBar = ((System.Windows.Controls.StackPanel)(this.FindName("appBar")));
            this.GridStack = ((System.Windows.Controls.Grid)(this.FindName("GridStack")));
            this.txtName = ((System.Windows.Controls.TextBox)(this.FindName("txtName")));
            this.txtPass = ((System.Windows.Controls.PasswordBox)(this.FindName("txtPass")));
            this.btnLogin = ((System.Windows.Controls.Button)(this.FindName("btnLogin")));
            this.HpLogout = ((System.Windows.Controls.HyperlinkButton)(this.FindName("HpLogout")));
            this.HPL1 = ((System.Windows.Controls.HyperlinkButton)(this.FindName("HPL1")));
            this.btnBack = ((System.Windows.Controls.HyperlinkButton)(this.FindName("btnBack")));
            this.TLYCScroll = ((System.Windows.Controls.ScrollViewer)(this.FindName("TLYCScroll")));
            this.TLYC = ((DevExpress.Xpf.LayoutControl.TileLayoutControl)(this.FindName("TLYC")));
            this.TxtTest = ((Paradise5.ControlEXT.TextBoxEX)(this.FindName("TxtTest")));
        }
    }
}

