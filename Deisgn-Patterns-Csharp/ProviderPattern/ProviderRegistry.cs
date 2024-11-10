using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderPattern
{
    public static class ProviderRegistry
    {
        private static readonly Dictionary<string, Type> _providers = new Dictionary<string, Type>();

        // Register a new provider type with a unique key
        public static void RegisterProvider(string providerName, Type providerType)
        {
            if (!typeof(IDatabaseProvider).IsAssignableFrom(providerType))
            {
                throw new ArgumentException("Type must implement IDatabaseProvider");
            }
            _providers[providerName] = providerType;
        }

        // Get an instance of a registered provider
        public static IDatabaseProvider GetProvider(string providerName)
        {
            if (_providers.TryGetValue(providerName, out Type providerType))
            {
                return (IDatabaseProvider)Activator.CreateInstance(providerType);
            }
            throw new ArgumentException("Provider not found");
        }
    }

}
