
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Positions.InsertPositions.Responses;
using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Configurations.Positions.InsertPositions
{
    internal sealed class InsertPositionsHandler : IInteractor<InsertPositionsRequest, InsertPositionsResponse>
    {
        private readonly ILogger<InsertPositionsHandler> _logger;
        private readonly IConfigurationsRepository _configurations;

        public InsertPositionsHandler(ILogger<InsertPositionsHandler> logger, IConfigurationsRepository configurations)
        {
            _logger=logger;
            _configurations=configurations;
        }
        public async Task<InsertPositionsResponse> Handle(InsertPositionsRequest request, CancellationToken cancellationToken)
        {
           
            var GetPositions = await _configurations.GetPositionsAsync().ConfigureAwait(false);

            var Positions = GetPositions.Select(p => new PositionsDto { PositionName = p.PositionName }).ToList();

            if (Positions.Any(p => p.PositionName.Equals(request.PositionName, StringComparison.OrdinalIgnoreCase)))
            {
                // Si existe, da un error
                return new FailureInsertPositionsResponse("El nombre de la posición ya existe.");
            }
            await _configurations.InsertPositionsAsync(request.PositionName).ConfigureAwait(false);
            return new SuccessInsertPositionsResponse(request.PositionName);
        }
    }
}
