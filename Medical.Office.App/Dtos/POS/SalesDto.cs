namespace Medical.Office.App.Dtos.POS
{
    public record SalesDto(

        int SaleId,
        long IDPatient,
        DateTime SaleDate,
        decimal TotalAmount,
        string PaymentType,
        string SaleStatus,
        long UserId
    );
}
