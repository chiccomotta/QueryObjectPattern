using QueryObjectPattern.DAL;
using QueryObjectPattern.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QueryObjectPattern
{
    public class PostDetailQuery
    {
        public int? Id { get; set; }
        public DateTime? Created { get; set; }

        public PostDetailQuery(int? id, DateTime? created)
        {
            this.Id = id;
            this.Created = created;
        }    
    }

    // Esempio 1 (con QueryBase e interfaccia)
    public class CustomerByStatusAndIdQuery : QueryBase, IQueryObjectOldVersion<Customers, Customers>
    {
        public int Id { get; set; }
        public int Status { get; set; }

        public CustomerByStatusAndIdQuery(StudioDBContext dbContext) : base(dbContext)
        {
        }

        public Expression<Func<Customers, bool>> Query()
        {
            return (x =>  x.Id == Id && x.Status == 1);
        }
        
        // Esempio con un predicato Func<T1, T2, TResult>
        public Expression<Func<Post, Blog , bool>> QueryPostAndBlog()
        {
            return (post, blog) => post.Title == "Titolo" && blog.Name == "Ciccio";
        }

        public Customers Execute()
        {
             return DbContext.Customers.Where(Query()).SingleOrDefault();
        }
    }    



    // Esempio 2 (con classe concreta)
    public class MultiplePostsQuery : QueryObjectOldVersion<Customers, IEnumerable<Customers>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public MultiplePostsQuery(StudioDBContext dbContext) : base(dbContext)
        {
        }

        public override Expression<Func<Customers, bool>> Query()
        {
            return (x =>  x.Id == Id && x.Status == 1);
        }

        public override IEnumerable<Customers> Execute()
        {
            return DbContext.Customers.Where(Query()).ToList();
        }        
    }

    // Esempio 3 - Classe che eredita da QueryBase per il costruttore e implementa
    // l'interfaccia IQueryObject
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

    // Esempio 4 - stesso caso dell'esempio 3 ma la query ritorna una lista di Dto
    public class CustomersInDateDtoQueryObject : QueryBase, IQueryObject<Customers, List<CustomersDto>>
    {
        public int Id { get; set; }
        public int Status { get; set; }

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
                    FullName = c.Nome + " " + c.Cognome,
                    Matricola = c.Matricola.Value,
                    Password = DateTime.Now.ToString()
                })
                .ToList();
        }

        public IQueryable<Customers> Query()
        {
            var query = DbContext.Customers
                .AddFilterIfValue(StartDate, c => c.SignUpDate >= StartDate)
                .AddFilterIfValue(EndDate, c => c.SignUpDate < EndDate);

            return query;
        }
    }

}
