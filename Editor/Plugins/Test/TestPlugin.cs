using SoftwareArchitecturesHomework.Editor.Core.Factory;
using SoftwareArchitecturesHomework.Editor.Core.Interface;
using SoftwareArchitecturesHomework.Editor.TransformLibraries;
using SoftwareArchitecturesHomework.Editor.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SoftwareArchitecturesHomework.Editor.Plugins.Test
{
    class TestPlugin:IPlugin
    {
        String name;
        TestControl component;
        IModelManager modelManager;
        public TestPlugin(String name)
        {
            this.name = name;
        }
        public void Initialize(IModelManager modelManager)
        {
            this.modelManager = modelManager;
            component = new TestControl();
            component.loadFromImageButton.Click += loadFromImageButton_Click;
            component.editFinish.Click += editFinish_Click;
            component.editSelected.Click += editSelected_Click;
            component.mergeSelected.Click += mergeSelected_Click;
            component.deleteSelected.Click += deleteSelected_Click;
        }


        void deleteSelected_Click(object sender, RoutedEventArgs e)
        {
            var model=modelManager.GetModel();
            foreach(var s in model.SelectedBlobs)
            {
                model.Blobs.Remove(s);
            }
            model.SelectedBlobs.Clear();
            modelManager.ModelChanged();
        }

        void mergeSelected_Click(object sender, RoutedEventArgs e)
        {
            var model = modelManager.GetModel();
            var merged=ModelTransformLibrary.MergeBlobs(model.SelectedBlobs);
            if (merged == null) return;
            model.Blobs.Add(merged);
            deleteSelected_Click(sender, e);
        }

        void editSelected_Click(object sender, RoutedEventArgs e)
        {
            var model = modelManager.GetModel();
            var merged = ModelTransformLibrary.MergeBlobs(model.SelectedBlobs);
            model.TemporaryBlob=merged;
            deleteSelected_Click(sender, e);
        }

        void editFinish_Click(object sender, RoutedEventArgs e)
        {
            var m = modelManager.GetModel();
            if (m.TemporaryBlob == null) return;
            m.Blobs.Add(m.TemporaryBlob);
            m.TemporaryBlob = null;
            modelManager.ModelChanged();
        }

        void loadFromImageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ModelFactory mf=new ModelFactory();
            var dlg = new Microsoft.Win32.OpenFileDialog();

            if (dlg.ShowDialog()==true)
            {
                var model = mf.CreateModelFromImage(dlg.FileName);
                model.Initialize(modelManager);
                modelManager.SetModel(model);
            }
            
        }

        public string GetName()
        {
            return name;
        }

        public PluginType GetPreferredType()
        {
            return PluginType.Tool;
        }

        public void Refresh()
        {
            
        }

        public void HandleEditEvent(IPlugin senderPlugin, System.Windows.Point position, object sender, System.Windows.Input.MouseEventArgs e)
        {
            Console.WriteLine(position);
            var model=modelManager.GetModel();
            //if (model.Blobs.Count < 1) model.Blobs.Add(new List<Point>());

            int brushSize=(int)component.brushSlider.Value;
            List<Point> pixels=new List<Point>();
            for (int i = -brushSize; i <= brushSize; i++)
            {
                for (int j = -brushSize; j <= brushSize; j++)
                {
                    
                    Point p2 = new Point(position.X+i, position.Y+j);
                    pixels.Add(p2);
                }
            }
            if (component.Brush.IsChecked==true)
            {
                ModelTransformLibrary.AddPixelsToTempBlob(model,pixels);
                modelManager.ModelChanged();
            }
            else if(component.Eraser.IsChecked==true)
            {
                ModelTransformLibrary.RemovePixelsFromTempBlob(model, pixels);
                modelManager.ModelChanged();
            }
            else if(component.Select.IsChecked==true)
            {
                var selected = ModelTransformLibrary.GetBlobsHighlighted(model, position);
                if(selected.Count==0)
                {
                    model.SelectedBlobs.Clear();
                }
                else foreach(var b in selected)
                {
                    if(!model.SelectedBlobs.Contains(b))
                    {
                        model.SelectedBlobs.Add(b);
                    }
                }
                modelManager.ModelChanged();
            }
        }


        public UserControl GetComponent()
        {
            return component;
        }
    }
}
