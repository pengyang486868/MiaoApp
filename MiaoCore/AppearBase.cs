using System.Windows;
using MiaoCore.Enums;

namespace MiaoCore
{
    public class AppearBase : Window
    {
        public void InitAppear(object param)
        {
            ConfirmResult = ConfirmResultEnum.Canceled;
            DataContext = param;
        }

        public void InitAppear(object param,string title)
        {
            ConfirmResult = ConfirmResultEnum.Canceled;
            DataContext = param;
            Title = title;
        }

        public ConfirmResultEnum ConfirmResult { get; private set; }

        protected virtual void OnConfirm(object sender, RoutedEventArgs e)
        {
            ConfirmResult = ConfirmResultEnum.Confirmed;
            Close();
        }

        protected virtual void OnCancel(object sender, RoutedEventArgs e)
        {
            ConfirmResult = ConfirmResultEnum.Canceled;
            Close();
        }
    }
}
