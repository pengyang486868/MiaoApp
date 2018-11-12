using System;
using System.Windows.Controls;
using DialogAppBase;

namespace DialogAppWindowBase
{
    public class DialogManager
    {
        public static void ShowDialog(ViewModelBase vm, string title = null, int height = 300, int width = 500)
        {
            var vmType = vm.GetType();
            var vmTypeName = vmType.FullName;
            if (vmTypeName != null)
            {
                var vName = vmTypeName.Replace("ViewModel", "View");
                var vInsType = vmType.Assembly.GetType(vName);
                var vIns = Activator.CreateInstance(vInsType);

                var wnd = new PlainDialog
                {
                    Title = title,
                    Height = height,
                    Width = width,
                    DataContext = vm,
                    MainControl = {Content = vIns as UserControl}
                };
                wnd.ShowDialog();
            }
        }
    }
}
