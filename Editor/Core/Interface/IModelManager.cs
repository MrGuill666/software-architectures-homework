using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareArchitecturesHomework.Editor.Core.Interface
{
    public interface IModelManager
    {
        void ModelChanged();
        void HandleEditEvent(IPlugin senderPlugin, System.Windows.Point position, object sender, System.Windows.Input.MouseEventArgs e);
        IModel GetModel();
        void SetModel(IModel model);
    }
}
