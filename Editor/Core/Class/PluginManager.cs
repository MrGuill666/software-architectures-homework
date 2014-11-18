using SoftwareArchitecturesHomework.Editor.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecturesHomework.Editor.Core.Class
{
    class PluginManager: IPluginManager
    {
        private IModelManager modelManager;
        private List<IPlugin> plugins, activePlugins;

        public void Initialize(IModelManager modelManager)
        {
            this.modelManager = modelManager;
            plugins=new List<IPlugin>();
            activePlugins = new List<IPlugin>();
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
            }
        }

        public List<IPlugin> GetActivePlugins()
        {
            return activePlugins;
        }

        public void LoadPlugins()
        {
            //TODO
        }
    }
}
