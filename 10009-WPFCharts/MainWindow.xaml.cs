#region References

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using ChartTest.Utils;

#endregion

namespace ChartTest
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Fields

        public IEnumerable<DataPoint> ItemsSource { get; set; }

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            GenerateData();
            DrawRectangle();
        }

        #endregion

        #region Methods

        public IList<DataPoint> GenerateData()
        {
            IList<DataPoint> dataPoints = new List<DataPoint>();

            Random num = new Random();

            for (int i = 1; i < num.Next(300); i++)
            {
                DataPoint pointItem = new DataPoint()
                {
                    IndependentValue = "Title " + i,
                    DependentValue = i,
                    ToolTip = "Title " + i
                };
                dataPoints.Add(pointItem);

            }
            return dataPoints;

        }

        public void DrawRectangle()
        {

            myGrid.Children.Add(GenerateRectangle());

        }

        /// <summary>
        /// Generate Rectangle with values
        /// </summary>
        /// <returns>Drawed Rectangle</returns>
        private Rectangle GenerateRectangle()
        {
            Rectangle rect = new Rectangle();
            double width = myGrid.Width;
            rect.Height = GetActualHeightParentControl() / 1;
            rect.Width = GetActualWidthParentContent() / 4;
            rect.Fill = Colorize.GetSingleton().GenerateColor();
            rect.ToolTip = "Estou aqui!";
            
            rect.SetValue(Grid.RowProperty, 0);
            rect.SetValue(Grid.ColumnProperty, 0);

            return rect;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>DataPoint item</returns>
        public DataPoint GenerateDataPoint()
        {

            DataPoint dataPoint = new DataPoint();


            return dataPoint;

        }

        /// <summary>
        /// Get Actual Width from container component
        /// </summary>
        /// <returns>Double Value</returns>
        public Double GetActualWidthParentContent()
        {
            if (this.myGrid.ActualWidth == double.NaN || this.myGrid.ActualWidth == 0.0)
                return this.Width;
            else
                return System.Windows.SystemParameters.PrimaryScreenWidth;
        }

        /// <summary>
        /// Get Actual Height from container component
        /// </summary>
        /// <returns>Double Value</returns>
        public Double GetActualHeightParentControl()
        {
            //if (this.myGrid.ActualHeight == double.NaN || this.myGrid.ActualHeight == 0.0)
            //    return this.Height;
            //else
                return (this.myGrid.Parent as Control).Height;
                //return System.Windows.SystemParameters.PrimaryScreenHeight;
        }

        public void DrawObject(Control c)
        {
            if (this.myGrid.Width == double.NaN)
            {

            }
        }

        private Object GetParent(Control obj) 
        {
            return obj.Parent;
        }

        // TODO Gustavo: Criar método que pesquisa todos os objetos pai

        #endregion

    }
}