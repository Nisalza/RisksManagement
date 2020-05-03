﻿using System;
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
using RisksManagementClient.UI.Windows;
using RisksManagementClient.ViewModels;

namespace RisksManagementClient.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для RiskShortInfoView.xaml
    /// </summary>
    public partial class RiskShortInfoView : UserControl
    {
        private readonly Risk _risk;

        private MainViewModel _viewModel;

        public EventHandler DeleteRisk;

        public RiskShortInfoView(Risk risk)
        {
            InitializeComponent();
            _risk = risk;
        }

        private void RiskShortInfoView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MainViewModel;
            RiskId.Content = _risk.Id.ToString();
            RiskName.Content = _risk.Name;
            RiskDescription.Content = _risk.Description;
            RiskProject.Content = _risk.Project.Name;
            RiskResponsiblePerson.Content = _risk.ResponsiblePerson.Name;
            RiskValue.Content = _risk.Value.ToString();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentRisk = _risk;
            ShowRiskFullInfoView(new UpdateRiskStrategy());
        }

        private void DuplicateButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentRisk = _risk;
            ShowRiskFullInfoView(new CreateRiskStrategy());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CurrentRisk = _risk;
            _viewModel.RiskContext.SetStrategy(new DeleteRiskStrategy());
            _viewModel.RiskSaving?.Invoke(null, EventArgs.Empty);

            
            bool ok = _viewModel.RiskContext.Result;
            MessageBoxes mb = new MessageBoxes();
            if (ok)
            {
                DeleteRisk?.Invoke(_risk, EventArgs.Empty);
                mb.ShowOkResult("Операция выполнена.");
            }
            else { mb.ShowErrorResult("Операция не была выполнена."); }
        }

        private void ShowRiskFullInfoView(IStrategy strategy)
        {
            RiskFullInfoView riskFullInfoView = new RiskFullInfoView();
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.MainView.RiskScroll.Content = riskFullInfoView;
            w.MainView.ShowSaveDeleteButtonsRisk();
            _viewModel.RiskContext.SetStrategy(strategy);
            w.MainView.LoadRisks();
        }
    }
}
