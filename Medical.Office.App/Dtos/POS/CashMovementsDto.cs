namespace Medical.Office.App.Dtos.POS
{
    public record CashMovementsDto(
    int CashMovementId,
    int CashRegisterId,
    DateTime MovementDate,
    string MovementType,
    decimal Amount,
    string Description
);
}
