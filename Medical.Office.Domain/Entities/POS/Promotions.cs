namespace Medical.Office.Domain.Entities.POS
{
    public class Promotions
    {
        public int PromotionId { get; set; }

        public string PromotionName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PromotionType { get; set; }

        public decimal Value { get; set; }

    }
}
