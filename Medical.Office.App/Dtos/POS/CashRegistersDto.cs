namespace Medical.Office.App.Dtos.POS
{
    public record CashRegistersDto(

        int CashRegisterId,
        string RegisterName,
        string RegisterStatus,
        DateTime OpeningDate,
        DateTime? ClosingDate,
        decimal InitialBalance,
        decimal? FinalBalance
    );
}
