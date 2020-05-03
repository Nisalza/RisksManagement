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
using RisksManagementClient.Strategies.StrategyStrategies;
using RisksManagementClient.UI.Windows;
using RisksManagementClient.ViewModels;

namespace RisksManagementClient.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для StrategyShortInfo.xaml
    /// </summary>
    public partial class StrategyShortInfo : UserControl
    {
        private readonly Strategy _strategy;

        private MainViewModel _viewModel;

        public EventHandler DeleteStrategy;

        public StrategyShortInfo(Strategy strategy)
        {
            InitializeComponent();
            _strategy = strategy;
        }

        private void StrategyFullInfo_OnLoaded(object sender, RoutedEventArgs e)
        {
            StrategyDescription.Content = _strategy.Description;
            StrategyType.Content = _strategy.StrategyType.Name;
            _viewModel = DataContext as MainViewModel;
        }

        private void DuplicateButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentStrategy = _strategy;
            ShowStrategyFullInfoView(new CreateStrategyStrategy());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentStrategy = _strategy;
            ShowStrategyFullInfoView(new UpdateStrategyStrategy());
        }

        private void ShowStrategyFullInfoView(IStrategy strategy)
        {
            StrategyFullInfo strategyFullInfo = new StrategyFullInfo();
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.MainView.StrategyScroll.Children.Add(strategyFullInfo);
            w.MainView.ShowSaveDeleteButtonsStrategy();
            _viewModel.StrategyContext.SetStrategy(strategy);
            w.MainView.LoadStrategies();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation(new DeleteStrategyStrategy());
        }

        private void ExecuteOperation(IStrategy strategy)
        {
            _viewModel.StrategyContext.SetStrategy(strategy);
            _viewModel.StrategySaving?.Invoke(_strategy, EventArgs.Empty);

            bool ok = _viewModel.StrategyContext.Result;
            MessageBoxes mb = new MessageBoxes();
            if (ok)
            {
                DeleteStrategy?.Invoke(_strategy, EventArgs.Empty);
                mb.ShowOkResult("Операция выполена.");
            }
            else
            {
                mb.ShowErrorResult("Операция не была выполнена");
            }
        }
    }
}
