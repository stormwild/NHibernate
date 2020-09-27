using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernateDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NHibernateSampleDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
                //x.LogSqlInConsole = true;
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var sessionFactory = cfg.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var txn = session.BeginTransaction())
            {
                //var customers = session.CreateCriteria<Customer>().List<Customer>();
                var customers = session.Query<Customer>().OrderBy(c => c.LastName).ToList();

                Console.WriteLine("--------------------------\n");

                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.FirstName} {customer.LastName}");
                }

                txn.Commit();

                Console.WriteLine("\n--------------------------\n");
            }

            Console.ReadLine();
        }
    }
}
