using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QueryObjectPattern
{
    // Handler che gestisce l'esecuzione della query tramite l'implementazione dell'interfaccia Execute
    public class PostDetailQueryHandler : IPostDetailQueryHandler
    {
        protected DbContext DbContext;

        // Il DbContext viene iniettato dal container DI
        public PostDetailQueryHandler(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        
        // Questa è l'implementazione vera della query
        public async Task<Post> Execute(PostDetailQuery query)
        {
            // Implementation of query:
            // DbContext.Posts.FirstOrDefault(x => x.Id == query.Id)
            
            // Other example:
            // DbContext.Posts.Where(x => x.Created <= query.Created)

            return await Task.Run(() => new Post());
        }
    }
}