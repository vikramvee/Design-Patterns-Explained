using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderPattern
{
    public interface IDatabaseProvider
    {
        void Connect();
        void ExecuteQuery(string query);
    }
}
