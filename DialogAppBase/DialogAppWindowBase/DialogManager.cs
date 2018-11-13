using System;
using System.Windows.Controls;
using DialogAppBase;

namespace DialogAppWindowBase
{
    public class DialogManager
    {
        public static void ShowDialog(ViewModelBase vm, string title = null, int height = 300, int width = 500)
        {
            var vIns = CreateViewIns(vm);
            if (vIns == null) return;

            var wnd = new PlainDialog
            {
                Title = title,
                Height = height,
                Width = width,
                DataContext = vm,
                MainControl = { Content = vIns as UserControl }
            };
            wnd.ShowDialog();
        }


        public static void ShowHintWindow(string str)
        {
            var hwin = new HintWindow()
            {
                TxtBlock = { Text = str },
                Opacity = 1
            };
            hwin.Show();
        }

        public static object CreateViewIns(object vm)
        {
            var vmType = vm.GetType();
            var vmTypeName = vmType.FullName;
            if (vmTypeName == null) return null;

            var vName = vmTypeName.Replace("ViewModel", "View");
            var vInsType = vmType.Assembly.GetType(vName);
            var vIns = Activator.CreateInstance(vInsType);
            return vIns;
        }


    }
}
