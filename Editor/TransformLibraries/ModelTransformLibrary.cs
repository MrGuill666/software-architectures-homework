using SoftwareArchitecturesHomework.Editor.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SoftwareArchitecturesHomework.Editor.TransformLibraries
{
    class ModelTransformLibrary
    {
        public static IModel AddPixelsToTempBlob(IModel model, IList<System.Windows.Point> pixels)
        {
            var tempblob = model.TemporaryBlob;
            var img = model.Image;
            if (tempblob == null)
            {
                model.TemporaryBlob=tempblob = new WriteableBitmap(img.PixelWidth, img.PixelHeight, img.DpiX, img.DpiY, PixelFormats.Pbgra32, null);
            }



            //pImgData.ToPointer
            int h = tempblob.PixelHeight;
            int w = tempblob.PixelWidth;
            UInt32[] pixelData = new UInt32[w * h];
            int widthInByte = 4 * w;

            tempblob.CopyPixels(pixelData, widthInByte, 0);
            foreach (var p in pixels)
            {
                if (p.X >= 0 && p.Y >= 0 && p.X < w && p.Y < h)
                {
                    var c =0xff000000;
                    pixelData[(int)p.X + (int)p.Y * w] = c;
                }
            }

            tempblob.WritePixels(new System.Windows.Int32Rect(0, 0, w, h), pixelData, widthInByte, 0);

            return model;
        }

        public static IModel RemovePixelsFromTempBlob(IModel model, IList<System.Windows.Point> pixels)
        {
            var tempblob = model.TemporaryBlob;
            var img = model.Image;
            if (tempblob == null)
            {
                model.TemporaryBlob=tempblob = new WriteableBitmap(img.PixelWidth, img.PixelHeight, img.DpiX, img.DpiY, PixelFormats.Pbgra32, null);
            }



            //pImgData.ToPointer
            int h = tempblob.PixelHeight;
            int w = tempblob.PixelWidth;
            int[] pixelData = new int[w * h];
            int widthInByte = 4 * w;

            tempblob.CopyPixels(pixelData, widthInByte, 0);
            foreach (var p in pixels)
            {
                if (p.X >= 0 && p.Y >= 0 && p.X < w && p.Y < h)
                {
                    var c = 0x00000000;
                    pixelData[(int)p.X + (int)p.Y * w] = c;
                }
            }

            tempblob.WritePixels(new System.Windows.Int32Rect(0, 0, w, h), pixelData, widthInByte, 0);

            return model;
        }

        public static IModel AddTempBlobToBlobs(IModel model)
        {
            model.Blobs.Add(model.TemporaryBlob);
            model.TemporaryBlob = null;
            return model;
        }

        public static IList<WriteableBitmap> MergeBlobs(IList<WriteableBitmap> blobs)
        {
            if (blobs.Count < 1) return null;

            IList<WriteableBitmap> ret = new List<WriteableBitmap>();
            var wb = new WriteableBitmap(blobs.First());


            return ret;
        }

        public static IModel EditBlob(IModel model, WriteableBitmap blob)
        {
            model.Blobs.Remove(blob);
            model.TemporaryBlob = blob;
            return model;
        }

        public static int GetPixel(WriteableBitmap wbm, Point p)
        {
            int h = wbm.PixelHeight;
            int w = wbm.PixelWidth;
            int[] pixelData = new int[w * h];
            int widthInByte = 4 * w;

            wbm.CopyPixels(pixelData, widthInByte, 0);

            int color=(pixelData[(int)p.X + (int)p.Y * w]);

            return color;
        }



        public static IList<WriteableBitmap> GetBlobsSelected(IModel model, Point pixel)
        {
            var ret = new List<WriteableBitmap>();
            foreach(var b in model.Blobs)
            {
                int c = GetPixel(b, pixel);
                if((c&0xff000000)>0)
                {
                    ret.Add(b);
                }
            }
            return ret;
        }
    }
}
