#region References

using System;
using System.Windows.Media;

#endregion

namespace ChartTest.Utils
{
    public class Colorize : Singleton<Colorize>
    {
        #region Fields

        private static readonly Random rand = new Random();

        #endregion

        #region Methods

        private Color GetRandomColor()
        {
            return Color.FromRgb(Convert.ToByte(rand.Next(0, 255)), Convert.ToByte(rand.Next(0, 255)), Convert.ToByte(rand.Next(0, 255)));
        }

        public SolidColorBrush GenerateColor()
        {
            return new SolidColorBrush(GetRandomColor());
        }

        #endregion
    }
}
