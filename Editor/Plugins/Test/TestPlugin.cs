﻿using SoftwareArchitecturesHomework.Editor.Core.Interface;
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
