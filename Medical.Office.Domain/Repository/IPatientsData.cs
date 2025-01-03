using Medical.Office.Domain.Entities.MedicalOffice;

namespace Medical.Office.Domain.Repository
{
    public interface IPatientsData
    {
        Task InsertPatientDataAsync(string Name, string FathersSurname, string MothersSurname, DateTime? DateOfBirth, string Gender, string Address, string Country, string City, string State, string ZipCode, string OutsideNumber, string InsideNumber, string PhoneNumber, string Email, string EmergencyContactName, string EmergencyContactPhone, string InsuranceProvider, string PolicyNumber, string BloodType, byte[] Photo, string InternalNotes);

        Task<PatientData> GetPatientDataByIDPatientAsync(long ID);
        Task <IEnumerable<PatientData>> GetPatientsDataListAsync();
        
        Task <IEnumerable<PatientsFiles>> GetPatientsFilesListAsync(long IDPatient);
        Task<PatientsFiles> GetPatientFileByIDPatientAndIdAsync(long IDPatient, long Id);
        
        Task DeletePatientFileAsync(long IDPatient, long Id);
        Task InsertPatientFileAsync(long IDPatient, string FileName, string FileType, string FileExtension, string Description ,byte[] FileData, DateTime DateTimeUploaded);

        #region AppoimentCalendar
        
        Task<int> MedicalAppointmentCalendarIsOverlappingAsync(long IDDoctor, DateTime AppointmentDateTime);
        Task UpdateAppointmentStatusAsync();
        Task InsertMedicalAppointmentCalendarAsync(long IDPatient ,long IDDoctor ,DateTime AppointmentDateTime ,string ReasonForVisit ,string Notes ,string TypeOfAppointment);
        Task UpdateMedicalAppointmentCalendarAsync(long Id ,long IDPatient ,long IDDoctor ,DateTime AppointmentDateTime ,string ReasonForVisit ,string Notes ,string TypeOfAppointment);
        Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDPatientAsync(long IdPatient);
        Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDDoctorAsync(long IdDoctor);
        Task<IEnumerable<MedicalAppointmentCalendar>> GetAllsMedicalAppointmentCalendarAsync();

        #endregion

    }
}
