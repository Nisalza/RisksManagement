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

            RiskPt.SelectedIndex = Array.IndexOf(_viewModel.ProbabilityTypes, _viewModel.ProbabilityTypes.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.ProbabilityType?.Id));
            RiskProb.SelectedIndex = Array.IndexOf(_viewModel.Probabilities, _viewModel.Probabilities.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.Probability?.Id));
            RiskIt.SelectedIndex = Array.IndexOf(_viewModel.ImpactTypes, _viewModel.ImpactTypes.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.ImpactType?.Id));
            RiskImpact.SelectedIndex = Array.IndexOf(_viewModel.Impacts, _viewModel.Impacts.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.Impact?.Id));
            RiskPriority.SelectedIndex = Array.IndexOf(_viewModel.Priorities, _viewModel.Priorities.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.Priority?.Id));
            RiskRp.SelectedIndex = Array.IndexOf(_viewModel.ResponsiblePersons, _viewModel.ResponsiblePersons.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.ResponsiblePerson?.Id));
            RiskMs.SelectedIndex = Array.IndexOf(_viewModel.MitigationStrategies, _viewModel.MitigationStrategies.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.MitigationStrategy?.Id));
            RiskCs.SelectedIndex = Array.IndexOf(_viewModel.ContingencyStrategies, _viewModel.ContingencyStrategies.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.ContingencyStrategy?.Id));
            RiskRelevance.SelectedIndex = Array.IndexOf(_viewModel.Relevances, _viewModel.Relevances.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.IsRelevance?.Id));
            RiskCause.SelectedIndex = Array.IndexOf(_viewModel.RiskCauses, _viewModel.RiskCauses.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.RiskCause?.Id));
            RiskProject.SelectedIndex = Array.IndexOf(_viewModel.Projects, _viewModel.Projects.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.Project?.Id));
            RiskClassification.SelectedIndex = Array.IndexOf(_viewModel.Classifications, _viewModel.Classifications.FirstOrDefault(x =>
                x.Id == _viewModel.CurrentRisk?.Classification?.Id));
        }

        private void RiskPt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel?.UpdateProbabilities();
        }

        private void RiskIt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel?.UpdateImpacts();
        }

        private void RiskProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel?.UpdateRp();
        }
    }
}
