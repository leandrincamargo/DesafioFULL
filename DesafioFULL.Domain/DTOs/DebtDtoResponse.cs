namespace DesafioFULL.Domain.DTOs
{
    public class DebtDtoResponse
    {
        public int Number { get; set; }
        public string DebtorName { get; set; }
        public int TotalInstallments { get; set; }
        public decimal OriginalValue { get; set; }
        public int OverDue { get; set; }
        public decimal UpdatedValue { get; set; }
    }
}
