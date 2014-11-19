using SoftwareArchitecturesHomework.Editor.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecturesHomework.Editor.Core.Class
{
    class Controller : IModelManager
    {
        private IPluginManager pluginManager=null;
        private IWindow window=null;
        private IModel model=null;

        public void Initialize(IWindow window, IPluginManager pluginManager)
        {
            this.pluginManager = pluginManager;
            this.window = window;
        }

        public void ModelChanged()
        {
            pluginManager.GetActivePlugins().ForEach(plugin=>plugin.Refresh());
        }

        public void HandleEditEvent(IPlugin senderPlugin, System.Windows.Point position, object sender, System.Windows.Input.MouseEventArgs e)
        {
            pluginManager.GetActivePlugins().ForEach(plugin => plugin.HandleEditEvent(senderPlugin, position,sender, e));
        }

        public IModel GetModel()
        {
            return model;
        }

        public void SetModel(IModel model)
        {
            this.model = model;
            ModelChanged();
        }
    }
}
