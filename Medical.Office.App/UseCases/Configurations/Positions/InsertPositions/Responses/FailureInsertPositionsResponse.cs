using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.Positions.InsertPositions.Responses
{
    public record class FailureInsertPositionsResponse(string Message): InsertPositionsResponse,IFailure;
}
