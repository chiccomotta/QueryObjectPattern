using QueryObjectPattern.DAL;
using QueryObjectPattern.QueryObjects.Infrastructure;
using System.Collections.Generic;
using System.Linq;

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