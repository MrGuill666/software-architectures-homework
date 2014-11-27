using SoftwareArchitecturesHomework.Editor.Core.Class;
using SoftwareArchitecturesHomework.Editor.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecturesHomework.Editor.Core.Factory
{
    class ModelFactory
    {
        public IModel CreateModel()
        {
            return new Model();
        }
        public IModel CreateModelFromImage(String path)
        {
            var model=new Model();
             model.Image=new System.Windows.Media.Imaging.BitmapImage(new System.Uri(path));
             return model;
        }
    }
}
