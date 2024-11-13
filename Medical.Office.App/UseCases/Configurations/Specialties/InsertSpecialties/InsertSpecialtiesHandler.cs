using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Specialties.InsertSpecialties.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Configurations.Specialties.InsertSpecialties
{
    internal sealed class InsertSpecialtiesHandler : IInteractor<InsertSpecialtiesRequest, InsertSpecialtiesResponse>
    {
        private readonly ILogger<InsertSpecialtiesHandler> _logger;
        private readonly IConfigurationsRepository _configurations;

        public InsertSpecialtiesHandler(ILogger<InsertSpecialtiesHandler> logger, IConfigurationsRepository configurations)
        {
            _logger=logger;
            _configurations=configurations;
        }
        public async Task<InsertSpecialtiesResponse> Handle(InsertSpecialtiesRequest request, CancellationToken cancellationToken)
        {
            var GetSpecialties = await _configurations.GetSpecialtiesAsync().ConfigureAwait(false);

            var Specialties = GetSpecialties.Select(p => new PositionsDto { PositionName = p.Specialty}).ToList();

            if (Specialties.Any(p => p.PositionName.Equals(request.Specialtie, StringComparison.OrdinalIgnoreCase)))
            {
                return new FailureInsertSpecialtiesResponse("La especialidad ya existe.");
            }

            await _configurations.InsertSpecialtiesAsync(request.Specialtie).ConfigureAwait(false);
            _logger.LogInformation("Se agrego la especialidad correctamente");
            return new SuccessInsertSpecialtiesResponse(request.Specialtie);
        }
    }
}
