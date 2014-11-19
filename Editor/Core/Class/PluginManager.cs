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
            }
        }

        public List<IPlugin> GetActivePlugins()
        {
            return activePlugins;
        }

        public void LoadPlugins()
        {
            //TODO
            /*for (int i = 0; i < 10; i++)
            {
                var p = new TestViewPlugin("TestViewPlugin" + i);
                p.Initialize(modelManager);
                plugins.Add(p);
            }*/
            IPlugin p = new TestViewPlugin("TestViewPlugin");
            p.Initialize(modelManager);
            plugins.Add(p);

            p = new TestPlugin("TestPlugin");
            p.Initialize(modelManager);
            plugins.Add(p);
        }
    }
}
