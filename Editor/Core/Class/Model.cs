using SoftwareArchitecturesHomework.Editor.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SoftwareArchitecturesHomework.Editor.Core.Class
{

    class Model: IModel
    {
        BitmapImage img=null;
        List<List<System.Windows.Point>> blobs=new List<List<System.Windows.Point>>();
        IModelManager modelManager=null;

        public void Initialize(IModelManager modelManager)
        {
            this.modelManager = modelManager;
        }


        public BitmapImage GetImage()
        {
            return img;
        }

        public List<List<System.Windows.Point>> GetBlobs()
        {
            return blobs;
        }



        public void SetImage(BitmapImage img)
        {
            this.img = img;
        }
    }
}
