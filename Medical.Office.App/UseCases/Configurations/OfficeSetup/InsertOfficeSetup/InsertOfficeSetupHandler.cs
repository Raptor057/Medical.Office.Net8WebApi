using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup
{
    internal sealed class InsertOfficeSetupHandler : IInteractor<InsertOfficeSetupRequest, InsertOfficeSetupResponse>
    {
        private readonly ILogger<InsertOfficeSetupHandler> _logger;
        private readonly IConfigurationsRepository _configurations;

        public InsertOfficeSetupHandler(ILogger<InsertOfficeSetupHandler> logger, IConfigurationsRepository configurations)
        {
            _logger=logger;
            _configurations=configurations;
        }
        public async Task<InsertOfficeSetupResponse> Handle(InsertOfficeSetupRequest request, CancellationToken cancellationToken)
        {
            var GetOfficeSetupData = await _configurations.GetOfficeSetupAsync().ConfigureAwait(false);

            if (GetOfficeSetupData == null)
            {
                await _configurations.InsertOfficeSetupAsync(request.NameOfOffice, request.Address).ConfigureAwait(false);
                _logger.LogInformation("Se agrego informacion de consultorio exitosamente");
                return new SuccessInsertOfficeSetupResponse(new OfficeSetupDto
                {
                    NameOfOffice = request.NameOfOffice,
                    Address = request.Address
                });
            }
            return new FailureInsertOfficeSetupResponse("No se puede agregar informacion debido a que ya existe");
        }
    }
}
