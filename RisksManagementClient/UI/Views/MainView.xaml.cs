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
using RisksManagementClient.Strategies;
using RisksManagementClient.Strategies.RiskStrategies;
using RisksManagementClient.ViewModels;

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

        private void CreateRisk_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentRisk = new Risk();
            RiskFullInfoView riskFullInfoView = new RiskFullInfoView();
            RiskScroll.Content = riskFullInfoView;
            ShowSaveDeleteButtons();

            IStrategy strategy = new CreateRiskStrategy();
            _viewModel.RiskContext.SetStrategy(strategy);
        }

        private void SaveCurrentRisk_OnClick(object sender, RoutedEventArgs e)
        {
            bool ok = _viewModel.RiskContext.ExecuteStrategy(_viewModel.CurrentRisk);

            if (ok) { ShowOkResult("Риск успешно создан.");}
            else { ShowErrorResult("Риск не был создан.");}
        }

        private void CloseCurrentRisk_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentRisk = null;
            RiskScroll.Content = null;
            CollapseSaveDeleteButtons();
        }

        private void CollapseSaveDeleteButtons()
        {
            SaveCurrentRisk.Visibility = Visibility.Collapsed;
            CloseCurrentRisk.Visibility = Visibility.Collapsed;
        }

        private void ShowSaveDeleteButtons()
        {
            SaveCurrentRisk.Visibility = Visibility.Visible;
            CloseCurrentRisk.Visibility = Visibility.Visible;
        }

        #endregion

        private void ShowOkResult(string msg, string caption = "Результат выполнения операции")
        {
            MessageBox.Show(msg, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowErrorResult(string msg, string caption = "Результат выполнения операции")
        {
            MessageBox.Show(msg, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
