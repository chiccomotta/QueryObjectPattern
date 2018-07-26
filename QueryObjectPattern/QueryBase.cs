using QueryObjectPattern.DAL;

namespace QueryObjectPattern
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