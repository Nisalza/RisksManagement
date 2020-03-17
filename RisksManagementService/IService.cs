using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RisksManagementService.Database.Models;

namespace RisksManagementService
{
    [ServiceContract(CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        #region Select

        [OperationContract]
        AppUser Connect(string login);

        [OperationContract]
        AppUser GetAppUser(int id);

        [OperationContract]
        Department[] GetUserDepartments();

        [OperationContract]
        Project[] GetUserProjects();

        [OperationContract]
        ProbabilityType[] GetProbabilityTypes();

        [OperationContract]
        Probability[] GetProbabilities();

        [OperationContract]
        ImpactType[] GetImpactTypes();

        [OperationContract]
        Impact[] GetImpacts();

        [OperationContract]
        Classification[] GetClassifications();

        [OperationContract]
        RiskManagementPlan[] GetManagementPlans();

        [OperationContract]
        Relevance[] GetRelevance();

        [OperationContract]
        RiskCause[] GetCauses();

        [OperationContract]
        Priority[] GetPriorities();

        [OperationContract]
        Risk[] GetRisks();

        [OperationContract]
        AppUser[] GetUsers();

        [OperationContract]
        UserProject[] GetUsersWithProjects();

        #endregion

        #region Insert

        [OperationContract]
        bool InsertRisk(Risk risk);

        #endregion

        #region Update

        [OperationContract]
        bool UpdateUser(AppUser user);

        [OperationContract]
        bool UpdateRisk(Risk risk);

        #endregion

        #region Delete

        [OperationContract]
        bool DeleteRisk(Risk risk);

        #endregion

        [OperationContract]
        void Disconnect();
    }
}
