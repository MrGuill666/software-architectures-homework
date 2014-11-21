using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace SoftwareArchitecturesHomework.Editor.Core.Interface
{
    public interface IModel
    {
        void Initialize(IModelManager modelManager);
        
        BitmapImage GetImage();
        void SetImage(BitmapImage img);
        List<List<System.Windows.Point>> GetBlobs();
    }
}
