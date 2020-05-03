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
    /// Логика взаимодействия для RisksFilter.xaml
    /// </summary>
    public partial class RisksFilter : UserControl
    {
        private MainViewModel _viewModel;
        
        public RisksFilter()
        {
            InitializeComponent();
        }

        private void RisksFilter_OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MainViewModel;
            LoadFilter();
        }

        private void LoadFilter()
        {
            LoadProjects();
            LoadDepartments();
            LoadClassification();
            ResponsibilityNo.IsChecked = true;
        }

        private void LoadProjects()
        {
            ProjectsFilter.Children.Clear();
            foreach (var t in _viewModel.Projects)
            {
                CheckBox cb = new CheckBox
                {
                    Style = Application.Current.FindResource("BaseCheckBox") as Style,
                    Content = t.Name
                };
                ProjectsFilter.Children.Add(cb);
            }
        }

        private void LoadDepartments()
        {
            DepartmentsFilter.Children.Clear();
            foreach (var t in _viewModel.Departments)
            {
                CheckBox cb = new CheckBox
                {
                    Style = Application.Current.FindResource("BaseCheckBox") as Style,
                    Content = t.Name
                };
                DepartmentsFilter.Children.Add(cb);
            }

        }

        private void LoadClassification()
        {
            ClassificationFilter.Children.Clear();
            foreach (var t in _viewModel.Classifications)
            {
                CheckBox cb = new CheckBox
                {
                    Style = Application.Current.FindResource("BaseCheckBox") as Style,
                    Content = t.Name
                };
                ClassificationFilter.Children.Add(cb);
            }

        }

        private void ResetRisksFilter_OnClick(object sender, RoutedEventArgs e)
        {
            LoadFilter();
            _viewModel.GetRisks();
        }

        private void ApplyRisksFilter_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetRisks(false);
            List<Risk> risks = new List<Risk>();
            ApplyProjects(risks);
            ApplyDepartments(risks);
            ApplyClassification(risks);
            risks = ApplyResponsibility(risks);

            _viewModel.Risks = risks.Distinct().ToArray();
            _viewModel.GetRisksEvent?.Invoke(null, null);
        }

        private void ApplyProjects(List<Risk> risks)
        {
            List<int> projects = new List<int>();
            for(int i = 0; i < ProjectsFilter.Children.Count; ++i)
            {
                if (((CheckBox)ProjectsFilter.Children[i]).IsChecked == true)
                {
                    projects.Add(_viewModel.Projects[i].Id);
                }
            }

            foreach (var t in projects)
            {
                risks.AddRange(_viewModel.Risks.Where(x => x.Project.Id == t));
            }
        }

        private void ApplyDepartments(List<Risk> risks)
        {
            List<int> deps = new List<int>();
            for (int i = 0; i < ProjectsFilter.Children.Count; ++i)
            {
                if (((CheckBox)DepartmentsFilter.Children[i]).IsChecked == true)
                {
                    deps.Add(_viewModel.Departments[i].Id);
                }
            }

            List<int> projects = new List<int>();

            foreach (var t in deps)
            {
                projects.AddRange(_viewModel.Projects.Where(x => x.Department.Id == t).Select(x => x.Id));
            }

            foreach (var t in projects)
            {
                risks.AddRange(_viewModel.Risks.Where(x => x.Project.Id == t));
            }
        }

        private List<Risk> ApplyResponsibility(List<Risk> risks)
        {
            if (risks.Count == 0)
            {
                risks = _viewModel.Risks.ToList();
            }

            if (ResponsibilityYes.IsChecked == false)
            {
                risks = risks.Except(risks.Where(x => x.ResponsiblePerson.Id == _viewModel.CurrentUser.Id)).ToList();
            }

            if (ResponsibilityNo.IsChecked == false)
            {
                risks = risks.Except(risks.Where(x => x.ResponsiblePerson.Id != _viewModel.CurrentUser.Id)).ToList();
            }

            return risks;
        }

        private void ApplyClassification(List<Risk> risks)
        {
            List<int> classes = new List<int>();
            for (int i = 0; i < ProjectsFilter.Children.Count; ++i)
            {
                if (((CheckBox)ClassificationFilter.Children[i]).IsChecked == true)
                {
                    classes.Add(_viewModel.Classifications[i].Id);
                }
            }

            foreach (var t in classes)
            {
                risks.AddRange(_viewModel.Risks.Where(x => x.Classification.Id == t));
            }
        }
    }
}
