using DesafioFULL.Application.Interfaces.Services;
using DesafioFULL.Application.Services;
using DesafioFULL.Domain.Entities;
using System;
using System.Linq;
using Xunit;

namespace DesafioFULL.Application.Test.Services
{
    public class DebtServiceTest
    {
        private readonly IDebtService debtService;
        private readonly IInstallmentService installmentService;

        public DebtServiceTest()
        {
            installmentService = new InstallmentService(null);
            debtService = new DebtService(null, installmentService);
        }

        [Theory, ClassData(typeof(DebtMock))]
        public void MountDebtDtoResponseTest(Debt debt)
        {
            var result = debtService.MountDebtDtoResponse(debt);
            var expectedOverDue = (DateTime.Today - debt.Installments.First().DueDate.Date).Days;
            var expectedTotalInstallments = debt.Installments.Count;
            var expectedOriginalValue = debt.Installments.Sum(x => x.Value);
            var expectedUpdatedValue = installmentService.GetUpdatedValue(debt.Installments, debt.PenaltyPercent, debt.InterestPercent);

            Assert.Equal(expectedOverDue, result.OverDue);
            Assert.Equal(expectedTotalInstallments, result.TotalInstallments);
            Assert.Equal(expectedOriginalValue, result.OriginalValue);
            Assert.Equal(expectedUpdatedValue, result.UpdatedValue);
        }
    }
}
