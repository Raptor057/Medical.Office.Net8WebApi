namespace Medical.Office.Domain.Entities.POS
{
    public class SalesPromotions
    {
        public int SalePromotionId { get; set; }

        public int SaleId { get; set; }

        public int PromotionId { get; set; }

        public decimal DiscountApplied { get; set; }

    }
}
