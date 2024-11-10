using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderPattern
{
    public class PostgreSQLProvider : IDatabaseProvider
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to PostgreSQL database...");
        }

        public void ExecuteQuery(string query)
        {
            Console.WriteLine($"Executing query on PostgreSQL: {query}");
        }
    }
}
