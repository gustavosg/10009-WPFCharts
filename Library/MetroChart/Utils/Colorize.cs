

#region References

using System;

using Windows.UI;
using Windows.UI.Xaml.Media;

#endregion

namespace ChartLibrary.Utils
{
    public class Colorize 
    {
        #region Fields

        private static readonly Random rand = new Random();

        #endregion

        #region Methods

        /// <summary>
        /// Generates a RGB Color
        /// </summary>
        /// <returns>New SolidColorBrush object</returns>
        public SolidColorBrush GenerateColor()
        {
            return new SolidColorBrush(Color.FromArgb(Convert.ToByte(rand.Next(0, 255)), Convert.ToByte(rand.Next(0, 255)), Convert.ToByte(rand.Next(0, 255)), Convert.ToByte(rand.Next(0, 255))));
        }

        #endregion
    }
}
