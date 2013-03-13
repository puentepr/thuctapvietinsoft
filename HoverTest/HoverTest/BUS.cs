using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HoverTest
{
    public class BUS
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
        public Control temp;
        public Control temp1;
        public Control lbltemp;
        public Label lbltemp1= new Label();
        string lbltext = "Focus";
        Color lblcolor = Color.Black;
        Font lblfont = new Font(FontFamily.GenericSerif, 15.0f);
        int khoangcach = 5;
        int max = 200;//Khoang cach tu control den label gan nhat(*)
        int min = 30;//Khoang cach tu control den label xa nhat(*)
        int duoi = -5;//Khoang cach tinh tu tren xuong cua control den label(*)                
        List<OldControl> odcontrol = new List<OldControl>();//(*)

        public void LoadAddGotFocus(Control ctrl)
        {
            if (temp == null)
            { 
                temp = ctrl;
                lbltemp1.Text = lbltext;
                lbltemp1.ForeColor = lblcolor;
                lbltemp1.Font = lblfont;
                tm.Interval = 500;
                tm.Tick += tm_Tick;
            }
            //SaveData(temp);//Dung luu lai thiet ke ban dau cua cac control(*)
            //Neu khong dung timer
            foreach (Control ctrChid in ctrl.Controls)
            {
                if (!(ctrChid is Label || ctrChid is LabelControl))
                {
                    ctrChid.GotFocus += ctrChid_GotFocus;
                    //ctrChid.LostFocus += ctrChid_LostFocus;//Khoi phuc lai control theo thiet ke ban dau(*)
                }
                if (ctrChid.Controls.Count > 0)
                {
                    LoadAddGotFocus(ctrChid);
                }

            }
            tm.Start();
            
        }

        void ctrChid_LostFocus(object sender, EventArgs e)
        {
            LostFocusCommon();
        }

        void SaveData(Control ctrl)
        {
            foreach (Control ctrChid in ctrl.Controls)
            {
                //odcontrol.Add(new OldControl(ctrChid.ForeColor, ctrChid.Font, ctrChid.Name));(*)
                if (ctrChid.Controls.Count > 0)
                {
                    SaveData(ctrChid);
                }

            }
        }
        void tm_Tick(object sender, EventArgs e)
        {
            //Ham thay doi mau label theo cach bat label(*)
            //if (lbltemp != null)
            //{
            //    ChangeColor(lbltemp);

            //}
            ChangeColor(lbltemp1);//Ham thay doi mau label theo cach add label
        }
        void ChangeColor(Control c)
        {
            if (c.ForeColor == Color.Gray)
            {
                c.ForeColor = Color.Black;
            }
            else if (c.ForeColor == Color.Black)
            {
                c.ForeColor = Color.Gray;
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
             
            if (ctrlChild.Name=="")
            {
                Point p = ctrlChild.Parent.Location;
                for (int i = min; i < max; i++)// Tim label trong khoang cach chi dinh
                {
                    Point plbl = p - new Size(i, duoi);  //    tuy 
                    Control c = (ctrlChild.Parent).Parent.GetChildAtPoint(plbl);

                    if ((c is Label || c is DevExpress.XtraEditors.LabelControl) && c.Visible == true)
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

                    if ((c is Label || c is DevExpress.XtraEditors.LabelControl) && c.Visible == true)
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
            if (ctrlChild.Name == "")
            {
                Point p = ctrlChild.Parent.Location;
                lbltemp1.Location = new Point((int)p.X + ctrlChild.Parent.Size.Width + khoangcach, (int)p.Y);
                (ctrlChild.Parent.Parent).Controls.Add(lbltemp1);
            }
            else
            {
                Point p = ctrlChild.Location;
                lbltemp1.Location = new Point((int)p.X + ctrlChild.Size.Width + khoangcach, (int)p.Y);
                (ctrlChild.Parent).Controls.Add(lbltemp1);
            }
        }
    }
}
 