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
using Paradise5.ServiceReference1;
using System.Configuration;

namespace Paradise5
{
    public partial class Test : Page
    {
        Service1Client ws = new Service1Client();
        public Test()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.SetValidation("Tên đăng nhập không được để trống");
                txtName.RaiseValidationError();
            }
            else
            {
                txtName.ClearValidationError();
                ws.CheckloginCompleted -= ws_CheckloginCompleted;
                ws.CheckloginCompleted += ws_CheckloginCompleted;
                ws.CheckloginAsync(txtName.Text, txtPass.Password);
            }
        }
        void ws_CheckloginCompleted(object sender, CheckloginCompletedEventArgs e)
        {
            int loginid = e.Result;
            if (loginid == -2||loginid==-1)
            {
                txtName.SetValidation("Tên đăng nhập hoặc mật khẩu không đúng");
                txtName.RaiseValidationError();
                //MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            }
            else if (loginid == -3)
            {
                txtName.SetValidation("Mật khẩu của bạn đã lâu không thay đổi. Vui lòng đổi mật khẩu");
                txtName.RaiseValidationError();
            }
            else
            {
                txtName.ClearValidationError();
                ws.SetSessionCompleted += ws_SetSessionCompleted;
                ws.SetSessionAsync(txtName.Text, loginid);
                //Cookie cookie = new Cookie ("UserName", txtName.Text);
                //cookie.Expires = DateTime.Now.AddYears(1);
            }
        }

        void ws_SetSessionCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //MessageBox.Show("Đăng nhập thành công");
            //this.NavigationService.Navigate(new Uri("/MainPage", UriKind.Relative));
            //Chuyen huong
            this.Content = new MainPage();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Home();
        }
    }
}
