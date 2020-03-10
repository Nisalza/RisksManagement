using SqlServerQueriesBuilder.SelectStatement;

namespace RisksManagementService.Database.Queries
{
    public class SelectStatement : IQuery
    {
        public ISelectBuilder SelectBuilder { get; set; }

        public SelectStatement()
        {
            SelectBuilder = new SelectBuilder();
        }
        
        public string GetRequest()
        {
            return SelectBuilder.BuildRequest();
        }
    }
}