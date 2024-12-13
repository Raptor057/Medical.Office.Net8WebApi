using Common.Common;

namespace Medical.Office.App.UseCases.POS.CashMovements.GetCashMovements.Response
{
    public record FailureGetCashMovementsResponse (string Message): GetCashMovementsResponse, IFailure;
}
