using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.UpdateOfficeSetup.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Configurations.OfficeSetup.UpdateOfficeSetup
{
    internal class UpdateOfficeSetupHandler : IInteractor<UpdateOfficeSetupRequest,UpdateOfficeSetupResponse>
    {
        private readonly ILogger<UpdateOfficeSetupHandler> _logger;
        private readonly IConfigurationsRepository _configurations;

        public UpdateOfficeSetupHandler(ILogger<UpdateOfficeSetupHandler> logger, IConfigurationsRepository configurations)
        {
            _logger=logger;
            _configurations=configurations;
        }

        public async Task<UpdateOfficeSetupResponse> Handle(UpdateOfficeSetupRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new FailureUpdateOfficeSetupResponse("No se recibieron datos");
            }

            var OfficeSetupData = new OfficeSetupDto
            {    
               NameOfOffice = request.NameOfOffice,
                Address = request.Address 
            };

            await _configurations.UpdateOfficeSetupAsync(OfficeSetupData.NameOfOffice,OfficeSetupData.Address).ConfigureAwait(false);

            var UpdatedOfficeSetupData = await _configurations.GetOfficeSetupAsync();
            
            var NewOfficeSetupData = new OfficeSetupDto
            {
                NameOfOffice = UpdatedOfficeSetupData.NameOfOffice,
                Address = UpdatedOfficeSetupData.Address
            };

            return new SuccessUpdateOfficeSetupResponse(NewOfficeSetupData);
        }
    }
}
