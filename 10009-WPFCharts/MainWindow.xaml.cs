// --------------------------------------------------------------------------------------
// 
// 
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

#region References

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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

            IList<DataPoint> dataSource = new List<DataPoint>();

            dataSource.Clear();

            dataSource.Add(new DataPoint { IndependentValue = "Sapatos", DependentValue = 100 });
            dataSource.Add(new DataPoint { IndependentValue = "Meias", DependentValue = 50 });
            dataSource.Add(new DataPoint { IndependentValue = "Botas", DependentValue = 100 });
            dataSource.Add(new DataPoint { IndependentValue = "Chinelos", DependentValue = 50 });

            myChart.ItemsSource = dataSource;

            //ColumnChart chart = new ColumnChart();

            //foreach (var item in chart.AddRectanglesToGrid())
            //    myGrid.Children.Add(item);

            //myGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            //myGrid.VerticalAlignment = VerticalAlignment.Stretch;
            
        }

        #endregion

        //#region Methods

        ///// <summary>
        ///// Generates DataPoints with random values
        ///// </summary>
        ///// <returns>List of DataPoint</returns>
        //public IList<DataPoint> GenerateData()
        //{
        //    IList<DataPoint> dataPoints = new List<DataPoint>();

        //    Random num = new Random();

        //    for (int i = 1; i < num.Next(50); i++)
        //    {
        //        DataPoint pointItem = new DataPoint()
        //        {
        //            IndependentValue = "Title " + i,
        //            DependentValue = i * 100,
        //            ToolTip = "Title " + i
        //        };
        //        dataPoints.Add(pointItem);

        //    }
        //    return dataPoints;

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public void AddRectanglesToGrid()
        //{
        //    if (myGrid.ActualHeight == double.NaN)
        //        myGrid.Height = (myGrid.Parent as Window).ActualHeight;

        //    if (myGrid.ActualWidth == double.NaN)
        //        myGrid.Width = (myGrid.Parent as Window).ActualWidth;

        //    foreach (Rectangle item in GenerateRectangle())
        //    {
        //        item.VerticalAlignment = VerticalAlignment.Bottom;

        //        myGrid.Children.Add(item);
        //    }
        //}
        ///// <summary>
        ///// Generate Rectangle with values
        ///// </summary>
        ///// <returns>Drawed Rectangle</returns>
        //private IList<Rectangle> GenerateRectangle()
        //{
        //    ItemsSource = GenerateData();
        //    IList<Rectangle> rectangleList = new List<Rectangle>();
        //    rectangleList.Clear();

        //    Int32 countItemsSource = (ItemsSource as IList).Count;

        //    Double widthComponent = GetActualWidthParentContent();

        //    Double widthPosition = widthComponent / countItemsSource;

        //    Double positionX = -widthComponent;

        //    foreach (var item in ItemsSource)
        //    {
        //        Rectangle rect = new Rectangle();

        //        //rect.Height = item.DependentValue ;
        //        rect.Height = item.DependentValue / (this.Height / 50);

        //        rect.Width = CalculateWidthOfRectangle(countItemsSource, GetActualWidthParentContent());
        //        //rect.Width = 10;
        //        rect.Fill = Colorize.GetSingleton().GenerateColor();
        //        rect.ToolTip = item.IndependentValue + " (" + item.DependentValue + ") ";

        //        // Configures border/BorderColor of rectangle
        //        rect.StrokeThickness = 1.5;
        //        rect.Stroke = new SolidColorBrush(Colors.Black);

        //        // this set location of component in screen
        //        rect.Margin = new Thickness(widthPosition + positionX / 2, 0, 0, 0);

        //        // position of component in grid
        //        widthPosition += widthComponent / countItemsSource;

        //        // Sets Vertical Alignment of rectangle to bottom
        //        rect.VerticalAlignment = VerticalAlignment.Bottom;

        //        rectangleList.Add(rect);
        //    }

        //    return rectangleList;
        //}

        ///// <summary>
        ///// Get Actual Width from container component
        ///// </summary>
        ///// <returns>Double Value</returns>
        //public Double GetActualWidthParentContent()
        //{
        //    if (this.myGrid.ActualWidth == double.NaN || this.myGrid.ActualWidth == 0.0)
        //        return this.Width;
        //    else
        //        return System.Windows.SystemParameters.PrimaryScreenWidth;
        //}

        ///// <summary>
        ///// Get Actual Height from container component
        ///// </summary>
        ///// <returns>Double Value</returns>
        //public Double GetActualHeightParentControl()
        //{
        //    //if (this.myGrid.ActualHeight == double.NaN || this.myGrid.ActualHeight == 0.0)
        //    //    return this.Height;
        //    //else
        //    return (this.myGrid.Parent as Control).Height;
        //    //return System.Windows.SystemParameters.PrimaryScreenHeight;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="countItemsSource"></param>
        ///// <param name="width"></param>
        ///// <returns></returns>
        //public Double CalculateWidthOfRectangle(Int32 countItemsSource, Double width)
        //{
        //    //return width / countItemsSource - (countItemsSource / 10) ;
        //    return width / countItemsSource - (width / 10);
        //}

        //#endregion
    }
}