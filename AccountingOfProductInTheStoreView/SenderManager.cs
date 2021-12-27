using ClassLibraryPluginsConfigurations.Interfaces;
using ClassLibraryPluginsConfigurations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfProductInTheStoreView
{
    public class SenderManager
    {
        [ImportMany(typeof(IPlugin))]
        public readonly Dictionary<string, IPlugin> Plugins = new Dictionary<string, IPlugin>();
        public List<string> Headers { get; set; }
        public SenderManager()
        {
            var catalog = new AggregateCatalog();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "SenderMessage");
            catalog.Catalogs.Add(new DirectoryCatalog(path));
            foreach (var dll in Directory.GetFiles(path, "*.dll"))
            {
                Assembly assembly = Assembly.LoadFile(dll);
                try
                {
                    IPlugin plugin = Activator.CreateInstance(assembly.GetTypes()[0]) as IPlugin;
                    Plugins.Add(Path.GetFileNameWithoutExtension(dll), plugin);
                }
                catch (ReflectionTypeLoadException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
