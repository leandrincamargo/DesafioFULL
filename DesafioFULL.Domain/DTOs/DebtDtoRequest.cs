using System.Collections.Generic;

namespace DesafioFULL.Domain.DTOs
{
    public class DebtDtoRequest
    {
        public int Number { get; set; }
        public string DebtorName { get; set; }
        public string DebtorCpf { get; set; }
        public decimal InterestPercent { get; set; }
        public decimal PenaltyPercent { get; set; }
        public List<InstallmentDtoRequest> Installments { get; set; }
    }
}
