using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HPA.Common
{
   public class FocusControlsIndicator
    {
        // Muon chay cach bat label gan nhat : xoa chu thich o cac dau (*)
        public struct OldControl
        {
            public Color oldcolor;
            public Font oldfont;
            public string controlname;
            public OldControl(Color c, Font f, string ten)
            {
                oldcolor = c;
                oldfont = f;
                controlname = ten;
            }
        }
        public Timer tm = new Timer();
        private PictureBox picIndicator = new PictureBox();
        public Control temp;
        public Control temp1;
        public Control lbltemp;
        const int khoangcach = 5;
        const int max = 200;//Khoang cach tu control den label gan nhat(*)
        const int min = 30;//Khoang cach tu control den label xa nhat(*)
        int duoi = -5;//Khoang cach tinh tu tren xuong cua control den label(*)                
        List<OldControl> odcontrol = new List<OldControl>();//(*)

        public void LoadAddGotFocus(Control ctrl)
        {
            if (temp == null)
            {
                temp = ctrl;
                picIndicator.BackColor = Color.Transparent;
                picIndicator.Image = global::HPA.Common.Properties.Resources.Tiangle;
                picIndicator.Size = new Size(20, 23);
            }
            //SaveData(temp);//Dung luu lai thiet ke ban dau cua cac control(*)
            //Neu khong dung timer
            foreach (Control ctrChid in ctrl.Controls)
            {
                if (!(ctrChid is Label || ctrChid is LabelControl))
                {
                    ctrChid.GotFocus -= ctrChid_GotFocus;
                    ctrChid.GotFocus += ctrChid_GotFocus;
                    //ctrChid.LostFocus += ctrChid_LostFocus;//Khoi phuc lai control theo thiet ke ban dau(*)
                }
                if (ctrChid.Controls.Count > 0)
                {
                    LoadAddGotFocus(ctrChid);
                }

            }

        }
        public void ctrChid_GotFocus(object sender, EventArgs e)
        {
            temp1 = (Control)sender;
            //GotFocusCommon(temp1);//Bat label gan nhat(*)
            GotFocusCommon1(temp1);// Add label   
        }
        //Test
        public void GotFocusCommon(Control ctrlChild)
        {

            if (ctrlChild.Name == "")
            {
                Point p = ctrlChild.Parent.Location;
                for (int i = min; i < max; i++)// Tim label trong khoang cach chi dinh
                {
                    Point plbl = p - new Size(i, duoi);  //    tuy 
                    Control c = (ctrlChild.Parent).Parent.GetChildAtPoint(plbl);

                    if ((c is Label || c is LabelControl) && c.Visible == true)
                    {
                        lbltemp = c;
                        c.ForeColor = Color.Gray;
                        c.Font = new Font(FontFamily.GenericSerif, 15.0f);
                        break;//Neu tim thay cai dau tien thi thoat khoi vong lap
                    }
                }

            }
            else
            {
                Point p = ctrlChild.Location;
                for (int i = min; i < max; i++)// Tim label trong khoang cach chi dinh
                {
                    Point plbl = p - new Size(i, duoi);  //    tuy 
                    Control c = ctrlChild.Parent.GetChildAtPoint(plbl);

                    if ((c is Label || c is LabelControl) && c.Visible == true)
                    {
                        lbltemp = c;
                        c.ForeColor = Color.Gray;
                        c.Font = new Font(FontFamily.GenericSerif, 15.0f);
                        break;//Neu tim thay cai dau tien thi thoat khoi vong lap
                    }
                }
            }
        }

        public void LostFocusCommon()//Dung de bat label gan nhat
        {
            if (lbltemp != null)
            {
                for (int q = 0; q < odcontrol.Count; q++)
                {
                    if (odcontrol[q].controlname == lbltemp.Name)
                    {
                        lbltemp.ForeColor = odcontrol[q].oldcolor;
                        lbltemp.Font = odcontrol[q].oldfont;
                        break;
                    }
                }
            }
        }

        public void GotFocusCommon1(Control ctrlChild)// Dung bo sung label  canh control
        {
            if (ctrlChild is Button || ctrlChild is SimpleButton || ctrlChild.GetType().FullName == "DevExpress.XtraBars.Docking.DockPanel")
                return;
            if (ctrlChild.Name == "")
            {
                Point p = ctrlChild.Parent.Location;
                picIndicator.Location = new Point((int)p.X + ctrlChild.Parent.Size.Width + khoangcach, (int)p.Y);
                (ctrlChild.Parent.Parent).Controls.Add(picIndicator);
            }
            else
            {
                Point p = ctrlChild.Location;
                picIndicator.Location = new Point((int)p.X + ctrlChild.Size.Width + khoangcach, (int)p.Y);
                (ctrlChild.Parent).Controls.Add(picIndicator);
            }
            picIndicator.BringToFront();
        }
       Form enter_to_tabForm;
        public void key_enter(Form f1)
        {
            
            f1.KeyPreview = true;
            f1.KeyDown -= Keyenter_KeyDown;
            f1.KeyDown += Keyenter_KeyDown;
            this.enter_to_tabForm = f1;
        }
        private void Keyenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enter_to_tabForm.SelectNextControl(enter_to_tabForm.ActiveControl, true, true, true, true);
            }
        }
    }
}
