using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Register providers (this can be automated with reflection)
            ProviderRegistry.RegisterProvider("MySQL", typeof(MySQLProvider));
            ProviderRegistry.RegisterProvider("PostgreSQL", typeof(PostgreSQLProvider));


            //Use below methos to auto discover and register the providers
            //AutoRegister.AutoRegisterProviders();

            // Retrieve and use a provider
            IDatabaseProvider provider = ProviderRegistry.GetProvider("MySQL");
            provider.Connect();
            provider.ExecuteQuery("SELECT * FROM Users");

            Console.ReadLine();
        }
    }
}
