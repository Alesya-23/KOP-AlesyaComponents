using System.Collections.Generic;

namespace PluginBuildWordReport
{
    public class WordParagraph
    {
        public List<(string, WordTextProperties)> Texts { get; set; }

        public WordTextProperties TextProperties { get; set; }
    }
}
