using DesafioFULL.Application.Interfaces.Services;
using DesafioFULL.Application.Services;
using System;
using Xunit;

namespace DesafioFULL.Application.Test.Services
{
    public class InstallmentServiceTest
    {
        private readonly IInstallmentService installmentService;

        public InstallmentServiceTest()
        {
            installmentService = new InstallmentService(null);
        }

        [Theory]
        [InlineData("2020-07-10")]
        [InlineData("2020-08-10")]
        [InlineData("2020-09-10")]
        public void GetOverDueTest(string dueDateString)
        {
            var dueDate = DateTime.Parse(dueDateString);
            var result = installmentService.GetOverDue(dueDate);
            var expected = (DateTime.Today - dueDate).Days;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, 2)]
        [InlineData(500, 5)]
        [InlineData(1000, 10)]
        public void GetPenaltyValueTest(decimal originalValue, decimal penaltyPercent)
        {
            var result = installmentService.GetPenaltyValue(originalValue, penaltyPercent);
            var expected = Math.Round(originalValue * penaltyPercent / 100, 2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("2020-07-10", 100, 1)]
        [InlineData("2020-08-10", 500, 2)]
        [InlineData("2020-09-10", 1000, 5)]
        public void GetInterestValueTest(string dueDateString, decimal value, decimal interestPercent)
        {
            var dueDate = DateTime.Parse(dueDateString);
            var result = installmentService.GetInterestValue(dueDate, value, interestPercent);

            var expectedDays = (DateTime.Today - dueDate).Days;
            var expected = Math.Round(interestPercent / 100 / 30 * expectedDays * value, 2);

            Assert.Equal(expected, result);
        }
    }
}
