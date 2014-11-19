using SoftwareArchitecturesHomework.Editor.Core.Interface;
using SoftwareArchitecturesHomework.Editor.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SoftwareArchitecturesHomework.Editor.Plugins.TestView
{
    class TestViewPlugin:IPlugin
    {
        String name;
        UserControl component;
        public TestViewPlugin(String name)
        {
            this.name = name;
        }
        public void Initialize(IModelManager modelManager)
        {
            component = new TestViewControl();
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
