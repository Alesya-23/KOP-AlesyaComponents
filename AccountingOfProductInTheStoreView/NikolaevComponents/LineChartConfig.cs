using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelComponents
{
    public class LineChartConfig
    {
        public string FilePath { get; set; }
        public string Header { get; set; }
        public string ChartTitle { get; set; }

        public List<List<int>> XValues { get; set; }
        public List<String> YValues { get; set; }
        public List<string> SeriesNames { get; set; }

        public LegendPosition Position { get; set; }
    }
}