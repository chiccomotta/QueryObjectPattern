using System;
using System.Linq.Expressions;
using QueryObjectPattern.DAL;

namespace QueryObjectPattern
{
    public class QueryObject<T, TR> : QueryBase, IQueryObject<T, TR>
    {
        public QueryObject(StudioDBContext dbContext) : base(dbContext)
        {            
        }

        public virtual TR Execute()
        {
            throw new NotImplementedException();
        }

        public virtual Expression<Func<T, bool>> Query()
        {
            throw new NotImplementedException();
        }
    }
}