using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderPattern
{
    public static class AutoRegister
    {
        public static void AutoRegisterProviders()
        {
            var providerType = typeof(IDatabaseProvider);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                           .SelectMany(s => s.GetTypes())
                           .Where(p => providerType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

            foreach (var type in types)
            {
                ProviderRegistry.RegisterProvider(type.Name, type);
            }
        }

    }
}
