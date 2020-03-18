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
using RisksManagementClient.Strategies.RiskStrategies;
using RisksManagementClient.Strategies.StrategyStrategies;

namespace RisksManagementClient.ViewModels
{
    public class MainViewModel : BindableBase, IServiceCallback
    {
        public MainViewModel()
        {
            ViewLoaded += OnViewLoaded;
            UserSaving += OnUserSaving;
            RiskSaving += OnRiskSaving;
            StrategySaving += OnStrategySaving;
            Client = SingletonClient.GetInstance(this).Client;
            RiskContext = new RiskContext();
            StrategyContext = new StrategyContext();
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

        private StrategyType[] _strategyTypes;

        private Strategy[] _strategies;

        private Strategy[] _mitigationStrategies;

        private Strategy[] _contingencyStrategies;

        private Relevance[] _relevances;

        private RiskCause[] _riskCauses;

        private Priority[] _priorities;

        private Risk[] _risks;

        private UserProject[] _userProjects;

        private AppUser[] _responsiblePersons;

        public IContext RiskContext;

        public IContext StrategyContext;

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

        public StrategyType[] StrategyTypes
        {
            get => _strategyTypes;
            set
            {
                _strategyTypes = value;
                RaisePropertyChanged();
            }
        }

        public Strategy[] MitigationStrategies
        {
            get => _mitigationStrategies;
            set
            {
                _mitigationStrategies = value;
                RaisePropertyChanged();
            }
        }

        public Strategy[] ContingencyStrategies
        {
            get => _contingencyStrategies;
            set
            {
                _contingencyStrategies = value;
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

        public EventHandler RiskSaving;

        public EventHandler StrategySaving;

        #endregion

        #region Методы событий

        private void OnViewLoaded(object sender, EventArgs e)
        {
            GetCurrentUser();
            GetDepartments();
            GetProjects();
            GetProbabilityTypes();
            GetProbabilities();
            GetImpactTypes();
            GetImpacts();
            GetClassifications();
            GetStrategyTypes();
            GetStrategies();
            GetRelevance();
            GetCauses();
            GetPriorities();
            GetRisks();
            GetUsersWithProjects();
        }

        private void OnUserSaving(object sender, EventArgs e)
        {
            bool ok = Client.UpdateUser(CurrentUser);
        }
        
        private void OnRiskSaving(object sender, EventArgs e)
        {
            RiskContext.ExecuteStrategy(CurrentRisk);
            GetRisks();
        }

        private void OnStrategySaving(object sender, EventArgs e)
        {
            StrategyContext.ExecuteStrategy(sender);
            GetStrategies();
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

        #region Загрузка данных с сервера

        private void GetUsersWithProjects()
        {
            _userProjects = Client.GetUsersWithProjects();
        }

        private void GetRisks()
        {
            Risks = Client.GetRisks();
        }

        private void GetPriorities()
        {
            Priorities = Client.GetPriorities();
        }

        private void GetCauses()
        {
            RiskCauses = Client.GetCauses();
        }

        private void GetRelevance()
        {
            Relevances = Client.GetRelevance();
        }

        private void GetStrategies()
        {
            _strategies = Client.GetStrategies();
            //todo Перенести константы в конфиги
            MitigationStrategies = _strategies.Where(x => x.StrategyType.Id == 1).ToArray();
            ContingencyStrategies = _strategies.Where(x => x.StrategyType.Id == 2).ToArray();
        }

        private void GetStrategyTypes()
        {
            StrategyTypes = Client.GetStrategyTypes();
        }

        private void GetClassifications()
        {
            Classifications = Client.GetClassifications();
        }

        private void GetImpacts()
        {
            _impacts = Client.GetImpacts();
        }

        private void GetImpactTypes()
        {
            ImpactTypes = Client.GetImpactTypes();
        }

        private void GetProbabilities()
        {
            _probabilities = Client.GetProbabilities();
        }

        private void GetProbabilityTypes()
        {
            ProbabilityTypes = Client.GetProbabilityTypes();
        }

        private void GetProjects()
        {
            Projects = Client.GetUserProjects();
        }

        private void GetDepartments()
        {
            Departments = Client.GetUserDepartments();
        }

        private void GetCurrentUser()
        {
            //todo Убрать дефолтный логин
            CurrentUser = Client.Connect(@"ALZA/Dashi");
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
