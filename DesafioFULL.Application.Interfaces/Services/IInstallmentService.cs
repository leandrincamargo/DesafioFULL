using DesafioFULL.Application.Interfaces.Services.Standard;
using DesafioFULL.Domain.DTOs;
using DesafioFULL.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DesafioFULL.Application.Interfaces.Services
{
    public interface IInstallmentService : IServiceBase<Installment>
    {
        void CreateInstallments(IEnumerable<InstallmentDtoRequest> request, Debt debt);
        decimal GetUpdatedValue(ICollection<Installment> installments, decimal penaltyPercent, decimal interestPercent);
        int GetOverDue(DateTime dueDate);
        decimal GetPenaltyValue(decimal originalValue, decimal penaltyPercent);
        decimal GetInterestValue(DateTime dueDate, decimal value, decimal interestPercent);
    }
}
