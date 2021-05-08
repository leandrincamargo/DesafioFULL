using DesafioFULL.Domain.Entities;
using System.Collections.Generic;

namespace DesafioFULL.Application.Test
{
    public static class InstallmentMock
    {
        public static ICollection<Installment> GetInstallments()
        {
            return new List<Installment> 
            {
                new Installment
                {
                    Number = 10,
                    DueDate = new System.DateTime(2020, 07, 10),
                    Value = 100
                },
                new Installment
                {
                    Number = 11,
                    DueDate = new System.DateTime(2020, 08, 10),
                    Value = 100
                },
                new Installment
                {
                    Number = 12,
                    DueDate = new System.DateTime(2020, 09, 10),
                    Value = 100
                }
            };
        }
    }
}
