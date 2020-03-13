using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SqlServerQueriesBuilder.General;

namespace RisksManagementService.Database.SqlGenerators
{
    public class SqlExecutor
    {
        public SqlDataReader ExecuteReader(string commandText)
        {
            SingletonConnection connection = SingletonConnection.GetInstance();
            SqlCommand command = new SqlCommand(commandText, connection.Connection);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}