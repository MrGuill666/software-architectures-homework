using SoftwareArchitecturesHomework.Editor.Core.Interface;
using SoftwareArchitecturesHomework.Editor.Plugins;
using SoftwareArchitecturesHomework.Editor.Plugins.Test;
using SoftwareArchitecturesHomework.Editor.Plugins.TestView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecturesHomework.Editor.Core.Class
{
    class PluginManager: IPluginManager
    {
        private IModelManager modelManager=null;
        private List<IPlugin> plugins = new List<IPlugin>(), activePlugins = new List<IPlugin>();

        public void Initialize(IModelManager modelManager)
        {
            this.modelManager = modelManager;
        }

        public List<IPlugin> GetPlugins()
        {
            return plugins;
        }

        public void ActivatePlugin(IPlugin plugin, bool active)
        {
            if(!active&&activePlugins.Contains(plugin))
            {
                activePlugins.Remove(plugin);
            }
            else if(active&&!activePlugins.Contains(plugin))
            {
                activePlugins.Add(plugin);
                plugin.Refresh();
            }
        }

        public List<IPlugin> GetActivePlugins()
        {
            return activePlugins;
        }

        public void LoadPlugins()
        {
            IEnumerable<string> pluginAssemblies;
            try
            {
                pluginAssemblies = System.IO.Directory.EnumerateFiles("plugins", "*.dll", System.IO.SearchOption.AllDirectories);
            }
            catch
            {
                pluginAssemblies = Enumerable.Empty<string>();
            }

            var pluginTypes = pluginAssemblies.SelectMany(file =>
            {
                try
                {
                    return Enumerable.Repeat(System.Reflection.Assembly.LoadFrom(file), 1);
                }
                catch
                {
                    return Enumerable.Empty<System.Reflection.Assembly>();
                }
            }).SelectMany(assembly => assembly.ExportedTypes.Where(type => (type.IsClass || type.IsValueType) && !type.IsAbstract && type.GetInterfaces().Any(typeof(IPlugin).Equals)));

            foreach (var pluginType in pluginTypes)
            {
                try
                {
                    var plugin = (IPlugin)pluginType.GetConstructor(Type.EmptyTypes).Invoke(null);
                    plugin.Initialize(modelManager);
                    plugins.Add(plugin);
                }
                catch
                {
                    // TODO: log loading error
                }
            }
            
            IPlugin p = new TestViewPlugin("TestViewPlugin");
            p.Initialize(modelManager);
            plugins.Add(p);

            p = new TestPlugin("TestPlugin");
            p.Initialize(modelManager);
            plugins.Add(p);

            
        }
    }
}
