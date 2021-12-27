using ClassLibraryPluginsConfigurations.Models;

namespace ClassLibraryPluginsConfigurations.Interfaces
{
    public interface IPlugin
    {
        string PluginName { get; }
        void Execute(AbstractModel abstractModel);
    }
}