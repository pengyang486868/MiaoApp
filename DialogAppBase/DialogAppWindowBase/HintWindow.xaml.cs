using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace DialogAppWindowBase
{
    /// <summary>
    /// HintWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HintWindow
    {
        public HintWindow()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            base.Show();
            var anim = new DoubleAnimation
            {
                From = Opacity,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(3))
            };
            anim.Completed += Anim_Completed;
            BeginAnimation(OpacityProperty, anim);

            var animt = new DoubleAnimation
            {
                From = TxtBlock.Opacity,
                To = 0.2,
                Duration = new Duration(TimeSpan.FromSeconds(3))
            };
            TxtBlock.BeginAnimation(OpacityProperty, animt);
        }

        private void Anim_Completed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
