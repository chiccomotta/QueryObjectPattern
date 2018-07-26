using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using QueryObjectPattern.DAL;

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
    public class CustomerByStatusAndIdQuery : QueryBase, IQueryObject<Customers, Customers>
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

        public Customers Execute()
        {
             return DbContext.Customers.Where(Query()).SingleOrDefault();
        }        
    }    

    // Esempio 2 (con classe concreta)
    public class MultiplePostsQuery : QueryObject<Customers, IEnumerable<Customers>>
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
}
