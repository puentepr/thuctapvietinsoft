
#region Using NameSpace
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;
using HPA.Common;
#endregion

namespace HPA.Report
{
	public class CReportView : HPA.Component.Framework.CBaseForm
	{
		#region Member Variables
			private CrystalDecisions.Windows.Forms.CrystalReportViewer m_ReportView;
			private CrystalDecisions.CrystalReports.Engine.ReportDocument m_ReportDoc;

			protected string			m_ReportName	= String.Empty;
			protected string			m_ReportPath	= String.Empty;

			protected object[]			m_ParamNames;
			protected object[]			m_ParamValues;
			protected int				m_PLength		= 0;
			//protected int				m_FLength		= 0;
		
			protected object[] m_ParamsNameAndValue;
			private string				m_strSubDir		= "\\Templates\\";
		#endregion

		#region Constructors
            
			public CReportView()
			{
				// This call is required by the Windows Form Designer.
				InitializeComponent();
			}
		#endregion

		#region Designer generated code

			private System.ComponentModel.IContainer components = null;

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if (components != null) 
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}

			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CReportView));
				this.m_ReportView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
				this.m_ReportDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
				this.SuspendLayout();
				// 
				// m_ReportView
				// 
				this.m_ReportView.AccessibleDescription = resources.GetString("m_ReportView.AccessibleDescription");
				this.m_ReportView.AccessibleName = resources.GetString("m_ReportView.AccessibleName");
				this.m_ReportView.ActiveViewIndex = -1;
				this.m_ReportView.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("m_ReportView.Anchor")));
				this.m_ReportView.AutoScroll = ((bool)(resources.GetObject("m_ReportView.AutoScroll")));
				this.m_ReportView.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("m_ReportView.AutoScrollMargin")));
				this.m_ReportView.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("m_ReportView.AutoScrollMinSize")));
				this.m_ReportView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_ReportView.BackgroundImage")));
				this.m_ReportView.DisplayBackgroundEdge = ((bool)(resources.GetObject("m_ReportView.DisplayBackgroundEdge")));
				this.m_ReportView.DisplayGroupTree = ((bool)(resources.GetObject("m_ReportView.DisplayGroupTree")));
				this.m_ReportView.DisplayToolbar = ((bool)(resources.GetObject("m_ReportView.DisplayToolbar")));
				this.m_ReportView.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("m_ReportView.Dock")));
				this.m_ReportView.Enabled = ((bool)(resources.GetObject("m_ReportView.Enabled")));
				this.m_ReportView.EnableDrillDown = ((bool)(resources.GetObject("m_ReportView.EnableDrillDown")));
				this.m_ReportView.Font = ((System.Drawing.Font)(resources.GetObject("m_ReportView.Font")));
				this.m_ReportView.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("m_ReportView.ImeMode")));
				this.m_ReportView.Location = ((System.Drawing.Point)(resources.GetObject("m_ReportView.Location")));
				this.m_ReportView.Name = "m_ReportView";
				this.m_ReportView.ReportSource = null;
				this.m_ReportView.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("m_ReportView.RightToLeft")));
				this.m_ReportView.ShowCloseButton = ((bool)(resources.GetObject("m_ReportView.ShowCloseButton")));
				this.m_ReportView.ShowExportButton = ((bool)(resources.GetObject("m_ReportView.ShowExportButton")));
				this.m_ReportView.ShowGotoPageButton = ((bool)(resources.GetObject("m_ReportView.ShowGotoPageButton")));
				this.m_ReportView.ShowGroupTreeButton = ((bool)(resources.GetObject("m_ReportView.ShowGroupTreeButton")));
				this.m_ReportView.ShowPageNavigateButtons = ((bool)(resources.GetObject("m_ReportView.ShowPageNavigateButtons")));
				this.m_ReportView.ShowPrintButton = ((bool)(resources.GetObject("m_ReportView.ShowPrintButton")));
				this.m_ReportView.ShowRefreshButton = ((bool)(resources.GetObject("m_ReportView.ShowRefreshButton")));
				this.m_ReportView.ShowTextSearchButton = ((bool)(resources.GetObject("m_ReportView.ShowTextSearchButton")));
				this.m_ReportView.ShowZoomButton = ((bool)(resources.GetObject("m_ReportView.ShowZoomButton")));
				this.m_ReportView.Size = ((System.Drawing.Size)(resources.GetObject("m_ReportView.Size")));
				this.m_ReportView.TabIndex = ((int)(resources.GetObject("m_ReportView.TabIndex")));
				this.m_ReportView.Visible = ((bool)(resources.GetObject("m_ReportView.Visible")));
				// 
				// m_ReportDoc
				// 
				this.m_ReportDoc.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
				this.m_ReportDoc.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
				this.m_ReportDoc.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper;
				this.m_ReportDoc.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;
				// 
				// CReportView
				// 
				this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
				this.AccessibleName = resources.GetString("$this.AccessibleName");
				this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
				this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
				this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
				this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
				this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
				this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
				this.Controls.Add(this.m_ReportView);
				this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
				this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
				this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
				this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
				this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
				this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
				this.MinimizeBox = false;
				this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
				this.Name = "CReportView";
				this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
				this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
				this.Text = resources.GetString("$this.Text");
				this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
				this.ResumeLayout(false);

			}
		#endregion

		#region Private functions
			private bool IsFileValided()
			{
				return System.IO.File.Exists(m_ReportPath);
			}

			private void GetParamNameAndValue(object[] inParams)
			{	
				m_ParamsNameAndValue = inParams;
				for (int i = 0; i < m_PLength; i++)
				{
					// Check the name first.
					object temp = inParams[2*i];
					if ((temp == null) ||
						(!(temp is string)) ||
						(((string)temp).Trim().Length == 0 ))
						throw new Exception("Parameter " + i + "'s name must be a string, and cannot be null or empty");
					else
					{
						string name = ((string)temp).Trim();
						object val = inParams[2*i + 1];

						//Add to arrays
						m_ParamNames[i] = name;
						m_ParamValues[i] = val;
					}
				}
			}

			private void LogonToReport(string server, string database, string ID, string password)
			{

				TableLogOnInfo logonInfo = new TableLogOnInfo();
				//SubreportObject subReportObj;
				//string subReportName;
				SubreportObject subReportObj;

				
				//TableLogOnInfos loS = new TableLogOnInfos();
				// Set the logon information for each table.
				foreach(Table table in m_ReportDoc.Database.Tables)
				{
					// Get the TableLogOnInfo object.
					logonInfo = table.LogOnInfo;
					// Set the server or ODBC data source name, database name, 
					// user ID, and password.
					logonInfo.ConnectionInfo.ServerName = server;
					logonInfo.ConnectionInfo.DatabaseName = database;
					logonInfo.ConnectionInfo.UserID = ID;
					logonInfo.ConnectionInfo.Password = password;
					// Apply the connection information to the table.
					table.ApplyLogOnInfo(logonInfo);

					// check if logon was successful 
					// if TestConnectivity returns false, check 
					// logon credentials 

					// Added by NTuan: 18-Feb-2006
					// Must reset the table location
					// to make the logon info fully active
					if (table.TestConnectivity()) 
					{ 
						// drop fully qualified table location 
						if (table.Location.IndexOf(".") > 0) 
						{ 
							table.Location = table.Location.Substring(table.Location.LastIndexOf(".") + 1); 
						} 
						else table.Location = table.Location; 					
					} 
					// From now, m_ReportDoc really has new datasource informations
					
				}

				//Get All sub report				
				foreach (ReportObject obj in 
					m_ReportDoc.ReportDefinition.ReportObjects) 
				{ 
					if (obj.Kind == ReportObjectKind.SubreportObject) 
					{ 
						subReportObj = (SubreportObject)obj;
						ReportDocument subReport = subReportObj.OpenSubreport(subReportObj.SubreportName);
						// for each table apply connection info 
						foreach (Table tbl in subReport.Database.Tables) 
						{ 							
							tbl.ApplyLogOnInfo(logonInfo); 

							if (tbl.TestConnectivity()) 
								// drop fully qualified table location 
								if (tbl.Location.IndexOf(".") > 0) 
								{ 
									tbl.Location = tbl.Location.Substring(tbl.Location.LastIndexOf(".") + 1); 
								} 
								else tbl.Location = tbl.Location; 
						}
					} 
				} 
				
			} 

			private void LoadReport()
			{

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    ParameterFieldDefinition _paramF = null; ;

                    ParameterDiscreteValue _disValue = new ParameterDiscreteValue();

                    ParameterValues _cValues = null;
                    if (m_struct.Action == SReport.EAction.SAVE_TO_DISK)
                        this.Visible = false;
                    //Test call report by old or new method
                    if (m_ReportName.Substring(m_ReportName.Length - 6, 2).Equals("NT"))
                    {
                        //New Code 
                        m_ReportDoc.Load(m_ReportPath, OpenReportMethod.OpenReportByTempCopy);
                        //clsReportEngine objReportEngine = new clsReportEngine(this.DBEngine, m_ReportName,m_ParamNames,m_ParamValues);
                        clsReportEngine objReportEngine = new clsReportEngine(this.DBEngine, m_ReportName, m_ParamsNameAndValue);
                        m_ReportDoc.SetDataSource(objReportEngine.getDataSetValue());
                        m_ReportView.ReportSource = m_ReportDoc;
                        this.Cursor = Cursors.Default;
                        m_ReportView.Zoom(1);  //Fix
                        //End New Code
                    }
                    else
                    {
                        // * OLD CODE
                        //m_ReportDoc.Load(m_ReportPath);  
                        m_ReportDoc.Load(m_ReportPath, OpenReportMethod.OpenReportByTempCopy);

                        /*
                        LogonToReport(DBEngine.DataSourceName, 
                            "",
                            DBEngine.User,
                            DBEngine.Password);
                        */
                        LogonToReport(DBEngine.Server,
                            DBEngine.Database,
                            DBEngine.User,
                            DBEngine.Password);

                        // ============================================================
                        // Get the ParameterFieldDefinition object by name.
                        if (m_PLength != 0)
                        {
                            for (int i = 0; i < m_PLength; i++)
                            {
                                _paramF =
                                    m_ReportDoc.DataDefinition.ParameterFields[m_ParamNames[i].ToString()];
                                _cValues = _paramF.CurrentValues;

                                _disValue.Value = (object)m_ParamValues[i];

                                _cValues.Add(_disValue);

                                _paramF.ApplyCurrentValues(_cValues);
                            }
                        }
                        if (m_struct.Action == SReport.EAction.SAVE_TO_DISK)
                        {
                            m_ReportDoc.ExportToDisk(ExportFormatType.PortableDocFormat,m_struct.SaveToFileName);
                            m_ReportDoc.Dispose();
                            this.Close();
                            return;
                        }
                        //m_ReportDoc.SaveAs("test.rpt", ReportFileFormat.VSNetFileFormat);
                        m_ReportView.ReportSource = m_ReportDoc;

                        this.Cursor = Cursors.Default;

                        if (m_struct.Action == HPA.Common.SReport.EAction.PREVIEW)
                        {
                            m_ReportView.Zoom(1);
                        }
                        else if (m_struct.Action == HPA.Common.SReport.EAction.PRINT)
                        {
                            m_ReportView.PrintReport();
                            this.Close();
                        }
                        //* END OLD CODE

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    throw e;
                }
			}
		#endregion

		#region Envent Handlers
		#endregion

		#region Property
			// set sub directory to locate the report file
			public string SubDir
			{
				set {m_strSubDir = value;}
			}
		#endregion

		#region Override
			public override void SetData(object objParam)
			{
				if (objParam == null)
					return;

				m_struct = (HPA.Common.SReport)objParam;

				//MessageBox.Show("Set data in Report view");
			}

			protected override void OnLoad(EventArgs e)
			{
				base.OnLoad (e);

				//MessageBox.Show("Start loading report view");

				// Initialise report name
				m_ReportName = m_struct.ReportName;

				if(m_ReportName != String.Empty)
				{
					m_ReportPath = Application.StartupPath + m_strSubDir + m_ReportName;
				}
				else
				{
					throw new Exception("Report name must not be null");
				}

				if (m_struct.Parameters.Length == 0)
				{
					//Do nothing
				}
				else if (m_struct.Parameters.Length % 2 == 1)
					throw new Exception("The number of raw input parameters is not even");
				else
				{
					m_PLength = m_struct.Parameters.Length/2;
					//m_FLength = m_struct.Formulas.Length/2;

					//Init Param name and values
					m_ParamNames = new String[m_PLength];

					m_ParamValues = new Object[m_PLength];

					// Get Parameter names and values
					GetParamNameAndValue(m_struct.Parameters);
				}

				//MessageBox.Show("Load report"); 

				if(IsFileValided())
					LoadReport();
				else
					throw new Exception("Report file does not existed");
			}
		#endregion

		#region Variable
			HPA.Common.SReport m_struct;
		#endregion
	}
}

