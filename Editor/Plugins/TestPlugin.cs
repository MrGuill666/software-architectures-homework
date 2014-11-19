using SoftwareArchitecturesHomework.Editor.Core.Interface;
using SoftwareArchitecturesHomework.Editor.UI;
using SoftwareArchitecturesHomework.Editor.UI.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SoftwareArchitecturesHomework.Editor.Plugins
{
    class TestPlugin:IPlugin
    {
        String name;
        UserControl component;
        public TestPlugin(String name)
        {
            this.name = name;
        }
        public void Initialize(IModelManager modelManager)
        {
            component = new TestControl();
        }

        public string GetName()
        {
            return name;
        }

        public PluginType GetPreferredType()
        {
            return PluginType.Tool;
        }

        public void Refresh()
        {
            
        }

        public void HandleEditEvent()
        {
            
        }


        public UserControl GetComponent()
        {
            return component;
        }
    }
}
