using System;
using System.Linq.Expressions;

namespace QueryObjectPattern
{
    public interface IQueryObject<T, out TR>
    {
        Expression<Func<T, bool>> Query();
        TR Execute();
    }
}