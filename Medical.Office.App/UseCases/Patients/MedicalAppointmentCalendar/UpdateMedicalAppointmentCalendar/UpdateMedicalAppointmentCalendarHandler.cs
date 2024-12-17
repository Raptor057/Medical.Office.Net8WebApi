
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.UpdateMedicalAppointmentCalendar
{
    internal sealed class UpdateMedicalAppointmentCalendarHandler : IInteractor<UpdateMedicalAppointmentCalendarRequest, UpdateMedicalAppointmentCalendarResponse>
    {
        private readonly ILogger<UpdateMedicalAppointmentCalendarHandler> _logger;
        private readonly IPatientsData _patients;

        public UpdateMedicalAppointmentCalendarHandler(ILogger<UpdateMedicalAppointmentCalendarHandler> logger, IPatientsData patients)
        {
            _logger=logger;
            _patients=patients;
        }

        public async Task<UpdateMedicalAppointmentCalendarResponse> Handle(UpdateMedicalAppointmentCalendarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                

            }
            catch (Exception ex) 
            {
                _logger.LogError($"{ex.Message}");
               return new FailureUpdateMedicalAppointmentCalendarResponse($"{ex.Message}");
            }
        }
    }
}
