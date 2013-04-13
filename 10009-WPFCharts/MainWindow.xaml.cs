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
using ChartLibrary;


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
            dataSource.Add(new DataPoint { IndependentValue = "Chinelos", DependentValue = 25 });

            dataSource.Add(new DataPoint { IndependentValue = "Sapatos", DependentValue = 100 });
            dataSource.Add(new DataPoint { IndependentValue = "Meias", DependentValue = 75 });
            dataSource.Add(new DataPoint { IndependentValue = "Botas", DependentValue = 100 });
            dataSource.Add(new DataPoint { IndependentValue = "Chinelos", DependentValue = 50 });

            myChart.ItemsSource = dataSource;

        }

        #endregion
    }
}