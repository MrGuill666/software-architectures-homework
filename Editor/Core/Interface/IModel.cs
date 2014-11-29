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

        BitmapImage Image
        {
            get;
            set;
        }
        //       List<List<System.Windows.Point>> GetBlobs();

        IList<WriteableBitmap> Blobs
        {
            get;
        }
        //List<WriteableBitmap> GetBlobs();

        WriteableBitmap TemporaryBlob
        {
            get;
            set;
        }

        IList<WriteableBitmap> SelectedBlobs
        {
            get;
        }
    }
}