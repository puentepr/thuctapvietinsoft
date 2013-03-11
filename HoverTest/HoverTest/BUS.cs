using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HoverTest
{
    public class BUS
    {
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
        int max = 200;//Khoang cach tu control den label gan nhat;
        int min = 10;//Khoang cach tu control den label xa nhat;
        int duoi = -5;//Khoang cach tinh tu tren xuong cua control den label;

        List<OldControl> odcontrol = new List<OldControl>();

        public void LoadAddGotFocus(Control ctrl)
        {
            if (temp == null)
            { temp = ctrl; }
            SaveData(temp);
            tm.Interval = 500;
            tm.Tick += tm_Tick;
            tm.Start();
            //Neu khong dung timer
            //foreach (Control ctrChid in ctrl.Controls)
            //{
            //    ctrChid.GotFocus += ctrChid_GotFocus;
            //    if (ctrChid.Controls.Count > 0)
            //    {
            //        LoadAddGotFocus(ctrChid);
            //    }

            //}
        }

        void SaveData(Control ctrl)
        {
            foreach (Control ctrChid in ctrl.Controls)
            {
                odcontrol.Add(new OldControl(ctrChid.ForeColor, ctrChid.Font, ctrChid.Name));
                if (ctrChid.Controls.Count > 0)
                {
                    SaveData(ctrChid);
                }

            }
        }
        void tm_Tick(object sender, EventArgs e)
        {
            ProcessControls(temp);
                    
        }
        public void ctrChid_GotFocus(object sender, EventArgs e)
        {
            ProcessControls(temp);   
        }
        public void ProcessControls(Control ctrl)
        {
            foreach (Control ctrlChild in ctrl.Controls)
            {
                if (ctrlChild.Focused == true)
                {
                    Point p = ctrlChild.Location;
                    for (int i = min; i < max; i++)// Tim label trong khoang cach chi dinh
                    {
                        Point plbl = p - new Size(i, duoi);  //    tuy 
                        Control c = ctrlChild.Parent.GetChildAtPoint(plbl);

                        if (c is Label &&c.Visible==true)
                        {
                            Color[] clr = new Color[] 
                            { 
                             Color.Gray
                            ,Color.Black
                            };
                            for (Int32 k = 0; k < clr.Length; k++)
                            {
                                if (c.ForeColor == clr[k])
                                {
                                    c.ForeColor = (k == clr.Length - 1 ? clr[0] : clr[k + 1]);
                                    break;
                                }
                                else c.ForeColor = Color.Black;
                            }
                            c.Font = new Font(FontFamily.GenericSerif, 15.0f);
                            break;//Neu tim thay cai dau tien thi thoat khoi vong lap
                        }
                    }
                }
                else //Set lai font cho label khi mat focus;
                {
                    Point p = ctrlChild.Location;
                    for (int i = min; i < max; i++)
                    {
                        Point plbl = p - new Size(i, duoi);  //    tuy 
                        Control c = ctrlChild.Parent.GetChildAtPoint(plbl);
                        if (c is Label&&c.Visible==true)
                        {
                            for (int q = 0; q < odcontrol.Count; q++)
                            {
                                if (odcontrol[q].controlname == c.Name)
                                {
                                    c.ForeColor = odcontrol[q].oldcolor;
                                    c.Font = odcontrol[q].oldfont;
                                    break;
                                }
                            }
                            //c.ForeColor = Color.Black;
                            //c.Font = new Font(FontFamily.GenericSerif, 8.25f);
                            break;
                            
                        }
                    }
                }
                if (ctrlChild.Controls.Count > 0)
                    ProcessControls(ctrlChild);
            }
        }

    }
}
 