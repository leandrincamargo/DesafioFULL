using DesafioFULL.Application.Interfaces.Services.Standard;
using DesafioFULL.Domain.DTOs;
using DesafioFULL.Domain.Entities;
using System.Collections.Generic;

namespace DesafioFULL.Application.Interfaces.Services
{
    public interface IDebtService : IServiceBase<Debt>
    {
        int CreateDebt(DebtDtoRequest request);
        IEnumerable<DebtDtoResponse> GetDebts();
        DebtDtoResponse MountDebtDtoResponse(Debt debt);
    }
}
