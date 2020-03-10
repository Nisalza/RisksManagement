using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlServerQueriesBuilder.DeleteStatement;

namespace RisksManagementService.Database.Queries
{
    public class DeleteStatement : IQuery
    {
        public IDeleteBuilder DeleteBuilder { get; set; }

        public DeleteStatement()
        {
            DeleteBuilder = new DeleteBuilder();
        }

        public string GetRequest()
        {
            return DeleteBuilder.BuildRequest();
        }
    }
}