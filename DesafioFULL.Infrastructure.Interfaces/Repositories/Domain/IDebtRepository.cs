using DesafioFULL.Domain.Entities;
using DesafioFULL.Infrastructure.Interfaces.Repositories.Domain.Standard;
using System.Collections.Generic;

namespace DesafioFULL.Infrastructure.Interfaces.Repositories.Domain
{
    public interface IDebtRepository : IDomainRepository<Debt>
    {
        IEnumerable<Debt> GetDebtsWithInstallments();
    }
}
