namespace Medical.Office.Domain.Entities.POS
{
    public class Sales
    {
        public int SaleId { get; set; }

        public long IDPatient { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string PaymentType { get; set; }

        public string SaleStatus { get; set; }

        public long UserId { get; set; }

    }
}
