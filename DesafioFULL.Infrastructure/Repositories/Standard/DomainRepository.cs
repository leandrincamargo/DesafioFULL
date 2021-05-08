using DesafioFULL.Infrastructure.DBConfiguration;
using DesafioFULL.Infrastructure.Interfaces.Repositories.Domain.Standard;

namespace DesafioFULL.Infrastructure.Repositories.Standard
{
    public class DomainRepository<TEntity> : Repository<TEntity>, IDomainRepository<TEntity> where TEntity : class
    {
        protected DomainRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
