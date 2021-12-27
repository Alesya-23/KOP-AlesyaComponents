using System.Collections.Generic;

namespace ClassLibraryPluginsConfigurations.Models
{
    public class TableConfigModel<T>
    {
        public string Title { get; set; }
        public List<ColumnInfoConfigModel> ColumnInfo { get; set; }
        public List<T> Objects { get; set; }
    }
}