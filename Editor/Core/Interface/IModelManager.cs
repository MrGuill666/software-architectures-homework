using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareArchitecturesHomework.Editor.Core.Interface
{
    interface IModelManager
    {
        void ModelChanged();
        void HandleEditEvent(); //paramétert még ki kell találni
        IModel GetModel();
        void SetModel(IModel model);
    }
}
