using System;

namespace DesafioFULL.Domain.DTOs
{
    public class InstallmentDtoRequest
    {
        public int Number { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
    }
}
