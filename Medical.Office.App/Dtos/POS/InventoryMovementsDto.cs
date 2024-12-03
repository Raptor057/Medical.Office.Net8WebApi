namespace Medical.Office.App.Dtos.POS
{
    public record InventoryMovementsDto(
        int MovementId,
        int ProductId,
        string MovementType,
        int Quantity,
        DateTime MovementDate,
        string Description
    );
}
