using DesafioFULL.Infrastructure.Interfaces.Repositories.Standard;

namespace DesafioFULL.Infrastructure.Interfaces.Repositories.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IRepository<TEntity> where TEntity : class { }
}
