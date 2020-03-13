using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Database.Queries;

namespace RisksManagementService.Database.SqlGenerators
{
    public abstract class SqlForModel
    {
        protected readonly IQueryFactory QueryFactory;

        protected SqlForModel()
        {
            QueryFactory = new SqlServerQueriesFactory();
        }
    }
}