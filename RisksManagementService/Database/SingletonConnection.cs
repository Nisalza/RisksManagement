using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO.Pipes;
using System.Linq;
using System.Web;

namespace RisksManagementService.Database
{
    //todo удалить потом, если не понадобится
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
        }

        public void OpenConnection()
        {
            Connection.Open();
            IsOpen = true;
        }

        public void CloseConnection()
        {
            Connection.Close();
            IsOpen = false;
        }
    }
}