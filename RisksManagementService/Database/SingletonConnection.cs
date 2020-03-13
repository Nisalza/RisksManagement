using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO.Pipes;
using System.Linq;
using System.Web;

namespace RisksManagementService.Database
{
    public class SingletonConnection
    {
        private static SingletonConnection _instance;

        public bool IsOpen { get; private set; }

        public SqlConnection Connection { get; private set; }

        public static SingletonConnection GetInstance()
        {
            return _instance ?? (_instance = new SingletonConnection());
        }

        private SingletonConnection()
        {
            string cnString = ConfigurationManager.ConnectionStrings["RisksManagementDatabase"].ConnectionString;
            Connection = new SqlConnection(cnString);
            IsOpen = false;
            OpenConnection();
        }

        public void OpenConnection()
        {
            if (!IsOpen)
            {
                Connection.Open();
                IsOpen = true;
            }
        }

        public void CloseConnection()
        {
            if (IsOpen)
            {
                Connection.Close();
                IsOpen = false;
            }
        }
    }
}