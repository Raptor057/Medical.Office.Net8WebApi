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
        public async Task DeletePatientFileAsync(long IDPatient, long Id)
        => await _db.DeletePatientFiles(IDPatient, Id).ConfigureAwait(false);

        public async Task InsertPatientFileAsync(long IDPatient, string FileName, string FileType, string FileExtension, string Description, byte[] FileData, DateTime DateTimeUploaded)
        {
            var PatientFile = new PatientsFiles
            {
                Id=0,
                IDPatient = IDPatient,
                FileName = FileName,
                FileType = FileType,
                FileExtension = FileExtension,
                Description = Description,
                FileData = FileData,
                DateTimeUploaded = DateTimeUploaded
            };

            await _db.InsertPatientFiles(PatientFile);
        }

        public Task<int> MedicalAppointmentCalendarIsOverlappingAsync(long IDDoctor, DateTime AppointmentDateTime)
        => _db.MedicalAppointmentCalendarIsOverlapping(IDDoctor, AppointmentDateTime);

        public async Task InsertPatientDataAsync(string Name, string FathersSurname, string MothersSurname,
            DateTime? DateOfBirth, string Gender, string Address, string Country, string City, string State, string ZipCode, string OutsideNumber, string InsideNumber, string PhoneNumber, string Email, string EmergencyContactName, string EmergencyContactPhone, string InsuranceProvider, string PolicyNumber, string BloodType, byte[] Photo, string InternalNotes)
            => await _db.InsertPatientData(Name, FathersSurname, MothersSurname, DateOfBirth, Gender, Address, Country, City, State, ZipCode, OutsideNumber, InsideNumber, PhoneNumber, Email,EmergencyContactName, EmergencyContactPhone, InsuranceProvider, PolicyNumber, BloodType, Photo, InternalNotes).ConfigureAwait(false);

        #region MedicalAppointmentCalendar

        public Task UpdateAppointmentStatusAsync()
            => _db.UpdateAppointmentStatus();

        public async Task InsertMedicalAppointmentCalendarAsync(long IDPatient ,long IDDoctor ,DateTime AppointmentDateTime ,string ReasonForVisit ,string Notes ,string TypeOfAppointment)
        {
            var MedicalAppointmentCalendar = new MedicalAppointmentCalendar
            {
                IDPatient = IDPatient,
                IDDoctor = IDDoctor,
                AppointmentDateTime = AppointmentDateTime,
                ReasonForVisit = ReasonForVisit,
                Notes = Notes,
                TypeOfAppointment = TypeOfAppointment
            };
            await _db.InsertMedicalAppointmentCalendar(MedicalAppointmentCalendar).ConfigureAwait(false);
        }

        public async Task UpdateMedicalAppointmentCalendarAsync(long Id ,long IDPatient ,long IDDoctor ,DateTime AppointmentDateTime ,string ReasonForVisit ,string Notes ,string TypeOfAppointment)
        {
            var MedicalAppointmentCalendar = new MedicalAppointmentCalendar
            {
                Id = Id,
                IDPatient = IDPatient,
                IDDoctor = IDDoctor,
                AppointmentDateTime = AppointmentDateTime,
                ReasonForVisit = ReasonForVisit,
                Notes = Notes,
                TypeOfAppointment = TypeOfAppointment
            };
            await _db.UpdateMedicalAppointmentCalendar(MedicalAppointmentCalendar).ConfigureAwait(false);
        }

        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDPatientAsync(
            long IdPatient)
            => await _db.GetMedicalAppointmentCalendarListByIDPatient(IdPatient).ConfigureAwait(false);

        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDDoctorAsync(
            long IdDoctor)
            => await _db.GetMedicalAppointmentCalendarListByIDDoctor(IdDoctor).ConfigureAwait(false);

        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetAllsMedicalAppointmentCalendarAsync()
            => await _db.GetAllsMedicalAppointmentCalendar().ConfigureAwait(false);

        #endregion
    }
}
