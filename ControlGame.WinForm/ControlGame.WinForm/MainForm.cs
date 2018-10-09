using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;

namespace ControlGame.WinForm
{
    public partial class MainForm : Form
    {
        private Device _device;

        public MainForm()
        {
            //InitializeComponent();

            ClientSize = new Size(800, 600);
            //Text = "Control Game";
            MessageBox.Show("cons");
        }

        public bool InitCard()
        {
            MessageBox.Show("init");

            var pp = new PresentParameters
            {
                Windowed = true,
                SwapEffect = SwapEffect.Discard
            };

            _device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, pp);
            return true;
        }

        public void Render()
        {
            if (_device == null)
            {
                return;
            }

            _device.Clear(ClearFlags.Target, Color.Pink, 1f, 0);
            _device.BeginScene();

            //

            _device.EndScene();
            _device.Present();
        }
    }
}
