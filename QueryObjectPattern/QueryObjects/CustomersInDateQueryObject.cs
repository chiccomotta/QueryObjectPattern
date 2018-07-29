using System;
using System.Collections.Generic;
using System.Linq;
using QueryObjectPattern.DAL;
using QueryObjectPattern.QueryableExtensions;
using QueryObjectPattern.QueryObjects.Infrastructure;

namespace QueryObjectPattern.QueryObjects
{
    // Esempio 1 - Classe che eredita da QueryBase per il costruttore e implementa l'interfaccia IQueryObject
    public class CustomersInDateQueryObject : QueryBase, IQueryObject<Customers, List<Customers>>
    {
        public int Id { get; set; }
        public int Status { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public CustomersInDateQueryObject(StudioDBContext dbContext) : base(dbContext)
        {
        }

        public List<Customers> Execute()
        {
            return Query().ToList();
        }

        public IQueryable<Customers> Query()
        {
            var query = DbContext.Customers
                .AddFilterIfValue(StartDate, c =>  c.SignUpDate >= StartDate)
                .AddFilterIfValue(EndDate, c => c.SignUpDate < EndDate);

            return query;
        }
    }
}
