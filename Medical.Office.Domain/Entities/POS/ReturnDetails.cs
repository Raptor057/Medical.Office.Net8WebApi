namespace Medical.Office.Domain.Entities.POS
{
    public class ReturnDetails
    {
        public int ReturnDetailId { get; set; }

        public int ReturnId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Subtotal { get; set; }

    }
}
