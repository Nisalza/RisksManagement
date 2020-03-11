using SqlServerQueriesBuilder.InsertStatement;

namespace RisksManagementService.Database.Queries.Statements
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