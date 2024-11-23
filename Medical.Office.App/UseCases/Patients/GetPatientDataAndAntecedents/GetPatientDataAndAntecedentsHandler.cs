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
using Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient;
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
            var PsychiatricHistory =await _antecedent.GetPsychiatricHistoryByPatientIdAsync(request.IdPatient).ConfigureAwait(false);
            var MedicalAppointmentCalendar = await _patientsData.GetListMedicalAppointmentCalendarByIDPatientAsync(request.IdPatient).ConfigureAwait(false);

            // Crear una instancia "vacía" del DTO
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
                GetPatients.Photo,
                GetPatients.InternalNotes),
                new ActiveMedicationsDto(
                ActiveMedications.Id,
                ActiveMedications.IDPatient,
                ActiveMedications.ActiveMedicationsData,
                ActiveMedications.DateTimeSnap),
                new FamilyHistoryDto(
                FamilyHistory.Id,
                FamilyHistory.IDPatient,
                FamilyHistory.Diabetes,
                FamilyHistory.Cardiopathies,
                FamilyHistory.Hypertension,
                FamilyHistory.ThyroidDiseases,
                FamilyHistory.ChronicKidneyDisease,
                FamilyHistory.Others,          // Asegúrate de incluir el campo Others
                FamilyHistory.OthersData,
                FamilyHistory.DateTimeSnap),
                new MedicalHistoryNotesDto(
                MedicalHistoryNotes.Id,
                MedicalHistoryNotes.IDPatient,
                MedicalHistoryNotes.MedicalHistoryNotesData,
                MedicalHistoryNotes.DateTimeSnap),
                new NonPathologicalHistoryDto(
                NonPathologicalHistory.Id,
                NonPathologicalHistory.IDPatient,
                NonPathologicalHistory.PhysicalActivity,
                NonPathologicalHistory.Smoking,
                NonPathologicalHistory.Alcoholism,
                NonPathologicalHistory.SubstanceAbuse,
                NonPathologicalHistory.SubstanceAbuseData,
                NonPathologicalHistory.RecentVaccination,
                NonPathologicalHistory.RecentVaccinationData,
                NonPathologicalHistory.Others,
                NonPathologicalHistory.OthersData,
                NonPathologicalHistory.DateTimeSnap),
                new PathologicalBackgroundDto(
                PathologicalBackground.Id,
                PathologicalBackground.IDPatient,
                PathologicalBackground.PreviousHospitalization,
                PathologicalBackground.PreviousSurgeries,
                PathologicalBackground.Diabetes,
                PathologicalBackground.ThyroidDiseases,
                PathologicalBackground.Hypertension,
                PathologicalBackground.Cardiopathies,
                PathologicalBackground.Trauma,
                PathologicalBackground.Cancer,
                PathologicalBackground.Tuberculosis,
                PathologicalBackground.Transfusions,
                PathologicalBackground.RespiratoryDiseases,
                PathologicalBackground.GastrointestinalDiseases,
                PathologicalBackground.STDs,
                PathologicalBackground.STDsData,
                PathologicalBackground.ChronicKidneyDisease,
                PathologicalBackground.Others,
                PathologicalBackground.DateTimeSnap),
                new PatientAllergiesDto(
                PatientAllergies.Id,
                PatientAllergies.IDPatient,
                PatientAllergies.Allergies,
                PatientAllergies.DateTimeSnap),
                new PsychiatricHistoryDto(
                PsychiatricHistory.id,
                PsychiatricHistory.IDPatient,
                PsychiatricHistory.FamilyHistory,
                PsychiatricHistory.FamilyHistoryData,
                PsychiatricHistory.AffectedAreas,
                PsychiatricHistory.PastAndCurrentTreatments,
                PsychiatricHistory.FamilySocialSupport,
                PsychiatricHistory.FamilySocialSupportData,
                PsychiatricHistory.WorkLifeAspects,
                PsychiatricHistory.SocialLifeAspects,
                PsychiatricHistory.AuthorityRelationship,
                PsychiatricHistory.ImpulseControl,
                PsychiatricHistory.FrustrationManagement,
                PsychiatricHistory.DateTimeSnap),
                Enumerable.Empty<PatientsFilesDto>(),
                Enumerable.Empty<MedicalAppointmentCalendarDto>());
            return new SuccessGetPatientDataAndAntecedentsResponse(patientDataAndAntecedents);

        }
    }
}
