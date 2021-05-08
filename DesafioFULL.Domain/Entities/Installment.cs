using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioFULL.Domain.Entities
{
    public class Installment : IIdentityEntity
    {
        public int Id { get; set; }
        [Required]
        public Debt Debt { get; set; }
        public int Number { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
    }
}
