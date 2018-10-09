using System.Windows.Forms;

namespace ControlGame.WinForm
{
    static class Program
    {
        static void Main()
        {
            using (var form = new MainForm())
            {
                if (form.InitCard() == false)
                {
                    return;
                }

                form.Show();

                while (form.Created)
                {
                    form.Render();
                    Application.DoEvents();
                }
            }
        }
    }
}
