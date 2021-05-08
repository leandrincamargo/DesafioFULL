using DesafioFULL.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace DesafioFULL.Application.Test
{
    public class DebtMock : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Debt
                {
                    Number = 101010,
                    DebtorCpf = "15915915973",
                    DebtorName = "Mock 1",
                    InterestPercent = 1,
                    PenaltyPercent = 2,
                    Installments = InstallmentMock.GetInstallments()
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
