using QueryObjectPattern.DAL;

namespace QueryObjectPattern.QueryObjects.Infrastructure
{
    public abstract class QueryBase
    {
        protected readonly StudioDBContext DbContext;

        protected QueryBase(StudioDBContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}