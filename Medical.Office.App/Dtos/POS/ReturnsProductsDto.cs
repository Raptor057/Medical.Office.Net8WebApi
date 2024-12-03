namespace Medical.Office.App.Dtos.POS
{
    public record ReturnsProductsDto(
        int ReturnId,
        int SaleId,
        DateTime ReturnDate,
        decimal RefundedAmount,
        string ReturnStatusName
    );
}
