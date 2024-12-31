
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
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

                await _patients.UpdateMedicalAppointmentCalendarAsync(MedicalAppointmentData.Id,
                   MedicalAppointmentData.IDPatient,
                   MedicalAppointmentData.IDDoctor,
                   MedicalAppointmentData.AppointmentDateTime,
                   MedicalAppointmentData.ReasonForVisit,
                   MedicalAppointmentData.Notes,
                   MedicalAppointmentData.TypeOfAppointment).ConfigureAwait(false);

                //var MedicalAppointment = await _patients.GetMedicalAppointmentCalendarListByIDPatientAsync(MedicalAppointmentData.IDPatient).ConfigureAwait(false);
                var MedicalAppointment = await _patients.GetAllsMedicalAppointmentCalendarAsync().ConfigureAwait(false);
                
                // Verificar si hay registros y mapear al DTO, luego ordenar y obtener el último basado en AppointmentDateTime
                var lastMedicalAppointment = MedicalAppointment
                    ?.Select(m => new MedicalAppointmentCalendarDto(
                        m.Id,
                        m.IDPatient,
                        m.IDDoctor,
                        m.AppointmentDateTime,
                        m.ReasonForVisit,
                        m.AppointmentStatus,
                        m.Notes,
                        m.EndOfAppointmentDateTime,
                        m.CreatedAt,
                        m.UpdatedAt,
                        m.TypeOfAppointment))
                    .OrderByDescending(m => m.UpdatedAt)
                    .FirstOrDefault();
                
                return new SuccessUpdateMedicalAppointmentCalendarResponse(lastMedicalAppointment);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"{ex.Message}");
               return new FailureUpdateMedicalAppointmentCalendarResponse($"{ex.Message}");
            }
        }
    }
}
