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
        private Strategy _strategy;

        private MainViewModel _viewModel;

        public StrategyShortInfo(Strategy strategy)
        {
            InitializeComponent();
            _strategy = strategy;
        }

        private void StrategyFullInfo_OnLoaded(object sender, RoutedEventArgs e)
        {
            StrategyDescription.Text = _strategy.Description;
            StrategyType.Text = _strategy.StrategyType.Name;
            _viewModel = DataContext as MainViewModel;
        }

        private void DuplicateButton_Click(object sender, RoutedEventArgs e)
        {
            _strategy.Id = 0;
            ShowStrategyInfoWindow(new CreateStrategyStrategy(), "создана");
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ShowStrategyInfoWindow(new UpdateStrategyStrategy(), "обновлена");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ExecuteOperation(new DeleteStrategyStrategy(), "удалена");
        }

        private void ShowStrategyInfoWindow(IStrategy strategy, string action)
        {
            StrategyInfoWindow window = new StrategyInfoWindow(_strategy, _viewModel.StrategyTypes);
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                _strategy = window.StrategyFullInfo.Strategy;
                ExecuteOperation(strategy, action);
            }
        }

        private void ExecuteOperation(IStrategy strategy, string action)
        {
            _viewModel.StrategyContext.SetStrategy(strategy);
            _viewModel.StrategySaving?.Invoke(_strategy, EventArgs.Empty);

            bool ok = _viewModel.StrategyContext.Result;
            MessageBoxes mb = new MessageBoxes();
            if (ok)
            {
                mb.ShowOkResult($"Стратегия успешно {action}.");
                MainWindow w = (MainWindow) Window.GetWindow(this);
                w.MainView.LoadStrategies();
            }
            else
            {
                mb.ShowErrorResult($"Стратегия не была {action}.");
            }
        }
    }
}
