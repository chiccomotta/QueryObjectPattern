using System;
using System.Linq;

namespace QueryObjectPattern
{
    public interface IQueryObject<out T, out TResult>
    {
        IQueryable<T> Query();
        TResult Execute();
    }
}