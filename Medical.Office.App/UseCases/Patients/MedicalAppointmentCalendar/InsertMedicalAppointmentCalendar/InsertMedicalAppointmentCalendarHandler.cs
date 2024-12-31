using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.InsertMedicalAppointmentCalendar.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.InsertMedicalAppointmentCalendar
{
    internal sealed class InsertMedicalAppointmentCalendarHandler : IInteractor<InsertMedicalAppointmentCalendarRequest, InsertMedicalAppointmentCalendarResponse>
    {
        private readonly IPatientsData _patients;
        private readonly IConfigurationsRepository _configurations;
        private readonly ILogger<InsertMedicalAppointmentCalendarHandler> _logger;

        public InsertMedicalAppointmentCalendarHandler(ILogger<InsertMedicalAppointmentCalendarHandler> logger, IPatientsData patients, IConfigurationsRepository configurations)
        {
            _patients = patients;
            _configurations = configurations;
            _logger = logger;
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
                var TypeOfAppointment = await _configurations.GetTypeOfAppointmentsListAsync();
                if (Patient == null)
                {
                    return new FailureInsertMedicalAppointmentCalendarResponse($"No se puede agregar esta cita al paciente #{request.IDPatient} debido a que no se encontro registro del paciente");
                }
                if (Doctor == null)
                {
                    return new FailureInsertMedicalAppointmentCalendarResponse($"No se puede agregar esta cita al paciente #{request.IDPatient} debido a que no se encontro registro del doctor #{request.IDDoctor}");
                }
                if (TypeOfAppointment == null || !TypeOfAppointment.Select(x => x.NameTypeOfAppointment).Contains(request.TypeOfAppointment))
                {
                    return new FailureInsertMedicalAppointmentCalendarResponse(
                        $"No se puede agregar esta cita al paciente #{request.IDPatient} debido a que no se encontró un tipo de cita válido."
                    );
                }

                await _patients.InsertMedicalAppointmentCalendarAsync(
                    request.IDPatient,
                    request.IDDoctor,
                    request.AppointmentDateTime,
                    request.ReasonForVisit,
                    request.Notes,
                    request.TypeOfAppointment).ConfigureAwait(false);

                var MedicalAppointment = await _patients.GetMedicalAppointmentCalendarListByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
                
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
                
                return new SuccessInsertMedicalAppointmentCalendarResponse(lastMedicalAppointment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al manejar la inserción de la cita médica.");
                return new FailureInsertMedicalAppointmentCalendarResponse($"Ocurrió un error al procesar la solicitud. {ex}");
            }
        }
    }
}
