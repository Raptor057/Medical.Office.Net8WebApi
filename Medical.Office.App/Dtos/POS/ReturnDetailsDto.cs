namespace Medical.Office.App.Dtos.POS
{
    public record ReturnDetailsDto(
        int ReturnDetailId,
        int ReturnId,
        int ProductId,
        int Quantity,
        decimal UnitPrice,
        decimal Subtotal
    );
}
