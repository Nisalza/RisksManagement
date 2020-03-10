using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlServerQueriesBuilder.UpdateStatement;

namespace RisksManagementService.Database.Queries
{
    public class UpdateStatement : IQuery
    {
        public IUpdateBuilder UpdateBuilder { get; set; }

        public UpdateStatement()
        {
            UpdateBuilder = new UpdateBuilder();
        }

        public string GetRequest()
        {
            return UpdateBuilder.BuildRequest();
        }
    }
}