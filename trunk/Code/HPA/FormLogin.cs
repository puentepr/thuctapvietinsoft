﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HPA
{
    
    public partial class FormLogin : Form
    {
        //bool kt = false;
        //int Y, X;
        HPA.SQL.DataDaigramDataContext dt = new SQL.DataDaigramDataContext();
        public FormLogin()
        {
            InitializeComponent();
        }
        private void Dangnhap(string id,string pass)
        {
            int Loginid=dt.SC_Login_CheckLogin(id, pass);
            if (Loginid == -1 || Loginid == -2)
            {
                HPA.Common.Methods.ShowMessage(HPA.Common.CommonConst.LOGIN_FAILURE);
            }
            else
            {
                HPA.Common.StaticVars.LoginID = Loginid ;
                HPA.Common.StaticVars.UserName = txtName.Text;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pa = HPA.Common.Encryption.EncryptText(txtPass.Text,true);
            Dangnhap(txtName.Text, pa);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Control.ControlCollection ctrls = this.Controls;
            HPA.Common.Methods.ChangeLanguage(ref ctrls);
            if (File.Exists((HPA.Properties.Settings.Default.BackGroundLogin))==true)
            {
                this.BackgroundImage = System.Drawing.Image.FromFile(HPA.Properties.Settings.Default.BackGroundLogin);
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            else
            {
                this.BackgroundImage = null;
            }
        }

        //private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        //{
        //    kt = true;
        //    Y = e.Y;
        //    X = e.X;
        //}

        //private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        //{

        //}

        //private void FormLogin_MouseUp(object sender, MouseEventArgs e)
        //{
        //    kt = false;
        //}
    }
}
