using SoftwareArchitecturesHomework.Editor.Core.Class;
using SoftwareArchitecturesHomework.Editor.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecturesHomework.Editor.Core.Factory
{
    public class ModelFactory
    {
        public IModel CreateModel()
        {
            return null; //unimplemented
        }
        public IModel CreateModelFromImage(String path)
        {
            var model=new Model();
             model.SetImage(new System.Windows.Media.Imaging.BitmapImage(new System.Uri(path)));
             return model;
        }
    }
}
