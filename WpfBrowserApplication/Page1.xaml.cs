using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChartLibrary;

namespace WpfBrowserApplication1
{
    /// <summary>
    /// Interação lógica para Page1.xam
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
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
    }
}
