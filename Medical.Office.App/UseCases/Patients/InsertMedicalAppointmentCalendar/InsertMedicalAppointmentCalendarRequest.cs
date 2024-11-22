using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.InsertMedicalAppointmentCalendar.Response;

namespace Medical.Office.App.UseCases.Patients.InsertMedicalAppointmentCalendar
{
    public sealed class InsertMedicalAppointmentCalendarRequest : IRequest<InsertMedicalAppointmentCalendarResponse>
    {
        public static void ValidateData(MedicalAppointmentCalendarDto calendarDto, ErrorList errors)
        {
            if (calendarDto.IDPatient < 1)
            {
                errors.Add("El ID del paciente no es valido");
            }
            if (calendarDto.IDDoctor < 1)
            {
                errors.Add("El ID del Doctor no es valido");
            }
            if (calendarDto.AppointmentDateTime == default)
            {
                errors.Add("La fecha de la cita no es válida");
            }
            if (string.IsNullOrEmpty(calendarDto.TypeOfAppointment))
            {
                errors.Add("No se asigno el tipo de cita");
            }
            if (calendarDto.CreatedAt == default)
            {
                errors.Add("Fecha de creación inválida");
            }
            if (calendarDto.UpdatedAt == default)
            {
                errors.Add("Fecha de actualización inválida");
            }
        }

        public static bool CanInsertMedicalAppointment(MedicalAppointmentCalendarDto calendarDto, out ErrorList errors)
        {
            errors = new();
            ValidateData(calendarDto, errors);
            return errors.IsEmpty;
        }

        public static InsertMedicalAppointmentCalendarRequest InsertMedicalAppointmentCalendar(MedicalAppointmentCalendarDto calendarDto)
        {
            if (!CanInsertMedicalAppointment(calendarDto, out ErrorList errors)) throw errors.AsException();
            return new InsertMedicalAppointmentCalendarRequest(calendarDto);
        }

        public InsertMedicalAppointmentCalendarRequest(MedicalAppointmentCalendarDto calendarDto)
        {
            IDPatient = calendarDto.IDPatient;
            IDDoctor = calendarDto.IDDoctor;
            AppointmentDateTime = calendarDto.AppointmentDateTime;
            ReasonForVisit = calendarDto.ReasonForVisit;
            AppointmentStatus = calendarDto.AppointmentStatus;
            Notes = calendarDto.Notes;
            CreatedAt = calendarDto.CreatedAt;
            UpdatedAt = calendarDto.UpdatedAt;
            TypeOfAppointment = calendarDto.TypeOfAppointment;
        }

        // Propiedades
        public long IDPatient { get; }
        public long IDDoctor { get; }
        public DateTime AppointmentDateTime { get; }
        public string ReasonForVisit { get; }
        public string AppointmentStatus { get; }
        public string? Notes { get; }
        public DateTime? CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
        public string TypeOfAppointment { get; }
    }
}
