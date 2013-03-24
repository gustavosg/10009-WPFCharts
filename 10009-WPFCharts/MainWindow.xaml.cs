// --------------------------------------------------------------------------------------
// 
// 
// --------------------------------------------------------------------------------------
// 
// 
// --------------------------------------------------------------------------------------
// Autor: Gustavo Souza Gonçalves
// Data: 15/03/2013
// --------------------------------------------------------------------------------------
// Versão:
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

            AddRectanglesToGrid();
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

            //for (int i = 1; i < num.Next(300); i++)
            //{
            //    DataPoint pointItem = new DataPoint()
            //    {
            //        IndependentValue = "Title " + i,
            //        DependentValue = i * 100,
            //        ToolTip = "Title " + i
            //    };
            //    dataPoints.Add(pointItem);

            //}

            DataPoint pointItem = new DataPoint()
            {
                IndependentValue = "Title 1",
                DependentValue = 100,
                ToolTip = "Title 1"
            };
            dataPoints.Add(pointItem);
            return dataPoints;

        }

        /// <summary>
        /// 
        /// </summary>
        public void AddRectanglesToGrid()
        {
            if (myGrid.ActualHeight == double.NaN)
                myGrid.Height = (myGrid.Parent as Window).ActualHeight;

            if (myGrid.ActualWidth == double.NaN)
                myGrid.Width = (myGrid.Parent as Window).ActualWidth;

            foreach (var item in GenerateRectangle())
            {

                myGrid.Children.Add(item);
            }

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

            foreach (var item in ItemsSource)
            {
                Rectangle rect = new Rectangle();

                rect.Height = item.DependentValue;
                rect.Width = (ItemsSource as IList).Count * 10;
                rect.Fill = Colorize.GetSingleton().GenerateColor();
                rect.ToolTip = item.IndependentValue;

                rect.SetValue(Grid.RowProperty, 0);
                rect.SetValue(Grid.ColumnProperty, 0);

                rect.StrokeThickness = 2.0;

                // this set location of component in screen
                rect.Margin = new Thickness(0, 0, 0, 0);
                rectangleList.Add(rect);
            }


            //Rectangle rect = new Rectangle();
            //double width = myGrid.Width;
            //rect.Height = GetActualHeightParentControl() / 1;
            //rect.Width = GetActualWidthParentContent() / 4;
            //rect.Fill = Colorize.GetSingleton().GenerateColor();
            //rect.ToolTip = "Estou aqui!";

            //rect.SetValue(Grid.RowProperty, 0);
            //rect.SetValue(Grid.ColumnProperty, 0);

            return rectangleList;
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