using SoftwareArchitecturesHomework.Editor.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SoftwareArchitecturesHomework.Editor.Core.Class
{

    class Model : IModel
    {
        BitmapImage img = null;
        //  List<List<System.Windows.Point>> blobs=new List<List<System.Windows.Point>>();
        List<WriteableBitmap> masks = new List<WriteableBitmap>();
        IModelManager modelManager = null;

        public void Initialize(IModelManager modelManager)
        {
            this.modelManager = modelManager;
        }




        public List<WriteableBitmap> GetBlobs()
        {
            return masks;
        }


        public BitmapImage Image
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
            }
        }

        public List<WriteableBitmap> Blobs
        {
            get { return masks; }
        }


        private WriteableBitmap tempblob = null;
        public WriteableBitmap TemporaryBlob
        {
            get { return tempblob; }
            set { tempblob = value; }
        }
    }
}