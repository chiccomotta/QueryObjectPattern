using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using QueryObjectPattern.DAL;

namespace QueryObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            TestQueryDto();
            TestQuery();

            // DbContext (in verità arriva dal container DI)
            var dbContext = new StudioDBContext();

            //AddBook();
            //return;

            // Query Object
            var query = new PostDetailQuery(123, null);
;
            // Execute Query
            var result = new PostDetailQueryHandler(dbContext).Execute(query);

            // Post object
            Debug.Write(result);

            // ****
            // Creo un oggetto QueryObjectOldVersion
            CustomerByStatusAndIdQuery queryObj =
                new CustomerByStatusAndIdQuery(dbContext)
                {
                    Status = 1,
                    Id = 1
                };

            var result2 = queryObj.Execute();
            Console.WriteLine(result2.Nome);
            Console.WriteLine(result2.Cognome);

            Console.ReadKey();
        }

        public static void AddBook()
        {
            var book = new Book<Spices>
            {
                Spice = new Spices()
                {
                    SpiceMixName = "Zuppa di ceci",
                    Supplier = "Boh"
                }
            };

            var context = new StudioDBContext();
            context.Books.Add(book);
            context.SaveChanges();
        }

        public static void TestQuery()
        {
            // DbContext (in verità arriva dal container DI)
            var dbContext = new StudioDBContext();

            // Creo un oggetto QueryObjectQueryable
            CustomersInDateQueryObject queryObj =
                new CustomersInDateQueryObject(dbContext)
                {
                    StartDate = DateTime.Parse("2017-12-31"),
                    EndDate = DateTime.Parse("2018-01-01")
                };

            var result = queryObj.Execute();
            foreach (var customer in result)
            {
                Console.WriteLine(customer.Nome + " " + customer.Cognome );
            }

            Console.ReadKey();
        }

        public static void TestQueryDto()
        {
            // DbContext (in verità arriva dal container DI)
            var dbContext = new StudioDBContext();

            // Creo una query 
            CustomersInDateDtoQueryObject queryObj =
                new CustomersInDateDtoQueryObject (dbContext)
                {
                    StartDate = DateTime.Parse("2017-12-31"),
                    EndDate = null
                };

            var result = queryObj.Execute();
            foreach (var customer in result)
            {
                Console.WriteLine(customer.FullName);
                Console.WriteLine(customer.Matricola);
                Console.WriteLine(customer.Password);
                Console.WriteLine("-------------------------------------");
            }

            Console.ReadKey();
        }
    }
}
