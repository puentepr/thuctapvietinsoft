using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Charts;
using System.Collections.Generic;

namespace Paradise5
{
    public class CommonChart
    {
        static int mausac;
        #region TaoBieuDo
        public static ChartControl CreatPieChar(ChartControl abc, Diagram dg1, PieSeries2D dgs1, SolidColorBrush forecolor, string ChartTitle, List<string> Agrument, List<double> value)
        {
            mausac = 0;
            //Tao Tile cho Chart
            Title nt = new Title();
            nt.Content = ChartTitle;
            nt.Foreground = forecolor;
            abc.Titles.Add(nt);
            //Creat Diagram
            abc.Diagram = dg1;
            dgs1.HoleRadiusPercent = 0;//Thiet lap khoang trong tu tam hinh tron den duong tron
            dgs1.ArgumentScaleType = ScaleType.Auto;
            for (int i = 0; i < Agrument.Count; i++)
            {
                mausac++;
                SeriesPoint sr1 = new SeriesPoint();
                sr1.Argument = Agrument[i];
                sr1.Value = value[i];
                sr1.Tag = mausac.ToString();
                dgs1.Points.Add(sr1);
            }
            dgs1.Label = new SeriesLabel();//Tao Label cho Diagram
            PieSeries.SetLabelPosition(dgs1.Label, PieLabelPosition.Outside);
            dgs1.Label.RenderMode = LabelRenderMode.RectangleConnectedToCenter;
            //dgs1.LabelsVisibility = true;//Hien thi Lablel cho tung vung
            PointOptions pn1 = new PointOptions();
            pn1.PointView = PointView.ArgumentAndValues;
            pn1.Pattern = "{A} ({V})";//Tao mau chu thich
            NumericOptions nbm1 = new NumericOptions();//Tao Kieu hien thi
            nbm1.Format = NumericFormat.Percent;
            pn1.ValueNumericOptions = nbm1;
            PieSeries2D.SetPercentOptions(pn1, new PercentOptions() { PercentageAccuracy = 2, ValueAsPercent = false });//Quy dinh hien thi may so phan thap phan
            dgs1.PointOptions = pn1;
            dg1.Series.Add(dgs1);
            //Tao chu thich
            dgs1.LegendPointOptions = pn1;
            abc.Legend = new Legend();
            //End tao chu thich
            //Set mau sac cho seriespont
            abc.CustomDrawSeriesPoint += abc_CustomDrawSeriesPoint;
            return abc;
        }

        public static ChartControl CreatXYChar(ChartControl abc, XYDiagram2D dg1, BarSideBySideSeries2D dgs1, SolidColorBrush forecolor, string ChartTitle, List<string> Agrument, List<double> value)
        {
            abc.Titles.Clear();
            //Tao Tile cho Chart
            Title nt = new Title();
            nt.Content = ChartTitle;
            nt.Foreground = forecolor;
            abc.Titles.Add(nt);
            //Creat Diagram
            abc.Diagram = dg1;
            for (int i = 0; i < Agrument.Count; i++)
            {
                SeriesPoint sr1 = new SeriesPoint();
                sr1.Argument = Agrument[i];
                sr1.Value = value[i];
                dgs1.Points.Add(sr1);
            }
            SeriesLabel lbl1 = new SeriesLabel();
            dgs1.LabelsVisibility = true;//Hien thi Lablel cho tung vung
            lbl1.Indent = 10;
            lbl1.ConnectorThickness = 1;
            lbl1.ResolveOverlappingMode = ResolveOverlappingMode.Default;
            dgs1.Label = lbl1;
            dg1.Series.Add(dgs1);
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


