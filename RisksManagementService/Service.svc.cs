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

        public void Disconnect()
        {
            var connection = SingletonConnection.GetInstance();
            connection.CloseConnection();
        }
    }
}
