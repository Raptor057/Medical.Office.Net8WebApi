using Common.Common;
using Medical.Office.App.Dtos.Configurations;

namespace Medical.Office.App.UseCases.Configurations.Positions.InsertPositions.Responses
{
    public record  SuccessInsertPositionsResponse(string Positions): InsertPositionsResponse,ISuccess;
    //public record SuccessInsertPositionsResponse(PositionsDto Positions) : InsertPositionsResponse;
}
