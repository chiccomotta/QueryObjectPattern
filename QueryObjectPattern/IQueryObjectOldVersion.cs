using System;
using System.Linq.Expressions;

namespace QueryObjectPattern
{
    public interface IQueryObjectOldVersion<T, out TR>
    {
        Expression<Func<T, bool>> Query();
        TR Execute();
    }
}