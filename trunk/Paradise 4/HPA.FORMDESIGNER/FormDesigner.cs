using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Data;
using System.ComponentModel;
using HPA.Common;

namespace HPA.FORMDESIGNER
{
    public partial class FormDesigner : HPA.Component.Framework.CBaseForm
    {
        private DesignerHostImpl host;

        private Form form;
        private IServiceContainer serviceContainer;

        public FormDesigner()
        {
            InitializeComponent();
            
        }

        private void GenerateControls()
        {
            try
            {
                form = (Form)host.CreateComponent(typeof(Form), null);
                form.Controls.Clear();
                form.TopLevel = false;
                form.Text = "Design view";
                DataTable dtControlsList = DBEngine.execReturnDataTable("FormLayout_ControlList","@FormName",this.Name);
                if (dtControlsList != null && dtControlsList.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtControlsList.Rows)
                    {
                        if (dr["ControlName"] != DBNull.Value && !dr["ControlName"].ToString().Trim().Equals(string.Empty) && !dr["ControlName"].ToString().Equals(this.Name))
                        {
                            Control ctr = (Control)host.CreateComponent(dr["SystemType"].ToString(), dr["ControlName"].ToString());
                            ctr.Location = new Point((int)dr["LocationX"], (int)dr["LocationY"]);
                            ctr.Text = HPA.Common.UIMessage.Get_Message(ctr.Name);
                            ctr.Size = new Size((int)dr["Width"], (int)dr["Height"]);
                            ctr.Visible = Convert.ToBoolean(dr["Visible"]);
                            ctr.Enabled = Convert.ToBoolean(dr["Enabled"]);
                            if (dr[CommonConst.TabIndex] != DBNull.Value)
                                ctr.TabIndex = Convert.ToInt32(dr[CommonConst.TabIndex]);
                            // set font style
                            if (dr["FontName"] != DBNull.Value)
                            {
                                HPA.Common.LayOutControlHelper.SetFontStyle(ref ctr, dr);
                            }
                            if (dr[CommonConst.ForeColor] != DBNull.Value)
                            {
                                HPA.Common.LayOutControlHelper.SetForeColor(ref ctr, dr);
                            }
                            if (ctr is PictureBox)
                            {
                                ((PictureBox)ctr).Image = CImageUtility.byteArrayToImage((byte[])dr["Image"]);
                            }
                            form.Controls.Add(ctr);
                        }
                        else if (dr["ControlName"].ToString().Equals(this.Name) || (dr["SystemType"].ToString().Equals("System.Windows.Forms.SplitterPanel,System.Windows.Forms") && dr["ControlName"].ToString().Trim().Equals(string.Empty)))
                        {
                            form.Size = new Size((int)dr["Width"], (int)dr["Height"]);
                            form.Name = dr["FormName"].ToString();
                        }
                    }
                    foreach (DataRow dr in dtControlsList.Rows)
                    {
                        if (dr["ParentControl"] == DBNull.Value)
                            continue;
                        string PrentCtrName = dr["ParentControl"].ToString();
                        if (PrentCtrName.Trim().Equals(string.Empty))
                            PrentCtrName = form.Name;
                        if (!PrentCtrName.Equals(form.Name) && !dr["ControlName"].ToString().Trim().Equals(string.Empty))
                        {
                            if (form.Controls.Find(PrentCtrName, true).Length > 0 && form.Controls.Find(dr["ControlName"].ToString(), true).Length > 0)
                                form.Controls.Find(PrentCtrName, true)[0].Controls.Add(form.Controls.Find(dr["ControlName"].ToString(), true)[0]);
                        }
                    }
                }
                IRootDesigner rootDesigner = (IRootDesigner)host.GetDesigner(form);
                Control designView = (Control)rootDesigner.GetView(ViewTechnology.Default);
                designView.Dock = DockStyle.Fill;
                designSurfacePanel.Controls.Add(designView);

            }
            catch (Exception ex)
            {
                HPA.Common.Helper.LogError(ex, this.Text, "GenerateControls");
            }
        }
        public override void SetData(object objParam)
        {
            try
            {
                this.Name = objParam.ToString();
            }
            catch (Exception e)
            {
                HPA.Common.Helper.ShowException(e, this.Name + ".SetData()", null);
                return;
            }
        }
        private void AddBaseServices()
        {
            mainForm = pnlToolBox;
            Control ctrl = pnlToolBox.GetNextControl(null, true); //Get First Control
            do
            {
                if (ctrl.Text != "Design Mode" && ctrl.Text != "Control Mode" && (ctrl.Name != "ResizeBox"))
                {
                    SetEvent(ctrl);
                }
                ctrl = pnlToolBox.GetNextControl(ctrl, true);
            } while (ctrl != null);

            pnlToolBox.Paint -= new PaintEventHandler(pnlToolBox_Paint);
            pnlToolBox.MouseMove -= new MouseEventHandler(pnlToolBox_MouseMove);
            pnlToolBox.MouseUp -= new MouseEventHandler(pnlToolBox_MouseUp);
            pnlToolBox.Paint += new PaintEventHandler(pnlToolBox_Paint);
            pnlToolBox.MouseMove += new MouseEventHandler(pnlToolBox_MouseMove);
            pnlToolBox.MouseUp += new MouseEventHandler(pnlToolBox_MouseUp);

        }

