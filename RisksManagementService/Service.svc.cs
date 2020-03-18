using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;
using RisksManagementService.Database;
using RisksManagementService.Database.Models;
using RisksManagementService.Database.SqlGenerators.ForModels;

namespace RisksManagementService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service : IService
    {
        public AppUser CurrentUser { get; private set; }

        public AppUser Connect(string login)
        {
            SqlForAppUser sqlForAppUser = new SqlForAppUser();
            CurrentUser = sqlForAppUser.SelectByLogin(login);
            CurrentUser.OperationContext = OperationContext.Current;
            
            return CurrentUser;
        }

        #region Select

        public AppUser GetAppUser(int id)
        {
            SqlForAppUser sqlForAppUser = new SqlForAppUser();
            AppUser user = sqlForAppUser.SelectById(id);
            return user;
        }

        public Department[] GetUserDepartments()
        {
            if (CurrentUser == null) return null;
            SqlForUserDepartment sqlForUserDepartment = new SqlForUserDepartment();
            UserDepartment[] ud = sqlForUserDepartment.SelectAllByAppUser(CurrentUser);
            var result = ud.Select(x => x.Department);
            return result.ToArray();
        }

        public Project[] GetUserProjects()
        {
            if (CurrentUser == null) return null;
            SqlForUserProject sqlForUserProject = new SqlForUserProject();
            UserProject[] up = sqlForUserProject.SelectAllByAppUser(CurrentUser);
            var result = up.Select(x => x.Project);
            return result.ToArray();
        }

        public ProbabilityType[] GetProbabilityTypes()
        {
            SqlForProbabilityType sqlForProbabilityType = new SqlForProbabilityType();
            ProbabilityType[] result = sqlForProbabilityType.SelectAll();
            return result;
        }

        public Probability[] GetProbabilities()
        {
            SqlForProbability sqlForProbability = new SqlForProbability();
            Probability[] result = sqlForProbability.SelectAll();
            return result;
        }

        public ImpactType[] GetImpactTypes()
        {
            SqlForImpactType sqlForImpactType = new SqlForImpactType();
            ImpactType[] result = sqlForImpactType.SelectAll();
            return result;
        }

        public Impact[] GetImpacts()
        {
            SqlForImpact sqlForImpact = new SqlForImpact();
            Impact[] result = sqlForImpact.SelectAll();
            return result;
        }

        public Classification[] GetClassifications()
        {
            SqlForClassification sqlForClassification = new SqlForClassification();
            Classification[] result = sqlForClassification.SelectAll();
            return result;
        }

        public Strategy[] GetStrategies()
        {
            SqlForStrategy sqlForStrategy = new SqlForStrategy();
            Strategy[] result = sqlForStrategy.SelectAll();
            return result;
        }

        public Relevance[] GetRelevance()
        {
            SqlForRelevance sqlForRelevance = new SqlForRelevance();
            Relevance[] result = sqlForRelevance.SelectAll();
            return result;
        }

        public RiskCause[] GetCauses()
        {
            SqlForRiskCause sqlForRiskCause = new SqlForRiskCause();
            RiskCause[] result = sqlForRiskCause.SelectAll();
            return result;
        }

        public Priority[] GetPriorities()
        {
            SqlForPriority sqlForPriority = new SqlForPriority();
            Priority[] result = sqlForPriority.SelectAll();
            return result;
        }

        public Risk[] GetRisks()
        {
            SqlForUserDepartment sqlForUserDepartment = new SqlForUserDepartment();
            var departments = sqlForUserDepartment.SelectAllByAppUser(CurrentUser);

            var projects = new List<Project>();
            SqlForProject sqlForProject = new SqlForProject();
            foreach (UserDepartment department in departments)
            {
                var t = sqlForProject.SelectByDepartment(department.Department);
                projects.AddRange(t);
            }

            SqlForUserProject sqlForUserProject = new SqlForUserProject();
            projects.AddRange(sqlForUserProject.SelectAllByAppUser(CurrentUser).Select(x => x.Project));

            projects = projects.Distinct().ToList();

            var risks = new List<Risk>();
            SqlForRisk sqlForRisk = new SqlForRisk();
            foreach (Project project in projects)
            {
                var t = sqlForRisk.SelectByProject(project);
                risks.AddRange(t);
            }

            return risks.Distinct().ToArray();
        }

        public AppUser[] GetUsers()
        {
            SqlForAppUser sqlForAppUser = new SqlForAppUser();
            AppUser[] result = sqlForAppUser.SelectAll();
            return result;
        }

        public UserProject[] GetUsersWithProjects()
        {
            SqlForUserProject sqlForUserProject = new SqlForUserProject();
            var result = sqlForUserProject.SelectAll();
            return result;
        }

        #endregion

        #region Insert

        public bool InsertRisk(Risk risk)
        {
            SqlForRisk sqlForRisk = new SqlForRisk();
            bool ok = sqlForRisk.InsertRisk(risk, CurrentUser);
            return ok;
        }

        #endregion

        #region Update

        public bool UpdateUser(AppUser user)
        {
            if (CurrentUser == null) return false;
            CurrentUser.Phone = user.Phone;
            CurrentUser.Email = user.Email;
            CurrentUser.Telegram = user.Telegram;
            SqlForAppUser sqlForAppUser = new SqlForAppUser();
            bool result = sqlForAppUser.UpdateByUser(user);
            return result;
        }

        public bool UpdateRisk(Risk risk)
        {
            SqlForRisk sqlForRisk = new SqlForRisk();
            bool ok = sqlForRisk.UpdateRisk(risk, CurrentUser);
            return ok;
        }

        #endregion

        #region Delete

        public bool DeleteRisk(Risk risk)
        {
            SqlForRisk sqlForRisk = new SqlForRisk();
            bool ok = sqlForRisk.DeleteRisk(risk);
            return ok;
        }

        #endregion

        public void Disconnect()
        {
            var connection = SingletonConnection.GetInstance();
            connection.CloseConnection();
        }
    }
}
