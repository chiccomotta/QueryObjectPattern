using System;
using System.Diagnostics;

namespace QueryObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Query Object
            var query = new PostDetailQuery(123, null);

            // DbContext (in verità arriva dal container DI)
            var DbContext = new object();

            // Execute Query
            var result = new PostDetailQueryHandler(DbContext).Execute(query);

            // Post object
            Debug.Write(result);
            Console.ReadKey();
        }
    }
}
