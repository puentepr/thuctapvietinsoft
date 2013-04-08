using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paradise5.Web
{
    public class ChartData
    {
        public struct ChartCommonData
        {
            public string Agrument;
            public string Series;
            public double Value;
            public ChartCommonData(string agrument, string series, double value)
            {
                Agrument = agrument;
                Series = series;
                Value = value;
            }

        }
        public struct ChartCommon
        {
            public string ChartTitle;
            public string ChartType;
            public List<ChartCommonData> ChartData;
            public ChartCommon(string charttitle, string charttype, List<ChartCommonData> chartdata)
            {
                ChartTitle = charttitle;
                ChartType = charttype;
                ChartData = chartdata;
            }
        }
    }
}