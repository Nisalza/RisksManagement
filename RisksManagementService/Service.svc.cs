using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RisksManagementService.Database;
using RisksManagementService.Database.Models;
using RisksManagementService.Database.SqlGenerators.ForModels;

namespace RisksManagementService
{
    public class Service : IService
    {
        public AppUser CurrentUser { get; private set; }

        //todo вызывать при загрузке клиента
        public void Connect(string login)
        {
            SqlForAppUser sqlForAppUser = new SqlForAppUser();
            CurrentUser = sqlForAppUser.SelectAllByLogin(login);
            CurrentUser.OperationContext = OperationContext.Current;

            string cnString = ConfigurationManager.ConnectionStrings["RisksManagementDatabase"].ConnectionString;
            SingletonConnection connection = SingletonConnection.GetInstance();
            connection.OpenConnection();

            //CurrentUser.OperationContext.GetCallbackChannel<IServerCallback>().AppUserCallback(CurrentUser);
        }

        //todo вызывать при закрытии клиента
        public void Disconnect()
        {
            var connection = SingletonConnection.GetInstance();
            connection.CloseConnection();
        }
    }
}
