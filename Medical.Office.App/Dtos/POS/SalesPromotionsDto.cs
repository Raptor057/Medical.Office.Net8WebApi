namespace Medical.Office.App.Dtos.POS
{
    public record SalesPromotionsDto(

        int SalePromotionId,
        int SaleId,
        int PromotionId,
        decimal DiscountApplied
    );
}
