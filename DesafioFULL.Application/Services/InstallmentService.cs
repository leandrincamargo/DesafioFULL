using DesafioFULL.Application.Interfaces.Services;
using DesafioFULL.Application.Services.Standard;
using DesafioFULL.Domain.DTOs;
using DesafioFULL.Domain.Entities;
using DesafioFULL.Infrastructure.Interfaces.Repositories.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFULL.Application.Services
{
    public class InstallmentService : ServiceBase<Installment>, IInstallmentService
    {
        public InstallmentService(IInstallmentRepository repository) : base(repository) { }

        public void CreateInstallments(IEnumerable<InstallmentDtoRequest> request, Debt debt)
        {
            try
            {
                var installments = request.Select(x => MountNewInstallment(x, debt));
                base.AddRange(installments);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetUpdatedValue(ICollection<Installment> installments, decimal penaltyPercent, decimal interestPercent)
        {
            var originalValue = installments.Sum(x => x.Value);
            var penalty = GetPenaltyValue(originalValue, penaltyPercent);
            var interest = installments.Sum(x => GetInterestValue(x.DueDate, x.Value, interestPercent));

            return originalValue + penalty + interest;
        }

        public int GetOverDue(DateTime dueDate)
        {
            return (DateTime.Today - dueDate.Date).Days;
        }

        public decimal GetPenaltyValue(decimal originalValue, decimal penaltyPercent)
        {
            return Math.Round(originalValue * penaltyPercent / 100, 2);
        }

        public decimal GetInterestValue(DateTime dueDate, decimal value, decimal interestPercent)
        {
            var overDue = GetOverDue(dueDate);
            return Math.Round(interestPercent / 100 / 30 * overDue * value, 2);
        }

        private static Installment MountNewInstallment(InstallmentDtoRequest dto, Debt debt)
        {
            var newInstallment = new Installment();
            newInstallment.Number = dto.Number;
            newInstallment.DueDate = dto.DueDate.Date;
            newInstallment.Value = dto.Value;
            newInstallment.Debt = debt;

            return newInstallment;
        }
    }
}
