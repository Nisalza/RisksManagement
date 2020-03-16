﻿using System;
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

        public RiskManagementPlan[] GetManagementPlans()
        {
            SqlForRisksManagementPlan sqlForRisksManagementPlan = new SqlForRisksManagementPlan();
            RiskManagementPlan[] result = sqlForRisksManagementPlan.SelectAll();
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

        public Risk[] GetRisks()
        {
            //todo Переделать
            return new Risk[0];
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

        #endregion

        public void Disconnect()
        {
            var connection = SingletonConnection.GetInstance();
            connection.CloseConnection();
        }
    }
}
