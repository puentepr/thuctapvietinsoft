using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HPA.CommonForm
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        bool kt = false;
        int Y, X;
        private string _fullClassName;

        public string FullClassName
        {
            get { return _fullClassName; }
            set { _fullClassName = value; }
        }
        public BaseForm()
        {
            if (!HasAccessRight())
            {
                HPA.Common.Methods.ShowMessage(HPA.Common.CommonConst.NO_RIGHT_TO_ACCESS);
                this.Dispose();
                this.Close();
            }
            InitializeComponent();
        }

        private bool HasAccessRight()
        {
            HPA.SQL.DataDaigramDataContext sqlcon = new SQL.DataDaigramDataContext();
            if (sqlcon.SC_USEROBJECTRIGHT_GET(FullClassName, HPA.Common.StaticVars.LoginID) <= 0)
                return false;
            else
                return true;
        }

        private void BaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            kt = true;
            Y = e.Y;
            X = e.X;
        }

        private void BaseForm_MouseUp(object sender, MouseEventArgs e)
        {
            kt = false;
        }

        private void BaseForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (kt)
            {
                this.Top += e.Y - Y;
                this.Left += e.X - X;
            }
        }
    }
}