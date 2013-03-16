#region References

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

#endregion

namespace ChartTest
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Fields

        public IEnumerable ItemsSource { get; set; }

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            GenerateData();
            //DrawRectangle();
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

            //myGrid.Children.Add(rect);

        }


        private Rectangle GenerateRectangle()
        {
            Rectangle rect = new Rectangle();

            rect.Height = 300;
            rect.Width = 100;
            rect.Fill = new SolidColorBrush(Colors.Black);
            rect.ToolTip = "Estou aqui!";

            rect.SetValue(Grid.RowProperty, 0);
            rect.SetValue(Grid.ColumnProperty, 0);

            return rect;
        }


        public DataPoint GenerateDataPoint()
        {

            DataPoint point = new DataPoint();



            return point;

        }

        #endregion

    }
}