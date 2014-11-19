using SoftwareArchitecturesHomework.Editor.Core.Class;
using SoftwareArchitecturesHomework.Editor.Core.Interface;
using SoftwareArchitecturesHomework.Editor.Plugins;
using SoftwareArchitecturesHomework.Editor.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoftwareArchitecturesHomework.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void pluginsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.pluginsListBox.SelectedIndex;
            if (index >= 0)
            {
                pluginManager.ActivatePlugin(plugins[index], !pluginManager.GetActivePlugins().Contains(plugins[index]));
                if (pluginManager.GetActivePlugins().Contains(plugins[index]))
                {
                    var p = plugins[index];
                    if(windows.ContainsKey(p))
                    {
                        windows.Remove(p);
                    }
                        var pluginWindow = new PluginWindow();
                        pluginWindow.Initialize(p, pluginManager);
                        windows.Add(p, pluginWindow);
                        windows[p].Owner = this;
                    

                    windows[p].Show();
                    
                }
                else
                {
                   // windows[plugins[index]].Hide();
                    windows[plugins[index]].Close();
                    windows.Remove(plugins[index]);
                }
                
            }
        }

        private IPluginManager pluginManager;

        public void Initialize(IPluginManager pluginManager)
        {
            this.pluginManager = pluginManager;
        }

        private List<IPlugin> plugins = null;
        private Dictionary<IPlugin, Window> windows = new Dictionary<IPlugin,Window>();

        public void ResetComponents()
        {
            pluginsListBox.Items.Clear();
            plugins = pluginManager.GetPlugins();
            foreach (var p in plugins)
            {
                pluginsListBox.Items.Add(p.GetName());

               /* var pluginWindow = new PluginWindow();
                pluginWindow.Initialize(p, pluginManager);
                windows.Add(p, pluginWindow);*/

                
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            var controller = new Controller();
            var pluginManager = new PluginManager();
            pluginManager.Initialize(controller);
            pluginManager.LoadPlugins();
            controller.Initialize(this, pluginManager);
            pluginManager.Initialize(controller);
            this.Initialize(pluginManager);
            this.ResetComponents();
        }




    }
}
