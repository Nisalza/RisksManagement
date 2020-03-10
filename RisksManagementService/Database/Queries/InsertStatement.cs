using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlServerQueriesBuilder.InsertStatement;

namespace RisksManagementService.Database.Queries
{
    public class InsertStatement : IQuery
    {
        public InsertBuilder InsertBuilder { get; set; }

        public InsertStatement()
        {
            InsertBuilder = new InsertBuilder();
        }

        public string GetRequest()
        {
            return InsertBuilder.BuildRequest();
        }
    }
}