using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecturesHomework.Editor.Core.Interface
{
    enum PluginType
    {
        Tool, View
    }

    interface IPlugin
    {
        void Initialize(IModelManager modelManager);
        String GetName();
        //Component GetComponent(); 
        PluginType GetPreferredType();
        void Refresh();
        void HandleEditEvent(); //paramétert kitalálni
    }
}
