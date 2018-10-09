using System;
using System.Windows.Media;

namespace EatWhat
{
    public static class RandomProvider
    {
        public static string ProvideFood()
        {
            var menu = Environment.Menu;

            var seed = Guid.NewGuid().GetHashCode();
            var rm = new Random(seed);
            var dice = rm.Next(1000);

            return menu[dice % menu.Count];
        }

        public static SolidColorBrush ProvideColor()
        {
            var seed = Guid.NewGuid().GetHashCode();
            var rm = new Random(seed);
            var diceR = rm.Next(10000);
            var diceG = rm.Next(10000);
            var diceB = rm.Next(10000);

            return new SolidColorBrush(Color.FromRgb(
                byte.Parse((diceR % 255).ToString()),
                byte.Parse((diceG % 255).ToString()),
                byte.Parse((diceB % 255).ToString())));
        }
    }
}
