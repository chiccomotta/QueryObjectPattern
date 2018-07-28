using System;
using System.Linq;

namespace QueryObjectPattern
{
    public interface IQueryObjectQueryable<out T, out TResult>
    {
        IQueryable<T> Query();
        TResult Execute();
    }
}