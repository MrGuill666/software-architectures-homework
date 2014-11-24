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
            int[] pixelData = new int[w * h];
            int widthInByte = 4 * w;

            tempblob.CopyPixels(pixelData, widthInByte, 0);
            foreach (var p in pixels)
            {
                if (p.X >= 0 && p.Y >= 0 && p.X < w && p.Y < h)
                {
                    var c = 0x00ffffff;
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

        public static IModel MergeBlobs(IModel model, IList<WriteableBitmap> blobs)
        {
            //TODO
            return model;
        }

        public static IModel EditBlob(IModel model, WriteableBitmap blob)
        {
            model.Blobs.Remove(blob);
            model.TemporaryBlob = blob;
            return model;
        }

        public static WriteableBitmap SelectBlob(IModel model, Point pixel)
        {
            foreach(var b in model.Blobs)
            {
               //TODO
            }
            return null;
        }
    }
}
