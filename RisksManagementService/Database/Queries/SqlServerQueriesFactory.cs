using System;
using RisksManagementService.Database.Queries.Statements;

namespace RisksManagementService.Database.Queries
{
    public class SqlServerQueriesFactory : IQueryFactory
    {
        public IQuery Select()
        {
            return new SelectStatement();
        }

        public IQuery Update()
        {
            return new UpdateStatement();
        }

        public IQuery Insert()
        {
            return new InsertStatement();
        }

        public IQuery Delete()
        {
            return new DeleteStatement();
        }

        //todo CreateStatement
        public IQuery Create()
        {
            throw new NotImplementedException();
        }

        //todo AlterStatement
        public IQuery Alter()
        {
            throw new NotImplementedException();
        }

        //todo DropStatement
        public IQuery Drop()
        {
            throw new NotImplementedException();
        }
    }
}