using System.Collections.Generic;

namespace ClassLibraryPluginsConfigurations.Models
{
    public class ChartConfigModel
    {
        public string Title { get; set; }
        public string ChartTitle { get; set; }
        public LegendPosition LegendPosition { get; set; }
        public List<ChartData> ChartData { get; set; }
    }
}