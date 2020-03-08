using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RisksManagementService.Database.Models;

namespace RisksManagementService
{
    public class Service : IService
    {
        public AppUser CurrentUser { get; private set; }

        //todo вызывать при загрузке клиента
        public void Connect(string login)
        {
            //todo получить инфу о пользователе из БД
            string cnString = ConfigurationManager.ConnectionStrings["RisksManagementDatabase"].ConnectionString;
            CurrentUser.Connection = new SqlConnection(cnString);
            CurrentUser.Connection.Open();
        }

        //todo вызывать при закрытии клиента
        public void Disconnect()
        {
            CurrentUser.Connection.Close();
        }
    }
}
