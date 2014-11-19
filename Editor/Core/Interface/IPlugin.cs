using SoftwareArchitecturesHomework.Editor.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecturesHomework.Editor.Core.Interface
{
    public enum PluginType
    {
        Tool, View
    }

    public interface IPlugin
    {
        void Initialize(IModelManager modelManager);
        String GetName();
        System.Windows.Controls.UserControl GetComponent(); 
        PluginType GetPreferredType();
        void Refresh();
        void HandleEditEvent(IPlugin senderplugin, System.Windows.Point position, object sender, System.Windows.Input.MouseEventArgs e); 
    }
}
