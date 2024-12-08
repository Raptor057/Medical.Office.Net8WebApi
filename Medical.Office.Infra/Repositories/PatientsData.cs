using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;

namespace Medical.Office.Infra.Repositories
{
    class PatientsData : IPatientsData
    {
        private readonly MedicalOfficeSqlLocalDB _db;

        public PatientsData(MedicalOfficeSqlLocalDB db)
        {
            _db=db;
        }

        public async Task<MedicalAppointmentCalendar> GetLastMedicalAppointmentCalendarByIDPatientAsync(long IDPatient)
            => await _db.GetLastMedicalAppointmentCalendarByIDPatient(IDPatient).ConfigureAwait(false);
        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetListMedicalAppointmentCalendarAsync()
            => await _db.GetListMedicalAppointmentCalendar().ConfigureAwait(false);

        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetListMedicalAppointmentCalendarByIDPatientAsync(long IDPatient)
            => await _db.GetMedicalAppointmentCalendarByIDPatient(IDPatient).ConfigureAwait(false);

        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetListMedicalAppointmentCalendarByParamsAsync(long IDPatient, long IDDoctor, DateTime? AppointmentDateTime, string? ReasonForVisit, string? AppointmentStatus, string? Notes, string? TypeOfAppointment)
            => await _db.GetMedicalAppointmentCalendarByParams(IDPatient, IDDoctor, AppointmentDateTime, ReasonForVisit, AppointmentStatus, Notes, TypeOfAppointment).ConfigureAwait(false);

        public async Task InsertMedicalAppointmentCalendarAsync(long IDPatient, long IDDoctor, DateTime? AppointmentDateTime, string? ReasonForVisit, string? AppointmentStatus, string? Notes, string? TypeOfAppointment)
            => await _db.InsertMedicalAppointmentCalendar(IDPatient, IDDoctor, AppointmentDateTime, ReasonForVisit, AppointmentStatus, Notes, TypeOfAppointment).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PatientData> GetPatientDataByIDPatientAsync(long ID)
            => await _db.GetPatientDataByIDPatient(ID).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<PatientData>> GetPatientsDataListAsync()
            => await _db.GetPatientsDataList().ConfigureAwait(false);

        public async Task<IEnumerable<PatientsFiles>> GetPatientsFilesListAsync(long IDPatient)
        => await _db.GetPatientsFilesListByIDPatient(IDPatient).ConfigureAwait(false);

        public async Task<PatientsFiles> GetPatientFileByIDPatientAndIdAsync(long IDPatient, long Id)
        => await _db.GetPatientFileByIDPatient(IDPatient,Id).ConfigureAwait(false);
        public async Task DeletePatientFileAsync(long IDPatient, int Id)
        => await _db.DeletePatientFiles(IDPatient, Id).ConfigureAwait(false);

        public async Task InsertPatientFileAsync(PatientsFiles PatientFiles)
        => await _db.InsertPatientFiles(PatientFiles).ConfigureAwait(false);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="FathersSurname"></param>
        /// <param name="MothersSurname"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="Gender"></param>
        /// <param name="Address"></param>
        /// <param name="Country"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="ZipCode"></param>
        /// <param name="OutsideNumber"></param>
        /// <param name="InsideNumber"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
        /// <param name="EmergencyContactName"></param>
        /// <param name="EmergencyContactPhone"></param>
        /// <param name="InsuranceProvider"></param>
        /// <param name="PolicyNumber"></param>
        /// <param name="BloodType"></param>
        /// <param name="Photo"></param>
        /// <param name="InternalNotes"></param>
        /// <returns></returns>
        public async Task InsertPatientDataAsync(string Name, string FathersSurname, string MothersSurname,
            DateTime? DateOfBirth, string Gender, string Address, string Country, string City, string State, string ZipCode, string OutsideNumber, string InsideNumber, string PhoneNumber, string Email, string EmergencyContactName, string EmergencyContactPhone, string InsuranceProvider, string PolicyNumber, string BloodType, byte[] Photo, string InternalNotes)
            => await _db.InsertPatientData(Name, FathersSurname, MothersSurname, DateOfBirth, Gender, Address, Country, City, State, ZipCode, OutsideNumber, InsideNumber, PhoneNumber, Email,EmergencyContactName, EmergencyContactPhone, InsuranceProvider, PolicyNumber, BloodType, Photo, InternalNotes).ConfigureAwait(false);
    }
}
