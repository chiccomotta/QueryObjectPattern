using QueryObjectPattern.DAL;
using System;
using QueryObjectPattern.QueryObjects;

namespace QueryObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            TestQueryInStatus();
            TestQueryDto();
            TestQuery();
            //AddBook();

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
                Console.WriteLine($"{customer.Nome}  {customer.Cognome}");
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
                    Status = 2,
                    StartDate = DateTime.Parse("2017-10-09"),
                    EndDate = null
                };

            var result = queryObj.Execute();
            foreach (var customer in result)
            {
                Console.WriteLine($"FullName:  {customer.FullName}");
                Console.WriteLine($"Matricola: {customer.Matricola}");
                Console.WriteLine($"Password: {customer.Password}");
                Console.WriteLine("-------------------------------------");
            }

            Console.ReadKey();
        }
        public static void TestQueryInStatus()
        {
            // DbContext (in verità arriva dal container DI)
            var dbContext = new StudioDBContext();

            // Creo una query 
            CustomersInStatusQueryObject queryObj =
                new CustomersInStatusQueryObject(dbContext)
                {
                    Status = new[] {3,4}
                };

            var result = queryObj.Execute();
            foreach (var customer in result)
            {
                Console.WriteLine($"Nome: {customer.Nome}");
                Console.WriteLine($"Status: {customer.Status}");
                Console.WriteLine("-------------------------------------");
            }

            Console.ReadKey();
        }
    }
}
