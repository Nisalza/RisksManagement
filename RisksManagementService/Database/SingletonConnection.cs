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

        private bool _isOpen;

        public SqlConnection Connection { get; private set; }

        public static SingletonConnection GetInstance()
        {
            return _instance ?? (_instance = new SingletonConnection());
        }

        private SingletonConnection()
        {
            string cnString = ConfigurationManager.ConnectionStrings["RisksManagementDatabase"].ConnectionString;
            Connection = new SqlConnection(cnString);
            _isOpen = false;
            OpenConnection();
        }

        public void OpenConnection()
        {
            if (!_isOpen)
            {
                Connection.Open();
                _isOpen = true;
            }
        }

        public void CloseConnection()
        {
            if (_isOpen)
            {
                Connection.Close();
                _isOpen = false;
            }
        }
    }
}