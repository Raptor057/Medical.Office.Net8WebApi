using Common.Common;
using Medical.Office.App.Dtos.POS;

namespace Medical.Office.App.UseCases.POS.CashMovements.GetCashMovements.Response
{
    public record SuccessGetCashMovementsResponse(CashMovementsDto CashMovements): GetCashMovementsResponse, ISuccess;
}
