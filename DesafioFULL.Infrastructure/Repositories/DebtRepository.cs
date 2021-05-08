using DesafioFULL.Domain.Entities;
using DesafioFULL.Infrastructure.DBConfiguration;
using DesafioFULL.Infrastructure.Interfaces.Repositories.Domain;
using DesafioFULL.Infrastructure.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Infrastructure.Repositories
{
    public class DebtRepository : DomainRepository<Debt>, IDebtRepository
    {
        public DebtRepository(ApplicationContext dbContext) : base(dbContext) { }

        public IEnumerable<Debt> GetDebtsWithInstallments()
        {
            return _dbSet.Include(x => x.Installments).AsEnumerable();
        }
    }
}
