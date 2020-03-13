using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using RisksManagementClient.ServiceRisksManagement;

namespace RisksManagementClient.ViewModels
{
    public class MainViewModel : BindableBase, IServiceCallback
    {
        #region Поля
        
        public ServiceClient Client;

        private AppUser _currentUser;

        private Department[] _departments;

        private Project[] _projects;

        public AppUser CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                RaisePropertyChanged();
            }
        }

        public Department[] Departments
        {
            get => _departments;
            set
            {
                _departments = value;
                RaisePropertyChanged();
            }
        }

        public Project[] Projects
        {
            get => _projects;
            set
            {
                _projects = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region События

        public EventHandler ViewLoaded;

        #endregion

        #region Методы событий

        private void OnViewLoaded(object sender, EventArgs e)
        {
            //todo Убрать дефолтный логин
            CurrentUser = Client.Connect(@"ALZA/Dashi");
            Departments = Client.GetUserDepartments();
            Projects = Client.GetUserProjects();
        }

        #endregion

        #region Методы клиента

        public void DbModelCallback(object result)
        {
            throw new NotImplementedException();
        }

        #endregion

        public MainViewModel()
        {
            ViewLoaded += OnViewLoaded;
            Client = SingletonClient.GetInstance(this).Client;          
        }
    }
}
