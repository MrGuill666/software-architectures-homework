using SoftwareArchitecturesHomework.Editor.Core.Factory;
using SoftwareArchitecturesHomework.Editor.Core.Interface;
using SoftwareArchitecturesHomework.Editor.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SoftwareArchitecturesHomework.Editor.Plugins.Test
{
    class TestPlugin:IPlugin
    {
        String name;
        TestControl component;
        IModelManager modelManager;
        public TestPlugin(String name)
        {
            this.name = name;
        }
        public void Initialize(IModelManager modelManager)
        {
            this.modelManager = modelManager;
            component = new TestControl();
            component.loadFromImageButton.Click += loadFromImageButton_Click;
        }

        void loadFromImageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ModelFactory mf=new ModelFactory();
            var dlg = new Microsoft.Win32.OpenFileDialog();

            if (dlg.ShowDialog()==true)
            {
                modelManager.SetModel(mf.CreateModelFromImage(dlg.FileName));
            }
            
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

        public void HandleEditEvent(IPlugin senderPlugin, System.Windows.Point position, object sender, System.Windows.Input.MouseEventArgs e)
        {
            Console.WriteLine(position);
        }


        public UserControl GetComponent()
        {
            return component;
        }
    }
}
