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
    public class DebtService : ServiceBase<Debt>, IDebtService
    {
        private readonly IDebtRepository _repository;
        private readonly IInstallmentService _installmentService;

        public DebtService(IDebtRepository repository, IInstallmentService installmentService) : base(repository)
        {
            _repository = repository;
            _installmentService = installmentService;
        }

        public int CreateDebt(DebtDtoRequest request)
        {
            try
            {
                var debt = MountNewDebt(request);
                var newDebt = base.Add(debt);
                _installmentService.CreateInstallments(request.Installments, newDebt);

                return newDebt.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<DebtDtoResponse> GetDebts()
        {
            try
            {
                var debts = _repository.GetDebtsWithInstallments();
                return debts.Select(x => MountDebtDtoResponse(x));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Debt MountNewDebt(DebtDtoRequest request)
        {
            var newDebt = new Debt();
            newDebt.Number = request.Number;
            newDebt.DebtorName = request.DebtorName;
            newDebt.DebtorCpf = request.DebtorCpf;
            newDebt.InterestPercent = request.InterestPercent;
            newDebt.PenaltyPercent = request.PenaltyPercent;

            return newDebt;
        }

        public DebtDtoResponse MountDebtDtoResponse(Debt debt)
        {
            var newDebt = new DebtDtoResponse();
            newDebt.Number = debt.Number;
            newDebt.DebtorName = debt.DebtorName;
            newDebt.TotalInstallments = debt.Installments.Count;
            newDebt.OriginalValue = debt.Installments.Sum(x => x.Value);
            newDebt.OverDue = _installmentService.GetOverDue(debt.Installments.First().DueDate);
            newDebt.UpdatedValue = _installmentService.GetUpdatedValue(debt.Installments, debt.PenaltyPercent, debt.InterestPercent);

            return newDebt;
        }
    }
}
