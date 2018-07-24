using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using QueryObjectPattern.DAL;

namespace QueryObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Query Object
            var query = new PostDetailQuery(123, null);

            DbContextOptions<StudioDBContext> options = new DbContextOptions<StudioDBContext>();

            // DbContext (in verità arriva dal container DI)
            DbContext dbContext = new StudioDBContext(options);

            // Execute Query
            var result = new PostDetailQueryHandler(dbContext).Execute(query);

            // Post object
            Debug.Write(result);
            Console.ReadKey();
        }
    }
}
