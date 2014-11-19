using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareArchitecturesHomework.Editor.Core.Interface
{
    public interface IPluginManager
    {
        void Initialize(IModelManager modelManager);
        List<IPlugin> GetPlugins();
        void ActivatePlugin(IPlugin plugin, bool active);
        List<IPlugin> GetActivePlugins();
        void LoadPlugins();
    }
}
