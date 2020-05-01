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
using LiveCharts.Wpf;
using RisksManagementClient.ServiceRisksManagement;
using RisksManagementClient.Strategies;
using RisksManagementClient.Strategies.RiskStrategies;
using RisksManagementClient.Strategies.StrategyStrategies;
using RisksManagementClient.UI.Windows;
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
            LoadRisks();
            LoadStrategies();
            LoadRisksForMap();
            CartesianChart.AxisX.Clear();
            CartesianChart.AxisX.Add(new Axis{MinValue = 0, MaxValue = 1});
            CartesianChart.AxisY.Clear();
            CartesianChart.AxisY.Add(new Axis { MinValue = 0, MaxValue = 1 });
        }

        #region Риски

        private void CreateRisk_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentRisk = new Risk();
            RiskFullInfoView riskFullInfoView = new RiskFullInfoView();
            RiskScroll.Content = riskFullInfoView;
            ShowSaveDeleteButtonsRisk();

            IStrategy strategy = new CreateRiskStrategy();
            _viewModel.RiskContext.SetStrategy(strategy);
        }

        private void SaveCurrentRisk_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.RiskSaving?.Invoke(null, EventArgs.Empty);
            bool ok = _viewModel.RiskContext.Result;

            MessageBoxes mb = new MessageBoxes();
            if (ok)
            {
                mb.ShowOkResult("Операция выполнена.");
                LoadRisks();
                RiskScroll.Content = null;
                CollapseSaveDeleteButtonsRisk();
            }
            else { mb.ShowErrorResult("Операция не была выполнена.");}
        }

        private void CloseCurrentRisk_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentRisk = null;
            RiskScroll.Content = null;
            CollapseSaveDeleteButtonsRisk();
        }

        public void LoadRisks()
        {
            AllRisks.Children.Clear();
            foreach (Risk r in _viewModel.Risks)
            {
                RiskShortInfoView uc = new RiskShortInfoView(r);
                uc.DeleteRisk += DeleteRisk;
                AllRisks.Children.Add(uc);
            }
        }

        private void DeleteRisk(object sender, EventArgs e)
        {
            if (((Risk) sender)?.Id == _viewModel.CurrentRisk?.Id)
            {
                CloseCurrentRisk_Click(null, null);
            }
        }

        public void ShowSaveDeleteButtonsRisk()
        {
            SaveCurrentRisk.Visibility = Visibility.Visible;
            CloseCurrentRisk.Visibility = Visibility.Visible;
        }

        public void CollapseSaveDeleteButtonsRisk()
        {
            SaveCurrentRisk.Visibility = Visibility.Collapsed;
            CloseCurrentRisk.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Стратегии

        private void CreateStrategy_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentStrategy = new Strategy();
            StrategyFullInfo strategyFullInfo = new StrategyFullInfo();
            StrategyScroll.Children.Add(strategyFullInfo);
            ShowSaveDeleteButtonsStrategy();

            IStrategy strategy = new CreateStrategyStrategy();
            _viewModel.StrategyContext.SetStrategy(strategy);
        }

        public void ShowSaveDeleteButtonsStrategy()
        {
            SaveStrategy.Visibility = Visibility.Visible;
            CloseStrategy.Visibility = Visibility.Visible;
        }

        public void CollapseSaveDeleteButtonsStrategy()
        {
            SaveStrategy.Visibility = Visibility.Collapsed;
            CloseStrategy.Visibility = Visibility.Collapsed;
        }

        private void SaveStrategy_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.StrategySaving?.Invoke(_viewModel.CurrentStrategy, EventArgs.Empty);
            bool ok = _viewModel.StrategyContext.Result;

            MessageBoxes mb = new MessageBoxes();
            if (ok)
            {
                mb.ShowOkResult("Операция выполнена.");
                LoadStrategies();
                StrategyScroll.Children.Clear();
                CollapseSaveDeleteButtonsStrategy();
            }
            else { mb.ShowErrorResult("Операция не была выполнена."); }
        }

        private void CloseStrategy_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentStrategy = null;
            StrategyScroll.Children.Clear();
            CollapseSaveDeleteButtonsStrategy();
        }

        public void LoadStrategies()
        {
            AllStrategies.Children.Clear();
            foreach (Strategy s in _viewModel.MitigationStrategies)
            {
                StrategyShortInfo uc = new StrategyShortInfo(s);
                uc.DeleteStrategy += DeleteStrategy;
                AllStrategies.Children.Add(uc);
            }

            foreach (Strategy s in _viewModel.ContingencyStrategies)
            {
                StrategyShortInfo uc = new StrategyShortInfo(s);
                AllStrategies.Children.Add(uc);
            }
        }

        private void DeleteStrategy(object sender, EventArgs e)
        {
            if (((Strategy) sender)?.Id == _viewModel.CurrentStrategy?.Id)
            {
                CloseStrategy_Click(null, null);
            }
        }

        #endregion

        #region Карта рисков

        private void LoadRisksForMap()
        {
            RisksForMap.Children.Clear();
            foreach (Risk r in _viewModel.Risks)
            {
                TextBox t = new TextBox
                {
                    Text = $"({r.Id}) {r.Name}",
                    IsReadOnly = true
                };
                RisksForMap.Children.Add(t);
            }
        }

        #endregion
    }
}
