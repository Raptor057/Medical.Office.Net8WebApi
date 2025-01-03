using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PathologicalBackground;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory;
using Medical.Office.App.UseCases.Patients.GetPatientDataAndAntecedents.Responses;
using Medical.Office.Domain.Repository;


namespace Medical.Office.App.UseCases.Patients.GetPatientDataAndAntecedents
{
    internal sealed class GetPatientDataAndAntecedentsHandler : IInteractor<GetPatientDataAndAntecedentsRequest, GetPatientDataAndAntecedentsResponse>
    {
        private readonly IPatientsData _patientsData;
        private readonly IAntecedentPatient _antecedent;

        public GetPatientDataAndAntecedentsHandler(IPatientsData patientsData, IAntecedentPatient antecedent)
        {
            _patientsData = patientsData;
            _antecedent = antecedent;
        }

        public async Task<GetPatientDataAndAntecedentsResponse> Handle(GetPatientDataAndAntecedentsRequest request, CancellationToken cancellationToken)
        {

            var GetPatients = await _patientsData.GetPatientDataByIDPatientAsync(request.IdPatient).ConfigureAwait(false);
            var ActiveMedications = await _antecedent.GetActiveMedicationsByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            var FamilyHistory = await _antecedent.GetFamilyHistoryByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            var MedicalHistoryNotes = await _antecedent.GetMedicalHistoryNotesByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            var NonPathologicalHistory = await _antecedent.GetNonPathologicalHistoryByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            var PathologicalBackground = await _antecedent.GetPathologicalBackgroundByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            var PatientAllergies = await _antecedent.GetPatientAllergiesByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            var PsychiatricHistory = await _antecedent.GetPsychiatricHistoryByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            var PatientFiles = await _patientsData.GetPatientsFilesListAsync(request.IdPatient).ConfigureAwait(false);
            var MedicalAppointmentCalendar = await _patientsData.GetMedicalAppointmentCalendarListByIDPatientAsync(request.IdPatient).ConfigureAwait(false);

            var PatientFilesList = PatientFiles.Select(F => new PatientsFilesDto(F.Id,F.IDPatient, F.FileName, F.FileType, F.FileExtension, F.Description, F.FileData, F.DateTimeUploaded)).OrderByDescending(F => F.DateTimeUploaded).ToList();

            var MedicalAppointmentList = MedicalAppointmentCalendar.Select(appointment => new MedicalAppointmentCalendarDto(
                appointment.Id,
                appointment.IDPatient,
                appointment.patientName,
                appointment.IDDoctor,
                appointment.doctorName,
                appointment.AppointmentDateTime,
                appointment.ReasonForVisit,
                appointment.AppointmentStatus,
                appointment.Notes,
                appointment.EndOfAppointmentDateTime,
                appointment.CreatedAt,
                appointment.UpdatedAt,
                appointment.TypeOfAppointment
                )).ToList();

            var MedicalAppointmentListActive = MedicalAppointmentList.Where(m => m.AppointmentStatus == "Activa").OrderBy(m => m.AppointmentDateTime);
            var MedicalAppointmentListHistory = MedicalAppointmentList.Where(m => m.AppointmentStatus == "Inactiva").OrderByDescending(m => m.AppointmentDateTime);
            

            var patientDataAndAntecedents = new PatientDataAndAntecedentsDto(
                new GetPatientsDto(
                    GetPatients.ID,
                    GetPatients.Name,
                    GetPatients.FathersSurname,
                    GetPatients.MothersSurname,
                    GetPatients.DateOfBirth,
                    GetPatients.Gender,
                    GetPatients.Address,
                    GetPatients.Country,
                    GetPatients.City,
                    GetPatients.State,
                    GetPatients.ZipCode,
                    GetPatients.OutsideNumber,
                    GetPatients.InsideNumber,
                    GetPatients.PhoneNumber,
                    GetPatients.Email,
                    GetPatients.EmergencyContactName,
                    GetPatients.EmergencyContactPhone,
                    GetPatients.InsuranceProvider,
                    GetPatients.PolicyNumber,
                    GetPatients.BloodType,
                    GetPatients.DateCreated,
                    GetPatients.LastUpdated,
                    GetPatients.Photo ?? new byte[0],  // Asignar arreglo vacío si Photo es null
                    GetPatients.InternalNotes
                ),
                new ActiveMedicationsDto(
                    ActiveMedications?.Id ?? 0,
                    ActiveMedications?.IDPatient ?? 0,
                    ActiveMedications?.ActiveMedicationsData ?? "",
                    ActiveMedications?.DateTimeSnap ?? DateTime.MinValue
                ),
                new FamilyHistoryDto(
                    FamilyHistory?.Id ?? 0,
                    FamilyHistory?.IDPatient ?? 0,
                    FamilyHistory?.Diabetes ?? false,
                    FamilyHistory?.Cardiopathies ?? false,
                    FamilyHistory?.Hypertension ?? false,
                    FamilyHistory?.ThyroidDiseases ?? false,
                    FamilyHistory?.ChronicKidneyDisease ?? false,
                    FamilyHistory?.Others ?? false,
                    FamilyHistory?.OthersData ?? "",
                    FamilyHistory?.DateTimeSnap ?? DateTime.MinValue
                ),
                new MedicalHistoryNotesDto(
                    MedicalHistoryNotes?.Id ?? 0,
                    MedicalHistoryNotes?.IDPatient ?? 0,
                    MedicalHistoryNotes?.MedicalHistoryNotesData ?? "",
                    MedicalHistoryNotes?.DateTimeSnap ?? DateTime.MinValue
                ),
                new NonPathologicalHistoryDto(
                    NonPathologicalHistory?.Id ?? 0,
                    NonPathologicalHistory?.IDPatient ?? 0,
                    NonPathologicalHistory?.PhysicalActivity ?? false,
                    NonPathologicalHistory?.Smoking ?? false,
                    NonPathologicalHistory?.Alcoholism ?? false,
                    NonPathologicalHistory?.SubstanceAbuse ?? false,
                    NonPathologicalHistory?.SubstanceAbuseData ?? "",
                    NonPathologicalHistory?.RecentVaccination ?? false,
                    NonPathologicalHistory?.RecentVaccinationData ?? "",
                    NonPathologicalHistory?.Others ?? false,
                    NonPathologicalHistory?.OthersData ?? "",
                    NonPathologicalHistory?.DateTimeSnap ?? DateTime.MinValue
                ),
                new PathologicalBackgroundDto(
                    PathologicalBackground?.Id ?? 0,
                    PathologicalBackground?.IDPatient ?? 0,
                    PathologicalBackground?.PreviousHospitalization ?? false,
                    PathologicalBackground?.PreviousSurgeries ?? false,
                    PathologicalBackground?.Diabetes ?? false,
                    PathologicalBackground?.ThyroidDiseases ?? false,
                    PathologicalBackground?.Hypertension ?? false,
                    PathologicalBackground?.Cardiopathies ?? false,
                    PathologicalBackground?.Trauma ?? false,
                    PathologicalBackground?.Cancer ?? false,
                    PathologicalBackground?.Tuberculosis ?? false,
                    PathologicalBackground?.Transfusions ?? false,
                    PathologicalBackground?.RespiratoryDiseases ?? false,
                    PathologicalBackground?.GastrointestinalDiseases ?? false,
                    PathologicalBackground?.STDs ?? false,
                    PathologicalBackground?.STDsData ?? "",
                    PathologicalBackground?.ChronicKidneyDisease ?? false,
                    PathologicalBackground?.Others ?? "",
                    PathologicalBackground?.DateTimeSnap ?? DateTime.MinValue
                ),
                new PatientAllergiesDto(
                    PatientAllergies?.Id ?? 0,
                    PatientAllergies?.IDPatient ?? 0,
                    PatientAllergies?.Allergies ?? "",
                    PatientAllergies?.DateTimeSnap ?? DateTime.MinValue
                ),
                new PsychiatricHistoryDto(
                    PsychiatricHistory?.id ?? 0,
                    PsychiatricHistory?.IDPatient ?? 0,
                    PsychiatricHistory?.FamilyHistory ?? false,
                    PsychiatricHistory?.FamilyHistoryData ?? "",
                    PsychiatricHistory?.AffectedAreas ?? "",
                    PsychiatricHistory?.PastAndCurrentTreatments ?? "",
                    PsychiatricHistory?.FamilySocialSupport ?? false,
                    PsychiatricHistory?.FamilySocialSupportData ?? "",
                    PsychiatricHistory?.WorkLifeAspects ?? "",
                    PsychiatricHistory?.SocialLifeAspects ?? "",
                    PsychiatricHistory?.AuthorityRelationship ?? "",
                    PsychiatricHistory?.ImpulseControl ?? "",
                    PsychiatricHistory?.FrustrationManagement ?? "",
                    PsychiatricHistory?.DateTimeSnap ?? DateTime.MinValue
                ),
                PatientFilesList,
                MedicalAppointmentListActive,
                MedicalAppointmentListHistory
            );
            
            return new SuccessGetPatientDataAndAntecedentsResponse(patientDataAndAntecedents);

        }
    }
}
