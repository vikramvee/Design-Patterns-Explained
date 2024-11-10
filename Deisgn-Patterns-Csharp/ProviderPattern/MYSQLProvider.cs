using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderPattern
{
    public class MySQLProvider : IDatabaseProvider
    {
        public void Connect()
        {
            Console.WriteLine("Connecting to MySQL database...");
        }

        public void ExecuteQuery(string query)
        {
            Console.WriteLine($"Executing query on MySQL: {query}");
        }
    }
}
