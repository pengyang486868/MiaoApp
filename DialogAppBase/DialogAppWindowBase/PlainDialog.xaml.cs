using System.Windows;

namespace DialogAppWindowBase
{
    /// <summary>
    /// PlainDialog.xaml 的交互逻辑
    /// </summary>
    public partial class PlainDialog
    {
        public PlainDialog()
        {
            InitializeComponent();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
