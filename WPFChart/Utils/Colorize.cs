

#region References

using System;
using System.Windows.Media;

#endregion

namespace ChartLibrary.Utils
{
    public class Colorize : Singleton<Colorize>
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
            return new SolidColorBrush(Color.FromRgb(Convert.ToByte(rand.Next(0, 255)), Convert.ToByte(rand.Next(0, 255)), Convert.ToByte(rand.Next(0, 255))));
        }

        #endregion
    }
}
