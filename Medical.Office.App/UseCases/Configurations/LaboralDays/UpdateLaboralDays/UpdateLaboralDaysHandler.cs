using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.LaboralDays.UpdateLaboralDays.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Configurations.LaboralDays.UpdateLaboralDays
{
    internal sealed class UpdateLaboralDaysHandler : IInteractor<UpdateLaboralDaysRequest,UpdateLaboralDaysResponse>
    {
        private readonly ILogger<UpdateLaboralDaysHandler> _logger;
        private readonly IConfigurationsRepository _configurations;

        public UpdateLaboralDaysHandler(ILogger<UpdateLaboralDaysHandler> logger, IConfigurationsRepository configurations)
        {
            _logger=logger;
            _configurations=configurations;
        }

        public async Task<UpdateLaboralDaysResponse> Handle(UpdateLaboralDaysRequest request, CancellationToken cancellationToken)
        {
            await _configurations.UpdateLaboralDaysByIdAsync(request.LaboralDays.Id,request.LaboralDays.Laboral, request.LaboralDays.OpeningTime, request.LaboralDays.ClosingTime).ConfigureAwait(false);

            var UpdatedBusinessDay = await _configurations.GetLaboralDayByIdAsync(request.LaboralDays.Id).ConfigureAwait(false);

            return new SuccessUpdateLaboralDaysResponse(new LaboralDaysDto(UpdatedBusinessDay.Id, UpdatedBusinessDay.Days, UpdatedBusinessDay.Laboral, UpdatedBusinessDay.OpeningTime, UpdatedBusinessDay.ClosingTime));
        }
    }
}
