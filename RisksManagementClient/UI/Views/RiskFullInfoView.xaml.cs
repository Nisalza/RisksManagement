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
    /// Логика взаимодействия для RiskFullInfoView.xaml
    /// </summary>
    public partial class RiskFullInfoView : UserControl
    {
        private MainViewModel _viewModel;

        public RiskFullInfoView()
        {
            InitializeComponent();
        }

        private void RiskFullInfoView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MainViewModel;
        }

        private void RiskPt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.UpdateProbabilities();
        }

        private void RiskIt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.UpdateImpacts();
        }

        private void RiskProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.UpdateRp();
        }
    }
}
