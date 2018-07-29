using System.Collections.Generic;
using System.Linq;
using QueryObjectPattern.DAL;
using QueryObjectPattern.QueryableExtensions;
using QueryObjectPattern.QueryObjects.Infrastructure;

namespace QueryObjectPattern.QueryObjects
{
    public class CustomersInStatusQueryObject : QueryBase, IQueryObject<Customers, List<Customers>>
    {
        public int[] Status { get; set; }

        public CustomersInStatusQueryObject(StudioDBContext dbContext) : base(dbContext)
        {
        }

        public List<Customers> Execute()
        {
            return Query().ToList();
        }

        public IQueryable<Customers> Query()
        {
            var query =
                DbContext.Customers.Where(c => Status.Contains(c.Status));

            return query;
        }
    }
}