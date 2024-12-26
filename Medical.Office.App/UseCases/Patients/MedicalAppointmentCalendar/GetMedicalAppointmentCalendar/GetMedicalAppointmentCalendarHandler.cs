using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.GetMedicalAppointmentCalendar
{
    internal sealed class GetMedicalAppointmentCalendarHandler : IInteractor<GetMedicalAppointmentsRequest, GetMedicalAppointmentCalendarResponse>
    {
        private readonly ILogger<GetMedicalAppointmentCalendarHandler> _logger;
        private readonly IPatientsData _patients;
        private readonly IConfigurationsRepository _configurations;

        public GetMedicalAppointmentCalendarHandler(ILogger<GetMedicalAppointmentCalendarHandler> logger, IPatientsData patients, IConfigurationsRepository configurations)
        {
            _logger = logger;
            _patients = patients;
            _configurations = configurations;
        }

        public async Task<GetMedicalAppointmentCalendarResponse> Handle(GetMedicalAppointmentsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Caso 1: Solicita la lista completa (sin filtros)
                if (request.IDPatient == 0 && request.IDDoctor == 0 &&
                    !request.AppointmentDateTime.HasValue && string.IsNullOrEmpty(request.ReasonForVisit) &&
                    string.IsNullOrEmpty(request.AppointmentStatus) && string.IsNullOrEmpty(request.Notes) &&
                    string.IsNullOrEmpty(request.TypeOfAppointment))
                {
                    var appointments = await _patients.GetListMedicalAppointmentCalendarAsync();

                    var appointmentsDto = appointments.Select(m => new MedicalAppointmentCalendarDto(
                    m.Id , // Ajusta a un valor predeterminado si es necesario
                    m.IDPatient,
                    IDDoctor: m.IDDoctor,
                    m.AppointmentDate + m.AppointmentTime,
                    ReasonForVisit: m.ReasonForVisit,
                    m.AppointmentStatus,
                    Notes: m.Notes,
                    m.CreatedAt,
                    UpdatedAt: m.UpdatedAt,
                    m.TypeOfAppointment));
                    
                    return new SuccessGetListMedicalAppointmentCalendarResponse(appointmentsDto);
                }

                //Caso 2: Filtro por IDPatient
                if (request.IDPatient > 0 && request.IDDoctor > 0 &&
                    !request.AppointmentDateTime.HasValue && string.IsNullOrEmpty(request.ReasonForVisit) &&
                    string.IsNullOrEmpty(request.AppointmentStatus) && string.IsNullOrEmpty(request.Notes) &&
                    string.IsNullOrEmpty(request.TypeOfAppointment))
                {
                    var appointments = await _patients.GetListMedicalAppointmentCalendarByIDPatientAsync(request.IDPatient);

                    var appointmentsDto = appointments.Select(m => new MedicalAppointmentCalendarDto(
                    m.Id, // Ajusta a un valor predeterminado si es necesario
                    m.IDPatient,
                    IDDoctor: m.IDDoctor,
                    m.AppointmentDate+m.AppointmentTime,
                    m.ReasonForVisit,
                    AppointmentStatus: m.AppointmentStatus,
                    m.Notes,
                    CreatedAt: m.CreatedAt,
                    m.UpdatedAt,
                    TypeOfAppointment: m.TypeOfAppointment));
                    return new SuccessGetListMedicalAppointmentCalendarByIDPatientResponse(appointmentsDto);
                }

                //Caso 3: Última cita de un paciente
                if (request.IDPatient > 0 && request.IDDoctor > 0)
                {
                    var appointment = await _patients.GetLastMedicalAppointmentCalendarByIDPatientAsync(request.IDPatient);

                    var appointmentDto = new MedicalAppointmentCalendarDto(appointment.Id,appointment.IDPatient,appointment.IDDoctor,appointment.AppointmentDate+ appointment.AppointmentTime, appointment.ReasonForVisit,appointment.AppointmentStatus,appointment.Notes,appointment.CreatedAt,appointment.UpdatedAt,appointment.TypeOfAppointment);
                    
                    return new SuccessGetLastMedicalAppointmentCalendarByIDPatientResponse(appointmentDto);
                }

                // Caso 4: Filtro avanzado con todos los parámetros
                var filteredAppointments = await _patients.GetListMedicalAppointmentCalendarByParamsAsync(
                    request.IDPatient,
                    request.IDDoctor,
                    request.AppointmentDateTime ?? DateTime.MinValue,
                    request.ReasonForVisit ?? string.Empty,
                    request.AppointmentStatus ?? string.Empty,
                    request.Notes,
                    request.TypeOfAppointment ?? string.Empty);

                var filteredAppointmentsDto = filteredAppointments.Select(m => new MedicalAppointmentCalendarDto(
                    m.Id, // Ajusta a un valor predeterminado si es necesario
                    m.IDPatient,
                    m.IDDoctor,
                    m.AppointmentDate+m.AppointmentTime,
                    m.ReasonForVisit,
                    m.AppointmentStatus,
                    m.Notes,
                    m.CreatedAt,
                    m.UpdatedAt,
                    m.TypeOfAppointment));

                return new SuccessGetListMedicalAppointmentCalendarByParamsResponse(filteredAppointmentsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while handling GetMedicalAppointmentsRequest");
                return new FailureGetMedicalAppointmentCalendarResponse($"{new List<string> { ex.Message }}");
            }
        }
    }
}
