using DesafioFULL.Infrastructure.DBConfiguration;
using Microsoft.Extensions.Configuration;

namespace DesafioFULL.Infrastructure.IoC
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? DatabaseConnection.ConnectionConfiguration;
        }
    }
}
