using ClassLibraryPluginsConfigurations.Interfaces;
using ClassLibraryPluginsConfigurations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfProductInTheStoreView
{
    public class Manager
    {
        [ImportMany(typeof(IPlugin))]
        public IEnumerable<IPlugin> Plugins { get; private set; }

        public Dictionary<string, Action<AbstractModel>> Functions = new Dictionary<string, Action<AbstractModel>>();

        public string[] Headers { get; private set; }

        public Manager()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory));
            catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins")));

            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            if (Plugins.Count() != 0)
            {
                foreach (var plugin in Plugins.ToList())
                {
                    Functions.Add(plugin.PluginName, list => plugin.Execute(list));
                }
                Headers = Functions.Keys.ToArray();
            }
        }
    }
}