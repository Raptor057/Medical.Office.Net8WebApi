namespace Medical.Office.App.Dtos.POS
{
    public record PromotionsDto(

        int PromotionId,
        string PromotionName,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        string PromotionType,
        decimal Value
    );
}
