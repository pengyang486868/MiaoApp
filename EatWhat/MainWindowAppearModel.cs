using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using EatWhat.AppearModels;
using EatWhat.Appears;
using MiaoCore;

namespace EatWhat
{
    public class MainWindowAppearModel : AppearModelBase
    {
        public MiaoCommand StartSelectCmd { get; set; }
        public MiaoCommand StopSelectCmd { get; set; }
        public MiaoCommand MyMenuCmd { get; set; }
        public MiaoCommand WhoMade { get; set; }
        public MiaoCommand OtherSay { get; set; }

        private string _eatThis;
        public string EatThis
        {
            get => _eatThis;
            set => SetProp(ref _eatThis, value);
        }

        private SolidColorBrush _foodColor;
        public SolidColorBrush FoodColor
        {
            get => _foodColor;
            set => SetProp(ref _foodColor, value);
        }

        private bool _nowStart;

        public bool NowStart
        {
            get => _nowStart;
            set => SetProp(ref _nowStart, value);
        }

        private readonly DispatcherTimer _timer;

        public MainWindowAppearModel()
        {
            StartSelectCmd = new MiaoCommand(OnStartSelectCmd, CanStartSelectCmd);
            StopSelectCmd = new MiaoCommand(OnStopSelectCmd, CanStopSelectCmd);
            MyMenuCmd=new MiaoCommand(OnMyMenuCmd);

            WhoMade=new MiaoCommand(OnWhoMade);
            OtherSay=new MiaoCommand(OnOtherSay);

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };

            _timer.Tick += TimerTick;
        }

        private void OnStartSelectCmd()
        {
            Environment.ReloadMenu();
            _timer.Start();
            NowStart = true;
        }

        private bool CanStartSelectCmd()
        {
            return !_nowStart;
        }

        private void OnStopSelectCmd()
        {
            _timer.Stop();
            NowStart = false;
        }

        private bool CanStopSelectCmd()
        {
            return _nowStart;
        }

        private void TimerTick(object o, EventArgs e)
        {
            EatThis = RandomProvider.ProvideFood();
            FoodColor = RandomProvider.ProvideColor();
        }

        private void OnMyMenuCmd()
        {
            var mma = new MyMenuAppear
            {
                Title = "我的菜们"
            };
            mma.InitAppear(new MyMenuAppearModel());
            mma.ShowDialog();
        }

        private void OnWhoMade()
        {
            MessageBox.Show("肯定是PY做的阿", "谁做的", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnOtherSay()
        {
            MessageBox.Show("好好吃饭 [啾咪]", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
