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
using Prism.Services.Dialogs;
using RisksManagementClient.ServiceRisksManagement;
using RisksManagementClient.ViewModels;

namespace RisksManagementClient.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для StrategyFullInfo.xaml
    /// </summary>
    public partial class StrategyFullInfo : UserControl
    {
        private MainViewModel _viewModel;

        public StrategyFullInfo()
        {
            InitializeComponent();
        }

        private void StrategyFullInfo_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MainViewModel;
            StrategyTypes.SelectedIndex = Array.IndexOf(_viewModel.StrategyTypes, _viewModel.StrategyTypes.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentStrategy?.StrategyType?.Id));
        }
    }
}
