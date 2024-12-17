
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
            var MedicalAppointmentData = request.MedicalAppointment;
            try
            {
                if (MedicalAppointmentData == null)
                {
                    return new FailureUpdateMedicalAppointmentCalendarResponse("No se recibieron datos de consulta.");
                }

               await _patients.UpdateMedicalAppointmentCalendarAsync(MedicalAppointmentData.IDPatient, MedicalAppointmentData.IDDoctor, MedicalAppointmentData.AppointmentDateTime, MedicalAppointmentData.ReasonForVisit, MedicalAppointmentData.AppointmentStatus, MedicalAppointmentData.Notes, MedicalAppointmentData.TypeOfAppointment).ConfigureAwait(false);

                var MedicalAppointment = _patients.GetLastMedicalAppointmentCalendarByIDPatientAsync(MedicalAppointmentData.IDPatient).ConfigureAwait(false);

                return new SuccessUpdateMedicalAppointmentCalendarResponse(MedicalAppointmentData);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"{ex.Message}");
               return new FailureUpdateMedicalAppointmentCalendarResponse($"{ex.Message}");
            }
        }
    }
}
