using Medical.Office.Domain.Entities.MedicalOffice;

namespace Medical.Office.Domain.Repository
{
    public interface IPatientsData
    {
        Task InsertPatientDataAsync(string Name, string FathersSurname, string MothersSurname, DateTime? DateOfBirth, string Gender, string Address, string Country, string City, string State, string ZipCode, string OutsideNumber, string InsideNumber, string PhoneNumber, string Email, string EmergencyContactName, string EmergencyContactPhone, string InsuranceProvider, string PolicyNumber, string BloodType, byte[] Photo, string InternalNotes);
        Task InsertMedicalAppointmentCalendarAsync(long IDPatient, long IDDoctor, DateTime? AppointmentDateTime, string? ReasonForVisit, string? AppointmentStatus, string? Notes, string? TypeOfAppointment);

        Task<IEnumerable<MedicalAppointmentCalendar>> GetListMedicalAppointmentCalendarAsync();
        Task<IEnumerable<MedicalAppointmentCalendar>> GetListMedicalAppointmentCalendarByIDPatientAsync(long IDPatient);

        Task<MedicalAppointmentCalendar> GetLastMedicalAppointmentCalendarByIDPatientAsync(long IDPatient);
        Task<IEnumerable<MedicalAppointmentCalendar>> GetListMedicalAppointmentCalendarByParamsAsync(long IDPatient, long IDDoctor, DateTime? AppointmentDateTime, string? ReasonForVisit, string? AppointmentStatus, string? Notes, string? TypeOfAppointment);

        Task<PatientData> GetPatientDataByIDPatientAsync(long ID);
        Task <IEnumerable<PatientData>> GetPatientsDataListAsync();
    }
}
