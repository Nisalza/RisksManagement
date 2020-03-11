﻿using System;
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
        //todo убрать дефолтный логин
        public void Connect(string login = "Alza Nis")
        {
            //todo получить инфу о пользователе из БД
            CurrentUser.OperationContext = OperationContext.Current;
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
