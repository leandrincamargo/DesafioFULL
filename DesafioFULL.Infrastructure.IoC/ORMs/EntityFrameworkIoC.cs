using DesafioFULL.Infrastructure.DBConfiguration;
using DesafioFULL.Infrastructure.Interfaces.Repositories.Domain;
using DesafioFULL.Infrastructure.Interfaces.Repositories.Standard;
using DesafioFULL.Infrastructure.Repositories;
using DesafioFULL.Infrastructure.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioFULL.Infrastructure.IoC.ORMs
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration = null)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDebtRepository, DebtRepository>();
            services.AddScoped<IInstallmentRepository, InstallmentRepository>();

            return services;
        }
    }
}
