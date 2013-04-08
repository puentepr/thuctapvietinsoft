using DevExpress.Xpf.Charts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Paradise5.ServiceReference1;
using System.Linq;
using DevExpress.Xpf.Grid;

namespace Paradise5
{
    public class CommonChart
    {
        static int mausac;
        #region TaoBieuDo
        public static ChartControl CreatPieChart(SolidColorBrush forecolor, string ChartTitle, List<ChartDataChartCommonData> dtchart)
        {
            mausac = 0;
            ChartControl abc = new ChartControl();
            SimpleDiagram2D dg1 = new SimpleDiagram2D();
            //liabc.Titles.Clear();
            //Tao Tile cho Chart
            Title nt = new Title();
            nt.Content = ChartTitle;
            nt.Foreground = forecolor;
            abc.Titles.Add(nt);
            //Tinh so Series
            List<string> countsr = (from p in dtchart group p by p.Series into g select g.Key).ToList();
            //Creat Diagram
            abc.Diagram = dg1;
            GridControl dtl = new GridControl();
            for (int i = 0; i < countsr.Count; i++)
            {
                PieSeries2D dgs1 = new PieSeries2D();
                dgs1.HoleRadiusPercent = 0;//Thiet lap khoang trong tu tam hinh tron den duong tron
                dgs1.ArgumentScaleType = ScaleType.Auto;
                foreach (ChartDataChartCommonData dr in dtchart)//Tao cac point
                {
                    if (dr.Series == countsr.ElementAt(i))
                    {
                        //Tao Series
                        SeriesPoint sr1 = new SeriesPoint();
                        sr1.Argument = dr.Agrument + ":" + dr.Value.ToString();
                        sr1.Value = dr.Value;
                        sr1.Tag = mausac.ToString();
                        dgs1.Points.Add(sr1);
                        mausac++;
                    }
                }
                dgs1.Label = new SeriesLabel();//Tao Label cho Diagram
                PieSeries.SetLabelPosition(dgs1.Label, PieLabelPosition.TwoColumns);
                dgs1.Label.RenderMode = LabelRenderMode.RectangleConnectedToCenter;
                dgs1.LabelsVisibility = true;//Hien thi Lablel cho tung vung
                PointOptions pn1 = new PointOptions();
                pn1.PointView = PointView.ArgumentAndValues;
                pn1.Pattern = "{A} ({V})";//Tao mau chu thich
                NumericOptions nbm1 = new NumericOptions();//Tao Kieu hien thi
                nbm1.Format = NumericFormat.Percent;
                pn1.ValueNumericOptions = nbm1;
                PieSeries2D.SetPercentOptions(pn1, new PercentOptions() { ValueAsPercent = true, PercentageAccuracy = 5 });//Quy dinh ty le phan tram chinh xac
                dgs1.PointOptions = pn1;
                dg1.Series.Add(dgs1);
                //Tao chu thich
                dgs1.LegendPointOptions = pn1;

            }
            abc.Legend = new Legend();
            //End tao chu thich
            //Set mau sac cho seriespont
            abc.CustomDrawSeriesPoint += abc_CustomDrawSeriesPoint;
            return abc;
        }

        public static ChartControl CreatXYChart(SolidColorBrush forecolor, string ChartTitle, List<ChartDataChartCommonData> dtchart)
        {
            mausac = 0;
            ChartControl abc = new ChartControl();
            XYDiagram2D dg1 = new XYDiagram2D();
            //Tao Tile cho Chart
            Title nt = new Title();
            nt.Content = ChartTitle;
            nt.Foreground = forecolor;
            abc.Titles.Add(nt);
            //Tinh so Series
            List<string> countsr = (from p in dtchart group p by p.Series into g select g.Key).ToList();
            //Creat Diagram
            abc.Diagram = dg1;
            //Begin tao guong
            Pane pane1 = new Pane();
            pane1.MirrorHeight = 100;//Do cao guong
            dg1.DefaultPane = pane1;
            //End tao guong
            //Begin set kieu bieu do
            for (int i = 0; i < countsr.Count; i++)
            {
                BarSideBySideSeries2D dgs1 = new BarSideBySideSeries2D() { DisplayName = countsr[i].ToString() };//Neu ko co DisplayName chu thich khong hien thi
                Quasi3DBar2DModel an1 = new Quasi3DBar2DModel();
                dgs1.Model = an1;
                foreach (ChartDataChartCommonData dr in dtchart)//Tao cac point
                {
                    if (dr.Series == countsr.ElementAt(i))
                    {
                        //Tao Series
                        SeriesPoint sr1 = new SeriesPoint();
                        sr1.Argument = dr.Agrument;
                        sr1.Value = dr.Value;
                        sr1.Tag = mausac.ToString();
                        dgs1.Points.Add(sr1);
                        mausac++;
                    }
                }
                SeriesLabel lbl1 = new SeriesLabel();
                dgs1.LabelsVisibility = true;//Hien thi Lablel cho tung vung
                lbl1.Indent = 10;
                lbl1.ConnectorThickness = 1;
                lbl1.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                dgs1.Label = lbl1;
                dg1.Series.Add(dgs1);
            }
            //Tao chu thich
            abc.Legend = new Legend()
            {
                VerticalPosition = VerticalPosition.BottomOutside,
                HorizontalPosition = HorizontalPosition.Center,
                Orientation = Orientation.Horizontal
            };
            //End tao chu thich
            return abc;
        }

        static void abc_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            string tagsr = e.SeriesPoint.Tag.ToString();
            switch (tagsr)
            {
                case ("5"):
                    e.DrawOptions.Color = Color.FromArgb(255, 95, 158, 160);
                    break;
                case ("7"):
                    e.DrawOptions.Color = Color.FromArgb(255, 144, 238, 144);
                    break;
                case ("8"):
                    e.DrawOptions.Color = Colors.Red;
                    break;
                case ("9"):
                    e.DrawOptions.Color = Color.FromArgb(255, 238, 130, 238);
                    break;
                case ("10"):
                    e.DrawOptions.Color = Colors.Purple;
                    break;
                case ("11"):
                    e.DrawOptions.Color = Color.FromArgb(255, 222, 184, 135);
                    break;
                case ("12"):
                    e.DrawOptions.Color = Colors.Blue;
                    break;
                case ("13"):
                    e.DrawOptions.Color = Color.FromArgb(255, 199, 199, 199);
                    break;
                case ("14"):
                    e.DrawOptions.Color = Colors.Green;
                    break;
                case ("15"):
                    e.DrawOptions.Color = Colors.Yellow;
                    break;
            }
        }
        #endregion
    }
}
