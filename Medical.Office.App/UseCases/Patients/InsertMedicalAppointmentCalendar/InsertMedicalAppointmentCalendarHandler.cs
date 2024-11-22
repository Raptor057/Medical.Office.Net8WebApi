using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.InsertMedicalAppointmentCalendar.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.InsertMedicalAppointmentCalendar
{
    internal sealed class InsertMedicalAppointmentCalendarHandler: IInteractor<InsertMedicalAppointmentCalendarRequest,InsertMedicalAppointmentCalendarResponse>
    {
        private readonly IPatientsData _patients;
        private readonly IConfigurationsRepository _configurations;
        private readonly ILogger<InsertMedicalAppointmentCalendarHandler> _logger;

        public InsertMedicalAppointmentCalendarHandler(ILogger<InsertMedicalAppointmentCalendarHandler> logger,IPatientsData patients, IConfigurationsRepository configurations)
        {
            _patients=patients;
            _configurations=configurations;
            _logger=logger;
        }

        public async Task<InsertMedicalAppointmentCalendarResponse> Handle(InsertMedicalAppointmentCalendarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Validar el argumento de entrada
                if (request == null)
                throw new ArgumentNullException(nameof(request));

                var Patient = await _patients.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
                var Doctor = await _configurations.GetDoctorAsync(request.IDDoctor).ConfigureAwait(false);
                if (Patient == null) 
                {
                return new FailureInsertMedicalAppointmentCalendarResponse($"No se puede agregar esta cita a este paciente {request.IDPatient} debido a que no se encontro registro");
                }
                if (Doctor == null)
                {
                return new FailureInsertMedicalAppointmentCalendarResponse($"No se puede agregar esta cita a este paciente {request.IDPatient} debido a que no se encontro registro del doctor {request.IDDoctor}");
                }

                await _patients.InsertMedicalAppointmentCalendarAsync(request.IDPatient,request.IDDoctor,request.AppointmentDateTime,request.ReasonForVisit,request.AppointmentStatus,request.Notes,request.TypeOfAppointment).ConfigureAwait(false);

                var LastMedicalAppointmentCalendar = await _patients.GetLastMedicalAppointmentCalendarByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
            
                var MedicalAppointmentCalendar = new MedicalAppointmentCalendarDto(LastMedicalAppointmentCalendar.Id,LastMedicalAppointmentCalendar.IDPatient,LastMedicalAppointmentCalendar.IDDoctor,LastMedicalAppointmentCalendar.AppointmentDateTime,LastMedicalAppointmentCalendar.ReasonForVisit,LastMedicalAppointmentCalendar.AppointmentStatus,LastMedicalAppointmentCalendar.Notes,LastMedicalAppointmentCalendar.CreatedAt,LastMedicalAppointmentCalendar.UpdatedAt,LastMedicalAppointmentCalendar.TypeOfAppointment);

                return new SuccessInsertMedicalAppointmentCalendarResponse(MedicalAppointmentCalendar);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al manejar la inserción de la cita médica.");
                return new FailureInsertMedicalAppointmentCalendarResponse($"Ocurrió un error al procesar la solicitud. {ex}");
            }
    //return new SuccessInsertMedicalAppointmentCalendarResponse(new MedicalAppointmentCalendarDto(LastMedicalAppointmentCalendar.Id, LastMedicalAppointmentCalendar.IDPatient, LastMedicalAppointmentCalendar.IDDoctor, LastMedicalAppointmentCalendar.AppointmentDateTime, LastMedicalAppointmentCalendar.ReasonForVisit, LastMedicalAppointmentCalendar.AppointmentStatus, LastMedicalAppointmentCalendar.Notes, LastMedicalAppointmentCalendar.CreatedAt, LastMedicalAppointmentCalendar.UpdatedAt, LastMedicalAppointmentCalendar.TypeOfAppointment));
        }
    }
}
