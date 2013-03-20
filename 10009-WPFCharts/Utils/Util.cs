// --------------------------------------------------------------------------------------
// 
// 
// --------------------------------------------------------------------------------------
// 
// 
// --------------------------------------------------------------------------------------
// Autor: Gustavo Souza Gonçalves
// Data: 17/03/2013
// --------------------------------------------------------------------------------------
// Versão:
// 
// --------------------------------------------------------------------------------------
// Revisão:
// 
// --------------------------------------------------------------------------------------

#region References

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

#endregion


namespace ChartTest.Utils
{
    public class Util : Singleton<Util>
    {
        #region Fields

        #endregion


        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="control"></param>
        /// <returns></returns>
        public IEnumerable<T> FindAllChildren<T>(DependencyObject control) where T : DependencyObject
        {
            if (control != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(control); i++)
                {
                    DependencyObject obj = VisualTreeHelper.GetChild(control, i);

                    if ((obj != null) && (obj is T))
                    {
                        yield return (T)obj;
                    }

                    foreach (T childOfChild in FindAllChildren<T>(obj))
                    {
                        yield return childOfChild;

                    }
                }
            }
        }


        #endregion
    }
}
