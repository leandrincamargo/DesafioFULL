using DesafioFULL.Application.Interfaces.Services;
using DesafioFULL.Application.Interfaces.Services.Standard;
using DesafioFULL.Application.Services;
using DesafioFULL.Application.Services.Standard;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioFULL.Application.IoC.Services
{
    public static class ServicesIoC
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped<IDebtService, DebtService>();
            services.AddScoped<IInstallmentService, InstallmentService>();
        }
    }
}
