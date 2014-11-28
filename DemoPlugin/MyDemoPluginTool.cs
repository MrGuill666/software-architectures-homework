using MyDemoPluginTool;
using SoftwareArchitecturesHomework.Editor.Core.Factory;
using SoftwareArchitecturesHomework.Editor.Core.Interface;
using SoftwareArchitecturesHomework.Editor.TransformLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPlugin
{
    public class MyDemoPluginTool : IPlugin
    {
        MyDemoPluginControl _component;
        private IModelManager _modelManager;

        public void Initialize(IModelManager modelManager)
        {
            _modelManager = modelManager;
            _component = new MyDemoPluginControl();
            _component.loadFromImageButton.Click += loadFromImageButton_Click;
        }

        void loadFromImageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ModelFactory mf = new ModelFactory();
            var dlg = new Microsoft.Win32.OpenFileDialog();

            if (dlg.ShowDialog() == true)
            {
                var model = mf.CreateModelFromImage(dlg.FileName);
                model.Initialize(_modelManager);
                _modelManager.SetModel(model);
            }
        }

        public string GetName()
        {
            return "MyDemoPluginTool";
        }

        public System.Windows.Controls.UserControl GetComponent()
        {
            return _component;
        }

        public PluginType GetPreferredType()
        {
            return PluginType.Tool;
        }

        public void Refresh()
        {

        }

        public void HandleEditEvent(IPlugin senderplugin, System.Windows.Point position, object sender, System.Windows.Input.MouseEventArgs e)
        {
            Console.WriteLine(position);
            var model = _modelManager.GetModel();
            //if (model.Blobs.Count < 1) model.Blobs.Add(new List<Point>());

            int brushSize = (int)_component.brushSlider.Value;
            var pixels = new List<System.Windows.Point>();
            for (int i = -brushSize; i <= brushSize; i++)
            {
                for (int j = -brushSize; j <= brushSize; j++)
                {

                    var p2 = new System.Windows.Point(position.X + i, position.Y + j);
                    pixels.Add(p2);
                }
            }
            if (_component.Brush.IsChecked == true)
            {
                ModelTransformLibrary.AddPixelsToTempBlob(model, pixels);
                _modelManager.ModelChanged();
            }
            else if (_component.Eraser.IsChecked == true)
            {
                ModelTransformLibrary.RemovePixelsFromTempBlob(model, pixels);
                _modelManager.ModelChanged();
            }
        }
    }
}
