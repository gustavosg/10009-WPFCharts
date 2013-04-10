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
            Int16 value = 0;

            while (value < 2)
                value = Convert.ToInt16(num.Next(15));

            for (int i = 1; i < value; i++)
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

                children.Add(item);
            }

            return children;
        }

        /// <summary>
        /// Generate Rectangle with values
        /// </summary>
        /// <returns>Drawed Rectangle</returns>
        private IList<Rectangle> GenerateRectangle()
        {
            // Garante que ItemsSource nunca será nulo ou vazio
            while (ItemsSource == null)
                ItemsSource = GenerateData();

            IList<Rectangle> rectangleList = new List<Rectangle>();
            rectangleList.Clear();

            Int32 countItemsSource = (ItemsSource as IList).Count;

            Double widthComponent = GetActualWidthParentContent();

            Double widthPosition = widthComponent / countItemsSource;

            Double positionX = -widthComponent;

            Double minimum = ItemsSource.Min();

            foreach (var item in ItemsSource)
            {
                Rectangle rect = new Rectangle();

                //rect.Height = item.DependentValue ;
                //rect.Height = item.DependentValue / (myGrid.Height / 50);
                rect.Height = CalculateHeightOfRectangle(GetActualHeightParentControl(), item.DependentValue);

                rect.Width = CalculateWidthOfRectangle(countItemsSource, GetActualWidthParentContent());

                rect.Fill = Colorize.GetSingleton().GenerateColor();
                rect.ToolTip = item.IndependentValue + " (" + item.DependentValue + ") ";

                // Configures border/BorderColor of rectangle
                rect.StrokeThickness = 1.5;
                rect.Stroke = new SolidColorBrush(Colors.Black);

                // this set location of component in screen
                rect.Margin = new Thickness(widthPosition + positionX / 2, 0, 0, 0);



                Canvas.SetLeft(rect, 50);

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
                //if (myGrid.Width.Equals(Double.NaN))
                //    width = this.Width;
                //else
                //    width = myGrid.Width;

                width = 150.0;

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
                    height = this.Height;
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
        public Double CalculateWidthOfRectangle(Int32 countItemsSource, Double widthComponent)
        {
            Double minWidth = 50.0;
            Double width = 0.0;
            width = widthComponent / countItemsSource - (widthComponent / 10);
            if (width < minWidth)
                return minWidth;
            else
                return width;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countItemsSource"></param>
        /// <param name="height"></param>
        /// <param name="dependentValue"></param>
        /// <returns></returns>
        public Double CalculateHeightOfRectangle(Double heightComponent, Double dependentValue)
        {
            Double height = 0.0;

            if (this.Height.Equals(Double.NaN))
                height = 640.0;
            else
                height = (this.Parent as Control).Height;

            // ToDo Gustavo: Implementar lógica para controlar min/max de Height do component.

            return  (heightComponent / height) * dependentValue;
        }

        #endregion
    }
}
