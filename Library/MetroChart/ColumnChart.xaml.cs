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
using ChartLibrary.Utils;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

#endregion

namespace ChartLibrary
{
    /// <summary>
    /// Interação lógica para ColumnChart.xam
    /// </summary>
    public partial class ColumnChart : UserControl
    {
        #region Fields
        Colorize generateColors;

        #endregion;

        #region Properties

        private IEnumerable<DataPoint> itemsSource;
        public IEnumerable<DataPoint> ItemsSource
        {
            get { return itemsSource; }
            set
            {
                itemsSource = value;
                if (value != null)
                {
                    generateColors = new Colorize();
                    AddRectanglesToGrid();
                }
            }
        }

        #endregion

        #region Constructor

        public ColumnChart()
        {
            InitializeComponent();
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

            if (ItemsSource != null)
                foreach (DataPoint item in ItemsSource)
                    dataPoints.Add(item);

            return dataPoints;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<DataPoint> GenerateDataTest()
        {
            //Random rand = new Random();
            //Int16 value = 0;

            //while (value <= 3)
            //    value = Convert.ToInt16(rand.Next(150));

            //for (int i = 1; i <= value; i++)
            //{
            //    DataPoint pointItem = new DataPoint()
            //    {
            //        IndependentValue = "Title " + i,
            //        DependentValue = i * 1,

            //    };
            //    dataPoints.Add(pointItem);
            //}
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public IList<UIElement> AddRectanglesToGrid()
        {
            IList<UIElement> children = new List<UIElement>();

            if (myGrid.ActualHeight == double.NaN)
                myGrid.Height = (myGrid.Parent as FrameworkElement).ActualHeight;

            if (myGrid.ActualWidth == double.NaN)
                myGrid.Width = (myGrid.Parent as FrameworkElement).ActualWidth;

            foreach (Rectangle item in GenerateRectangle())
            {
                item.VerticalAlignment = VerticalAlignment.Bottom;

                myGrid.Children.Add(item);
            }

            return children;
        }

        /// <summary>
        /// Generate Rectangle with values
        /// </summary>
        /// <returns>Drawed Rectangle</returns>
        private IList<Rectangle> GenerateRectangle()
        {
            IList<Rectangle> rectangleList = new List<Rectangle>();

            rectangleList.Clear();

            //try
            //{
                if (ItemsSource != null)
                {
                    Int32 countItemsSource = (ItemsSource as IList).Count;
                    Double widthComponent = GetActualWidthParentContent();
                    Double widthPosition = widthComponent / (countItemsSource * 2);
                    Double positionX = -widthComponent;
                    IList<SolidColorBrush> colors = new List<SolidColorBrush>();

                    colors.Clear();

                    Double countColors = itemsSource.Max() / 4;

                    for (int i = 0; i < countColors; i++)
                        colors.Add(generateColors.GenerateColor());

                    foreach (var item in ItemsSource)
                    {
                        Rectangle rect = new Rectangle();

                        rect.Height = CalculateHeightOfRectangle(GetActualHeightParentControl(), item.DependentValue);

                        rect.Width = CalculateWidthOfRectangle(countItemsSource, GetActualWidthParentContent());

                        if (item.DependentValue <= countColors)
                            rect.Fill = colors[0];
                        else if (item.DependentValue <= countColors * 2)
                            rect.Fill = colors[1];
                        else if (item.DependentValue <= countColors * 3)
                            rect.Fill = colors[2];
                        else
                            rect.Fill = colors[3];

                        //rect.ToolTip = item.IndependentValue + " (" + item.DependentValue + ") ";

                        // Configures Border/BorderColor of rectangle
                        rect.StrokeThickness = 1.5;
                        rect.Stroke = new SolidColorBrush(Colors.Black);

                        // Set location of component in screen
                        rect.Margin = new Thickness(widthPosition + positionX / 2, 0, 0, 0);

                        // position of component in grid
                        widthPosition += widthComponent / countItemsSource;

                        // Sets Vertical Alignment of rectangle to bottom
                        rect.VerticalAlignment = VerticalAlignment.Bottom;

                        rectangleList.Add(rect);
                    }
                }
                return rectangleList;
            //}
            //catch (Exception)
            //{
            //    throw new Exception("Não foi informado um data source!");
            //}

        }

        /// <summary>
        /// Get Actual Width from container component
        /// </summary>
        /// <returns>Double Value</returns>
        public Double GetActualWidthParentContent()
        {
            //if (myGrid.ActualWidth.Equals(double.NaN) || myGrid.ActualWidth.Equals(0.0) ||
            //    (myGrid.Width.Equals(double.NaN) || myGrid.Width.Equals(0.0)))

            return myGrid.Width;
            //else

            //    return System.Windows.SystemParameters.PrimaryScreenWidth;
        }

        /// <summary>
        /// Get Actual Height from container component
        /// </summary>
        /// <returns>Double Value</returns>
        public Double GetActualHeightParentControl()
        {
            Double height = 0.0;

            if (this.myGrid.ActualHeight == double.NaN || this.myGrid.ActualHeight == 0.0)
            {
                if (myGrid.Height.Equals(Double.NaN))
                    height = this.Height;
                else
                    height = myGrid.Height;
            }
            return height;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countItemsSource"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public Double CalculateWidthOfRectangle(Int32 countItemsSource, Double widthComponent)
        {
            Double widthForComponent = (widthComponent / countItemsSource) / 2;

            return widthForComponent - (widthForComponent * 0.10);
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

            if (myGrid.Height.Equals(Double.NaN))
                height = 640.0;
            else
                height = myGrid.Height;

            Double proportion = dependentValue * (height / ItemsSource.Max());

            return (proportion) - (proportion / 10);
        }

        #endregion
    }
}
