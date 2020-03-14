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
using RisksManagementClient.UI.Windows;
using RisksManagementClient.ViewModels;

namespace RisksManagementClient.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        private MainViewModel _viewModel;

        public AccountView()
        {
            InitializeComponent();
        }

        private void UserSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel?.UserSaving?.Invoke(null, EventArgs.Empty);
        }

        private void DepartmentsDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DepartmentsDataGrid.SelectedItem == null) return;

            int index = DepartmentsDataGrid.SelectedIndex;
            AppUser user = _viewModel.Departments[index].Supervisor;
            if (user.Id == 0)
            {
                MessageBox.Show("Для подразделения не назначен руководитель.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            PersonInfoWindow personInfo = new PersonInfoWindow(user, _viewModel.Departments[index].Name);
            personInfo.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MainViewModel;
        }

        private void ProjectsDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ProjectsDataGrid.SelectedItem == null) return;

            int index = ProjectsDataGrid.SelectedIndex;
            AppUser user = _viewModel.Projects[index].Supervisor;
            if (user.Id == 0)
            {
                MessageBox.Show("Для проекта не назначен руководитель.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            PersonInfoWindow personInfo = new PersonInfoWindow(user, _viewModel.Projects[index].Name);
            personInfo.Show();
        }
    }
}