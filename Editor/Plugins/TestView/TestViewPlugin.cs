using SoftwareArchitecturesHomework.Editor.Core.Interface;
using SoftwareArchitecturesHomework.Editor.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SoftwareArchitecturesHomework.Editor.Plugins.TestView
{
    class TestViewPlugin : IPlugin
    {
        String name;
        TestViewControl component;
        IModelManager modelManager = null;
        public TestViewPlugin(String name)
        {
            this.name = name;
        }
        public void Initialize(IModelManager modelManager)
        {
            this.modelManager = modelManager;
            component = new TestViewControl();
            this.component.grid.PreviewMouseDown += component_MouseDown;
            this.component.grid.PreviewMouseUp += component_MouseUp;
            this.component.grid.MouseMove += component_MouseMove;

        }
        private bool pressed = false;
        private void component_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            pressed = false;
        }

        void component_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (pressed)
            {
                modelManager.HandleEditEvent(this, e.GetPosition(component.grid), sender, e);
            }
        }

        void component_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            pressed = true;
        }

        public string GetName()
        {
            return name;
        }

        public PluginType GetPreferredType()
        {
            return PluginType.View;
        }

        public void Refresh()
        {
            IModel model = modelManager.GetModel();
            if (model == null) return;
            var img = model.Image;
            if (img == null) return;
            component.image.Source = img;

            int i = 0;

            while (model.Blobs.Count > component.blobs.Children.Count)
            {
                var rect = new Rectangle();
                rect.Fill = new SolidColorBrush(Colors.OrangeRed);
                component.blobs.Children.Add(rect);
                rect.OpacityMask = new ImageBrush();
            }

            foreach (var b in model.Blobs)
            {
                var ib = (ImageBrush)component.blobs.Children[i].OpacityMask;
                ib.ImageSource = b;
                i++;
            }


            component.templbob.ImageSource = model.TemporaryBlob;

        }

        public void HandleEditEvent(IPlugin senderPlugin, System.Windows.Point position, object sender, System.Windows.Input.MouseEventArgs e)
        {

        }


        public UserControl GetComponent()
        {
            return component;
        }
    }
}
