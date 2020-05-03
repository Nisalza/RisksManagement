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
using RisksManagementClient.ServiceRisksManagement;
using RisksManagementClient.ViewModels;

namespace RisksManagementClient.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для StrategiesFilter.xaml
    /// </summary>
    public partial class StrategiesFilter : UserControl
    {
        private MainViewModel _viewModel;

        public StrategiesFilter()
        {
            InitializeComponent();
        }

        private void StrategiesFilter_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MainViewModel;
            LoadFilter();
        }

        private void LoadFilter()
        {
            LoadStrategyTypes();
        }

        private void LoadStrategyTypes()
        {
            StrategyTypesFilter.Children.Clear();
            foreach (var t in _viewModel.StrategyTypes)
            {
                CheckBox cb = new CheckBox
                {
                    Style = Application.Current.FindResource("BaseCheckBox") as Style,
                    Content = t.Name
                };
                StrategyTypesFilter.Children.Add(cb);
            }
        }

        private void ApplyStrategiesFilter_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetStrategies(false);
            List<Strategy> strategies = new List<Strategy>();
            ApplyStrategyTypes(strategies);

            _viewModel.Strategies = strategies.ToArray();
           _viewModel.GetStrategiesEvent?.Invoke(null, null);
        }

        private void ResetStrategiesFilter_Click(object sender, RoutedEventArgs e)
        {
            LoadFilter();
            _viewModel.GetStrategies();
        }

        private void ApplyStrategyTypes(List<Strategy> strategies)
        {
            List<int> st = new List<int>();
            for (int i = 0; i < StrategyTypesFilter.Children.Count; ++i)
            {
                if (((CheckBox)StrategyTypesFilter.Children[i]).IsChecked == true)
                {
                    st.Add(_viewModel.StrategyTypes[i].Id);
                }
            }

            foreach (var t in st)
            {
                strategies.AddRange(_viewModel.Strategies.Where(x => x.StrategyType.Id == t));
            }
        }
    }
}
