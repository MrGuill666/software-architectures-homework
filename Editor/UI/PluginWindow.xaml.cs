using SoftwareArchitecturesHomework.Editor.Core.Interface;
using System;
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
using System.Windows.Shapes;

namespace SoftwareArchitecturesHomework.Editor.UI
{
    /// <summary>
    /// Interaction logic for PluginWindow.xaml
    /// </summary>
    public partial class PluginWindow : Window
    {
        private IPlugin plugin;
        private IPluginManager pluginManager;
        public PluginWindow()
        {
            InitializeComponent();
        }

        public void Initialize(IPlugin plugin, IPluginManager pluginManager)
        {
            this.plugin = plugin;
            this.pluginManager = pluginManager;
            canvas.Children.Add(plugin.GetComponent());
            this.Title= plugin.GetName();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            canvas.Children.Clear();
            pluginManager.ActivatePlugin(plugin, false);
        }

       

    }
}
