namespace Medical.Office.Domain.Entities.POS
{
    public class ReturnsProducts
    {
        public int ReturnId { get; set; }

        public int SaleId { get; set; }

        public DateTime ReturnDate { get; set; }

        public decimal RefundedAmount { get; set; }

        public string ReturnStatusName { get; set; }

    }
}
