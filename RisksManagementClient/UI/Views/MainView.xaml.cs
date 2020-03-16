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
using RisksManagementClient.ViewModels;
using RisksManagementService.Database.Models;

namespace RisksManagementClient.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private readonly MainViewModel _viewModel;

        public MainView()
        {
            InitializeComponent();
            _viewModel = DataContext as MainViewModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel?.ViewLoaded(this, EventArgs.Empty);
        }

        #region Риски

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RiskFullInfoView riskFullInfoView = new RiskFullInfoView(new Risk() {Id = 3});
            RiskScroll.Content = riskFullInfoView;
        }

        #endregion
    }
}
