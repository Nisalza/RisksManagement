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
            SingletonConnection connection = SingletonConnection.GetInstance();
            SqlForAppUser sqlForAppUser = new SqlForAppUser();
            CurrentUser = sqlForAppUser.SelectAllByLogin(login);
            CurrentUser.OperationContext = OperationContext.Current;
            
            return CurrentUser;
        }

        //todo вызывать при закрытии клиента
        public void Disconnect()
        {
            var connection = SingletonConnection.GetInstance();
            connection.CloseConnection();
        }
    }
}
