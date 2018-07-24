using System.Threading.Tasks;

namespace QueryObjectPattern
{
    public interface IPostDetailQueryHandler
    {
        Task<Post> Execute(PostDetailQuery query);
    }
}
