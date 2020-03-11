using SqlServerQueriesBuilder.UpdateStatement;

namespace RisksManagementService.Database.Queries.Statements
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