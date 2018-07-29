using QueryObjectPattern.DAL;

namespace QueryObjectPattern.QueryObjects.Infrastructure
{
    public class QueryBase
    {
        protected readonly StudioDBContext DbContext;
        public QueryBase(StudioDBContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}