using System;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using Parus.Data.Abstractions;
using Parus.Data.Core;
using Parus.Data.Oracle;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // register dependencies
            var services = new ServiceCollection();
            services.AddDataAccess(options => options.UseOracle("User Id=PARUS;Password=PASSWORD;Data Source=127.0.0.1:1521/ORCL"));
            var serviceProvider = services.BuildServiceProvider();

            // loading companies
            using var connection = serviceProvider.GetRequiredService<IConnection>().ConnectionFactory.CreateConnection();
            connection.Open();
            
            var result = connection.Query<string>("select name from companies");

            Console.WriteLine("Companies:");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
