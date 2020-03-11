using SqlServerQueriesBuilder.DeleteStatement;

namespace RisksManagementService.Database.Queries.Statements
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