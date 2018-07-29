using System;
using System.Collections.Generic;
using System.Linq;
using QueryObjectPattern.DAL;
using QueryObjectPattern.Dto;
using QueryObjectPattern.QueryableExtensions;
using QueryObjectPattern.QueryObjects.Infrastructure;

namespace QueryObjectPattern.QueryObjects
{
    // Esempio 2 - Stesso caso dell'esempio 3 ma la query ritorna una lista di Dto
    public class CustomersInDateDtoQueryObject : QueryBase, IQueryObject<Customers, List<CustomersDto>>
    {
        public int Id { get; set; }
        public int? Status { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public CustomersInDateDtoQueryObject(StudioDBContext dbContext) : base(dbContext)
        {
        }

        public List<CustomersDto> Execute()
        {
            return Query()
                .Select(c => new CustomersDto()
                {
                    FullName = $"{c.Nome}  {c.Cognome}",
                    Matricola = c.Matricola.Value,
                    Password = new Random().Next().ToString()
                })
                .ToList();
        }

        public IQueryable<Customers> Query()
        {
            var query = DbContext.Customers
                .AddFilterIfValue(StartDate, c => c.SignUpDate >= StartDate)
                .AddFilterIfValue(EndDate, c => c.SignUpDate < EndDate)
                .AddFilterIfValue(Status, c => c.Status == Status);                

            return query;
        }
    }
}
