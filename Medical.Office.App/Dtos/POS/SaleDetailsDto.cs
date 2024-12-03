namespace Medical.Office.App.Dtos.POS
{
    public record SaleDetailsDto(

        int SaleDetailId,
        int SaleId,
        int ProductId,
        int Quantity,
        decimal UnitPrice,
        decimal Subtotal
    );
}