        private void SetEvent(Control ctrl)
        {
            ctrl.MouseDown -= new MouseEventHandler(ctrl_MouseDown);
            ctrl.MouseDown += new MouseEventHandler(ctrl_MouseDown);

        }
        private Control mainForm = null;
        private Rectangle controlImage;
        private bool controlDragStarted = false;
        private Control controlUnderDrag = null;
        private Size mouseOffset;
        void pnlToolBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && controlDragStarted)
            {
                controlDragStarted = false;
                mainForm.Capture = false;
                mainForm.Cursor = Cursors.Default;

                GraphicsPath myGraphicsPath = new GraphicsPath();
                Rectangle tempRectangle = new Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4);
                myGraphicsPath.AddRectangle(tempRectangle);
                System.Drawing.Region rgn = new Region(myGraphicsPath);

                controlImage.Height = 0; controlImage.Width = 0;
                mainForm.Invalidate(rgn);
                if (controlImage.X < pnlToolBox.Width)
                    return;
                if (controlUnderDrag is DevExpress.XtraEditors.LabelControl)
                {
                    DevExpress.XtraEditors.LabelControl lbl = (DevExpress.XtraEditors.LabelControl)host.CreateComponent(typeof(DevExpress.XtraEditors.LabelControl), string.Format("lbl{0}_{1}", this.Name, DateTime.Now.Second + DateTime.Now.Minute * 60));
                    lbl.Text = "Lable";
                    lbl.Size = controlUnderDrag.Size;
                    form.Controls.Add(lbl);
                    lbl.Location = controlImage.Location;
                }
                if (controlUnderDrag is PictureBox)
                {
                    PictureBox pic = (PictureBox)host.CreateComponent(typeof(PictureBox), string.Format("pic{0}_{1}", this.Name, DateTime.Now.Second + DateTime.Now.Minute * 60));
                    form.Controls.Add(pic);
                    pic.Size = controlUnderDrag.Size;
                    pic.Location = controlImage.Location;
                }
                if (controlUnderDrag is GroupBox)
                {
                    GroupBox grb = (GroupBox)host.CreateComponent(typeof(GroupBox), string.Format("grb{0}_{1}", this.Name, DateTime.Now.Second + DateTime.Now.Minute * 60));
                    grb.Text = "Group box";
                    grb.Size = controlUnderDrag.Size;
                    form.Controls.Add(grb);
                    grb.Location = controlImage.Location;
                }
            }
        }

        void pnlToolBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (controlDragStarted)
            {
                GraphicsPath myGraphicsPath = new GraphicsPath();
                Rectangle tempRectangle = new Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4);
                myGraphicsPath.AddRectangle(tempRectangle);
                System.Drawing.Region rgn = new Region(myGraphicsPath);

                controlImage = new Rectangle(e.Location.X - mouseOffset.Width, e.Location.Y - mouseOffset.Height, controlImage.Width,
                    controlImage.Height);

                mainForm.Invalidate(rgn);

                myGraphicsPath.Dispose();
                myGraphicsPath = new GraphicsPath();
                rgn.Dispose();
                tempRectangle = new Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4);
                rgn = new Region(tempRectangle);
                mainForm.Invalidate(rgn);
            }
        }
        void pnlToolBox_Paint(object sender, PaintEventArgs e)
        {
            if (controlImage != null && controlDragStarted)
            {
                e.Graphics.DrawRectangle(Pens.Green, controlImage);
            }
        }
        void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //find out which control is being dragged
                controlUnderDrag = mainForm.GetChildAtPoint(((Control)sender).Location + new Size(e.Location.X, e.Location.Y));
                if (controlUnderDrag != null)
                {
                    mainForm.Capture = true; //capture mouse
                    mainForm.Cursor = Cursors.Hand;

                    controlImage = new Rectangle(controlUnderDrag.Location, controlUnderDrag.Size);
                    mouseOffset = new Size(e.Location.X, e.Location.Y);

                    Rectangle tempRectangle = new Rectangle(controlImage.X - 2, controlImage.Y - 2, controlImage.Width + 4, controlImage.Height + 4);
                    GraphicsPath myGraphicsPath = new GraphicsPath();
                    myGraphicsPath.AddRectangle(tempRectangle);
                    System.Drawing.Region rgn = new Region(myGraphicsPath);
                    mainForm.Invalidate(rgn);

                    controlDragStarted = true;
                }
            }
        }
        private void selectionService_SelectionChanged(object sender, EventArgs e)
        {
            ISelectionService selectionService = host.GetService(typeof(ISelectionService)) as ISelectionService;

            if (propertyGrid != null && selectionService != null)
            {
                ICollection selectedComponents = selectionService.GetSelectedComponents();
                // if nothing is selected, just select the root component
                if (selectedComponents == null || selectedComponents.Count == 0)
                {
                    propertyGrid.SelectedObjects = new object[] { host.RootComponent };
                }
                // we have to copy over the selected components list
                // into an array and then set the selectedObjects property
                object[] selections = new Object[selectedComponents.Count];
                selectedComponents.CopyTo(selections, 0);
                propertyGrid.SelectedObjects = selections;
            }
        }

        private void FormDesigner_Load(object sender, EventArgs e)
        {
            AddBaseServices();

            // create host
            host = new DesignerHostImpl(serviceContainer);
            GenerateControls();

            // we need to subscribe to selection changed events so 
            // that we can update our properties grid

            ISelectionService selectionService = host.GetService(typeof(ISelectionService)) as ISelectionService;
            selectionService.SelectionChanged += new EventHandler(selectionService_SelectionChanged);
            // activate the host
            host.Activate();
            btnSave.Text = UIMessage.Get_Message(btnSave.Name);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HPA.Common.LayOutControlHelper.SaveDesignForm(form.Controls);
                UIMessage.ShowMessage(CommonConst.DATASAVED_SUCCESSFULLY, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                HPA.Common.Helper.ShowException(ex, ex.Message, this.Text);
            }
            
        }

    }
}