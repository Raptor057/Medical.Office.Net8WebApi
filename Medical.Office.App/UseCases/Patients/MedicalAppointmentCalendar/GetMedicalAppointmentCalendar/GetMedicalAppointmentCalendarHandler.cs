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
                if (request.IDPatient > 0 && request.IDDoctor <= 0)
                {
                    var MedicalAppointment = await _patients.GetMedicalAppointmentCalendarListByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
                    if (MedicalAppointment == null)
                    {
                        return new FailureGetMedicalAppointmentCalendarResponse($"No se encontraron citas para el paciente #{request.IDPatient}");
                    }
                    
                    var MedicalAppointmentList = MedicalAppointment.Select(m => new MedicalAppointmentCalendarDto(
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
                        m.TypeOfAppointment)).ToList();
                    
                    return new SuccessGetListMedicalAppointmentCalendarResponse(MedicalAppointmentList);
                }
                else if (request.IDPatient <= 0 && request.IDDoctor > 0)
                {
                    var MedicalAppointment = await _patients.GetMedicalAppointmentCalendarListByIDDoctorAsync(request.IDDoctor).ConfigureAwait(false);
                    if (MedicalAppointment == null)
                    {
                        return new FailureGetMedicalAppointmentCalendarResponse($"No se encontraron citas para el doctor #{request.IDDoctor}");
                    }
                    var MedicalAppointmentList = MedicalAppointment.Select(m => new MedicalAppointmentCalendarDto(
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
                        m.TypeOfAppointment)).ToList();
                    
                    return new SuccessGetListMedicalAppointmentCalendarResponse(MedicalAppointmentList);
                }
                else if (request.IDPatient <= 0 && request.IDDoctor <= 0)
                {
                    var MedicalAppointment = await _patients.GetAllsMedicalAppointmentCalendarAsync().ConfigureAwait(false);
                    if (MedicalAppointment == null)
                    {
                        return new FailureGetMedicalAppointmentCalendarResponse("No se encontraron citas");
                    }
                    var MedicalAppointmentList = MedicalAppointment.Select(m => new MedicalAppointmentCalendarDto(
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
                        m.TypeOfAppointment)).ToList();
                    
                    return new SuccessGetListMedicalAppointmentCalendarResponse(MedicalAppointmentList);
                }
                else
                {
                    return new FailureGetMedicalAppointmentCalendarResponse("No se recibieron datos de consulta.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while handling GetMedicalAppointmentsRequest");
                return new FailureGetMedicalAppointmentCalendarResponse($"{new List<string> { ex.Message }}");
            }
        }
    }
}
