using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using HPA.CommonForm;

namespace HPA.Update
{
    public partial class UpdateFromFile : UserControl
    {
        public UpdateFromFile()
        {
            InitializeComponent();
        }
        public byte[] buffer;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog() { Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.PNG)|*.jpg; *.jpeg; *.gif; *.bmp; *.PNG" };
            if (open.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(open.FileName);
                pictureBox1.Image = bit;
                FileStream fileStream = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, (int)fileStream.Length);
                fileStream.Close();
            }
        }
        public void updateImage(string idmenu)
        {
           // EzSqlCollection.EzSql2 ex = new EzSqlCollection.EzSql2();
            BaseForm bf = new CommonForm.BaseForm();       
           
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
