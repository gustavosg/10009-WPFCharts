using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChartLibrary;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco é documentado em http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <resumo>
    /// Uma página vazia que pode ser usada sozinho ou navigated para dentro de um Frame.
    /// </resumo>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

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

        /// <resumo>
        /// Chamado quando esta página é exibida num Frame.
        /// </resumo>
        /// <param name="e">Dados de evento que descrevem como essa página foi atingida.  O parâmetro
        /// propriedade normalmente é usada para configurar a página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
