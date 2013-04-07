// --------------------------------------------------------------------------------------
// Descrição:
// 
// --------------------------------------------------------------------------------------
// Autor: Gustavo Souza Gonçalves
// Data: 15/03/2013
// --------------------------------------------------------------------------------------
// Versão: 0.1
// 
// --------------------------------------------------------------------------------------
// Revisão:
// 
// --------------------------------------------------------------------------------------


#region references

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
    /// Interação lógica para ColumnChart.xam
    /// </summary>
    public partial class ColumnChart : UserControl
    {
        #region Fields

        public IEnumerable<DataPoint> ItemsSource { get; set; }

        #endregion

        #region Constructor

        public ColumnChart()
        {
            InitializeComponent();

            //AddRectanglesToGrid();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates DataPoints with random values
        /// </summary>
        /// <returns>List of DataPoint</returns>
        public IList<DataPoint> GenerateData()
        {
            IList<DataPoint> dataPoints = new List<DataPoint>();

            Random num = new Random();

            for (int i = 1; i < num.Next(50); i++)
            {
                DataPoint pointItem = new DataPoint()
                {
                    IndependentValue = "Title " + i,
                    DependentValue = i * 100,
                    ToolTip = "Title " + i
                };
                dataPoints.Add(pointItem);

            }
            return dataPoints;

        }

        /// <summary>
        /// 
        /// </summary>
        public IList<UIElement> AddRectanglesToGrid()
        {
            IList<UIElement> children = new List<UIElement>();
            
            if (myGrid.ActualHeight == double.NaN)
                myGrid.Height = (myGrid.Parent as Window).ActualHeight;

            if (myGrid.ActualWidth == double.NaN)
                myGrid.Width = (myGrid.Parent as Window).ActualWidth;

            foreach (Rectangle item in GenerateRectangle())
            {
                item.VerticalAlignment = VerticalAlignment.Bottom;

                //myGrid.Children.Add(item);

                children.Add(item);
            }

            return children;
            //return myGrid;
        }
        /// <summary>
        /// Generate Rectangle with values
        /// </summary>
        /// <returns>Drawed Rectangle</returns>
        private IList<Rectangle> GenerateRectangle()
        {
            ItemsSource = GenerateData();
            IList<Rectangle> rectangleList = new List<Rectangle>();
            rectangleList.Clear();

            Int32 countItemsSource = (ItemsSource as IList).Count;

            Double widthComponent = GetActualWidthParentContent();

            Double widthPosition = widthComponent / countItemsSource;

            Double positionX = -widthComponent;

            foreach (var item in ItemsSource)
            {
                Rectangle rect = new Rectangle();

                //rect.Height = item.DependentValue ;
                //rect.Height = item.DependentValue / (myGrid.Height / 50);
                rect.Height = CalculateHeightOfRectangle(countItemsSource, GetActualHeightParentControl(), item.DependentValue);

                rect.Width = CalculateWidthOfRectangle(countItemsSource, GetActualWidthParentContent());
                //rect.Width = 10;
                rect.Fill = Colorize.GetSingleton().GenerateColor();
                rect.ToolTip = item.IndependentValue + " (" + item.DependentValue + ") ";

                // Configures border/BorderColor of rectangle
                rect.StrokeThickness = 1.5;
                rect.Stroke = new SolidColorBrush(Colors.Black);

                // this set location of component in screen
                rect.Margin = new Thickness(widthPosition + positionX / 2, 0, 0, 0);

                // position of component in grid
                widthPosition += widthComponent / countItemsSource;

                // Sets Vertical Alignment of rectangle to bottom
                rect.VerticalAlignment = VerticalAlignment.Bottom;

                rectangleList.Add(rect);
            }

            return rectangleList;
        }

        /// <summary>
        /// Get Actual Width from container component
        /// </summary>
        /// <returns>Double Value</returns>
        public Double GetActualWidthParentContent()
        {
            if (this.myGrid.ActualWidth == double.NaN || this.myGrid.ActualWidth == 0.0)
            {
                Double width = 0.0;
                if (myGrid.Width.Equals(Double.NaN))
                    width = 125.0;
                else
                    width = myGrid.Width;

                return width;
            }
            else
                return System.Windows.SystemParameters.PrimaryScreenWidth;
        }

        /// <summary>
        /// Get Actual Height from container component
        /// </summary>
        /// <returns>Double Value</returns>
        public Double GetActualHeightParentControl()
        {
            if (this.myGrid.ActualHeight == double.NaN || this.myGrid.ActualHeight == 0.0)
            {
                Double height = 0.0;
                if (myGrid.Height.Equals(Double.NaN))
                    height = 525.0;
                else
                    height = myGrid.Height;

                return height;
            }
            else
                return System.Windows.SystemParameters.PrimaryScreenHeight;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countItemsSource"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public Double CalculateWidthOfRectangle(Int32 countItemsSource, Double width)
        {
            //return width / countItemsSource - (countItemsSource / 10) ;
            return width / countItemsSource - (width / 10);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countItemsSource"></param>
        /// <param name="height"></param>
        /// <param name="dependentValue"></param>
        /// <returns></returns>
        public Double CalculateHeightOfRectangle(Int32 countItemsSource, Double height, Double dependentValue)
        {
            //item.DependentValue / (myGrid.Height / 50)
            return dependentValue / (height / 50);
            //return height / countItemsSource - (height / 10);
        }

        #endregion
    }
}
