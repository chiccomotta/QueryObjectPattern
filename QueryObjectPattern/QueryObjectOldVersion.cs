using System;
using System.Linq.Expressions;
using QueryObjectPattern.DAL;

namespace QueryObjectPattern
{
    public class QueryObjectOldVersion<T, TR> : QueryBase, IQueryObjectOldVersion<T, TR>
    {
        public QueryObjectOldVersion(StudioDBContext dbContext) : base(dbContext)
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