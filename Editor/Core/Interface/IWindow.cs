using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecturesHomework.Editor.Core.Interface
{
    interface IWindow
    {
        void Initialize(IPluginManager pluginManager);
        void ResetComponents();
    }
}
