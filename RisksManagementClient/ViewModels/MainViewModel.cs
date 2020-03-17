using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using RisksManagementClient.ServiceRisksManagement;
using RisksManagementClient.Strategies;

namespace RisksManagementClient.ViewModels
{
    public class MainViewModel : BindableBase, IServiceCallback
    {
        public MainViewModel()
        {
            ViewLoaded += OnViewLoaded;
            UserSaving += OnUserSaving;
            Client = SingletonClient.GetInstance(this).Client;
        }

        #region Поля

        public ServiceClient Client;

        private AppUser _currentUser;

        private Department[] _departments;

        private Project[] _projects;

        private Risk _currentRisk;

        private ProbabilityType[] _probabilityTypes;

        private Probability[] _probabilities;

        private Probability[] _selectedProbabilities;

        private ImpactType[] _impactTypes;

        private Impact[] _impacts;

        private Impact[] _selectedImpacts;

        private Classification[] _classifications;

        private RiskManagementPlan[] _managementPlans;

        private Relevance[] _relevances;

        private RiskCause[] _riskCauses;

        private Priority[] _priorities;

        private Risk[] _risks;

        private UserProject[] _userProjects;

        private AppUser[] _responsiblePersons;

        private IStrategy _currentStrategy;
        
        #endregion

        #region Свойства

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

        public Risk CurrentRisk
        {
            get => _currentRisk;
            set
            {
                _currentRisk = value;
                RaisePropertyChanged();
            }
        }

        public ProbabilityType[] ProbabilityTypes
        {
            get => _probabilityTypes;
            set
            {
                _probabilityTypes = value;
                RaisePropertyChanged();
            }
        }

        public Probability[] Probabilities
        {
            get => _selectedProbabilities;
            set
            {
                _selectedProbabilities = value;
                RaisePropertyChanged();
            }
        }

        public ImpactType[] ImpactTypes
        {
            get => _impactTypes;
            set
            {
                _impactTypes = value;
                RaisePropertyChanged();
            }
        }

        public Impact[] Impacts
        {
            get => _selectedImpacts;
            set
            {
                _selectedImpacts = value;
                RaisePropertyChanged();
            }
        }

        public Classification[] Classifications
        {
            get => _classifications;
            set
            {
                _classifications = value;
                RaisePropertyChanged();
            }
        }

        public RiskManagementPlan[] ManagementPlans
        {
            get => _managementPlans;
            set
            {
                _managementPlans = value;
                RaisePropertyChanged();
            }
        }

        public Relevance[] Relevances
        {
            get => _relevances;
            set
            {
                _relevances = value;
                RaisePropertyChanged();
            }
        }

        public RiskCause[] RiskCauses
        {
            get => _riskCauses;
            set
            {
                _riskCauses = value;
                RaisePropertyChanged();
            }
        }

        public Priority[] Priorities
        {
            get => _priorities;
            set
            {
                _priorities = value;
                RaisePropertyChanged();
            }
        }

        public Risk[] Risks
        {
            get => _risks;
            set
            {
                _risks = value;
                RaisePropertyChanged();
            }
        }

        public AppUser[] ResponsiblePersons
        {
            get => _responsiblePersons;
            set
            {
                _responsiblePersons = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region События

        public EventHandler ViewLoaded;

        public EventHandler UserSaving;

        #endregion

        #region Методы событий

        private void OnViewLoaded(object sender, EventArgs e)
        {
            //todo Убрать дефолтный логин
            CurrentUser = Client.Connect(@"ALZA/Dashi");
            Departments = Client.GetUserDepartments();
            Projects = Client.GetUserProjects();
            ProbabilityTypes = Client.GetProbabilityTypes();
            _probabilities = Client.GetProbabilities();
            ImpactTypes = Client.GetImpactTypes();
            _impacts = Client.GetImpacts();
            Classifications = Client.GetClassifications();
            ManagementPlans = Client.GetManagementPlans();
            Relevances = Client.GetRelevance();
            RiskCauses = Client.GetCauses();
            Priorities = Client.GetPriorities();
            Risks = Client.GetRisks();
            _userProjects = Client.GetUsersWithProjects();
        }
        
        private void OnUserSaving(object sender, EventArgs e)
        {
            bool ok = Client.UpdateUser(CurrentUser);
        }

        #endregion

        #region Фильтрация свойств

        public void UpdateProbabilities()
        {
            Probabilities = _probabilities?.Where(x => x.ProbabilityType.Id == CurrentRisk.ProbabilityType?.Id)
                .ToArray();
        }

        public void UpdateImpacts()
        {
            Impacts = _impacts?.Where(x => x.ImpactType.Id == CurrentRisk.ImpactType?.Id)
                .ToArray();
        }

        public void UpdateRp()
        {
            ResponsiblePersons = _userProjects?.Where(x => x.Project.Id == CurrentRisk.Project?.Id)
                .Select(x => x.AppUser)
                .Distinct()
                .ToArray();
        }

        #endregion

        #region Методы клиента

        public void DbModelCallback(object result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
