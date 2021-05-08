using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioFULL.Domain.Entities
{
    public class Debt : IIdentityEntity
    {
        public Debt()
        {
            this.Installments = new HashSet<Installment>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        [Required]
        public string DebtorName { get; set; }
        [Required]
        public string DebtorCpf { get; set; }
        public decimal InterestPercent { get; set; }
        public decimal PenaltyPercent { get; set; }

        public virtual ICollection<Installment> Installments { get; set; }
    }
}
