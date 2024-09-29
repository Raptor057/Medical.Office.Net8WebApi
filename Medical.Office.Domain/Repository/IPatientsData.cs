using Medical.Office.Domain.DataSources.Entities.MedicalOffice;

namespace Medical.Office.Domain.Repository
{
    public interface IPatientsData
    {
        Task InsertPatientDataAsync(string Name, string FathersSurname, string MothersSurname, DateTime? DateOfBirth, string Gender, string Address, string Country, string City, string State, string ZipCode, string OutsideNumber, string InsideNumber, string PhoneNumber, string Email, string EmergencyContactName, string EmergencyContactPhone, string InsuranceProvider, string PolicyNumber, string BloodType, byte[] Photo, string InternalNotes);

        Task<PatientData> GetPatientDataByIDPatientAsync(long ID);
        Task <IEnumerable<PatientData>> GetPatientsDataListAsync();
    }
}
