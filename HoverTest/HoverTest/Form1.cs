using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HoverTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Set focus cho cac control
            BUS bu = new BUS();
            bu.LoadAddGotFocus( this);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //void ctrChid_GotFocus(object sender, EventArgs e)
        //{
        //    ProcessControls(this);
        //}
        //private void LoadAddGotFosus(Control ctrl)
        //{
        //    foreach (Control ctrChid in ctrl.Controls)
        //    {
        //        ctrChid.GotFocus += ctrChid_GotFocus;
        //        if (ctrChid.Controls.Count > 0)
        //        LoadAddGotFosus(ctrChid);
        //    }

        //}
        //private void ProcessControls(Control ctrl)
        //{
        //    foreach (Control ctrlChild in ctrl.Controls)
        //    {
        //        if (ctrlChild.Focused == true)
        //        {
        //            Point p = ctrlChild.Location;
        //            Point plbl = p - new Size(10, -5);  //    tuy  
        //            Control c = ctrlChild.Parent.GetChildAtPoint(plbl);

        //            if (c is Label)
        //            {
        //                Color[] clr = new Color[] 
        //                    { 
        //                     Color.Blue
        //                    ,Color.Black
        //                    };
        //                for (Int32 i = 0; i < clr.Length; i++)
        //                    if (c.ForeColor == clr[i])
        //                    {
        //                        c.ForeColor = (i == clr.Length - 1 ? clr[0] : clr[i + 1]);
        //                        break;
        //                    }

        //                c.Font = new Font(FontFamily.GenericSerif, 15.0f);
                        
        //            }
        //        }
        //        else
        //        {
        //            Point p = ctrlChild.Location;
        //            Point plbl = p - new Size(10, -5);
        //            Control c = ctrlChild.Parent.GetChildAtPoint(plbl);
        //            if (c is Label)
        //            {
        //                c.ForeColor = Color.Black;
        //                c.Font = new Font(FontFamily.GenericSerif, 8.25f);
        //            }
        //        }
        //        if (ctrlChild.Controls.Count > 0)
        //            ProcessControls(ctrlChild);
        //    }
        //}
    }
}
