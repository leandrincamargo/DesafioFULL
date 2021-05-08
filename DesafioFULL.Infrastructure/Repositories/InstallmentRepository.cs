using DesafioFULL.Domain.Entities;
using DesafioFULL.Infrastructure.DBConfiguration;
using DesafioFULL.Infrastructure.Interfaces.Repositories.Domain;
using DesafioFULL.Infrastructure.Repositories.Standard;

namespace DesafioFULL.Infrastructure.Repositories
{
    public class InstallmentRepository : DomainRepository<Installment>, IInstallmentRepository
    {
        public InstallmentRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
