using System.Threading.Tasks;

namespace QueryObjectPattern
{
    public class PostDetailQueryHandler : IPostDetailQueryHandler
    {
        protected object DbContext;

        public PostDetailQueryHandler(object dbContext)
        {
            this.DbContext = dbContext;
        }
        
        public async Task<Post> Execute(PostDetailQuery query)
        {
            // Implementation of query:
            // DbContext.Posts.FirstOrDefault(x => x.Id == query.Id)
            
            // Other example:
            // DbContext.Posts.Where(x => x.Created <= query.Created)

            return new Post();
        }
    }
}