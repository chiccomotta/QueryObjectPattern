using System.Linq;

namespace QueryObjectPattern.QueryObjects.Infrastructure
{
    public interface IQueryObject<out T, out TResult>
    {
        IQueryable<T> Query();
        TResult Execute();
    }
}