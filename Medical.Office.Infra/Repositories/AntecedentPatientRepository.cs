using Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;

namespace Medical.Office.Infra.Repositories
{
    internal class AntecedentPatientRepository : IAntecedentPatient
    {
        private readonly MedicalOfficeSqlLocalDB _db;

        public AntecedentPatientRepository(MedicalOfficeSqlLocalDB db)
        {
            _db = db;
        }

        #region Get
        public async Task<ActiveMedications> GetActiveMedicationsByPatientIdAsync(long IDPatient)
            => await _db.GetActiveMedicationsByIDPatient(IDPatient);

        public async Task<FamilyHistory> GetFamilyHistoryByPatientIdAsync(long IDPatient)
            => await _db.GetFamilyHistoryByIDPatient(IDPatient);

        public async Task<MedicalHistoryNotes> GetMedicalHistoryNotesByPatientIdAsync(long IDPatient)
            => await _db.GetMedicalHistoryNotesByIDPatient(IDPatient);

        public async Task<NonPathologicalHistory> GetNonPathologicalHistoryByPatientIdAsync(long IDPatient)
            => await _db.GetNonPathologicalHistoryByIDPatient(IDPatient);

        public async Task<PathologicalBackground> GetPathologicalBackgroundByPatientIdAsync(long IDPatient)
            => await _db.GetPathologicalBackgroundByIDPatient(IDPatient);

        public async Task<PatientAllergies> GetPatientAllergiesByPatientIdAsync(long IDPatient)
            => await _db.GetPatientAllergiesByIDPatient(IDPatient);

        public async Task<PsychiatricHistory> GetPsychiatricHistoryByPatientIdAsync(long IDPatient)
            => await _db.GetPsychiatricHistoryByIDPatient(IDPatient);
        #endregion

        #region Insert
        public async Task InsertActiveMedicationsAsync(long IDPatient, string AactiveMedicationsData)
            => await _db.InsertActiveMedications(IDPatient, AactiveMedicationsData);

        public async Task InsertFamilyHistoryAsync(long IDPatient, int? Diabetes, int? Cardiopathies, int? Hypertension,
            int? ThyroidDiseases, int? ChronicKidneyDisease, int? Others, string? OthersData)
            => await _db.InsertFamilyHistory(IDPatient, Diabetes, Cardiopathies, Hypertension,
                ThyroidDiseases, ChronicKidneyDisease, Others, OthersData);

        public async Task InsertMedicalHistoryNotesAsync(long IDPatient, string MedicalHistoryNotesData)
            => await _db.InsertMedicalHistoryNotes(IDPatient, MedicalHistoryNotesData);

        public async Task InsertNonPathologicalHistoryAsync(long IDPatient, int? PhysicalActivity, int? Smoking, int? Alcoholism,
            int? SubstanceAbuse, string? SubstanceAbuseData, int? RecentVaccination, string? RecentVaccinationData,
            int? Others, string? OthersData)
            => await _db.InsertNonPathologicalHistory(IDPatient, PhysicalActivity, Smoking, Alcoholism,
                SubstanceAbuse, SubstanceAbuseData, RecentVaccination, RecentVaccinationData, Others, OthersData);

        public async Task InsertPathologicalBackgroundAsync(long IDPatient, int? PreviousHospitalization, int? PreviousSurgeries,
            int? Diabetes, int? ThyroidDiseases, int? Hypertension, int? Cardiopathies, int? Trauma,
            int? Cancer, int? Tuberculosis, int? Transfusions, int? RespiratoryDiseases,
            int? GastrointestinalDiseases, int? STDs, string? STDsData, int? ChronicKidneyDisease,
            string? Others)
            => await _db.InsertPathologicalBackground(IDPatient, PreviousHospitalization, PreviousSurgeries,
                Diabetes, ThyroidDiseases, Hypertension, Cardiopathies, Trauma, Cancer, Tuberculosis,
                Transfusions, RespiratoryDiseases, GastrointestinalDiseases, STDs, STDsData, ChronicKidneyDisease,
                Others);

        public async Task InsertPatientAllergiesAsync(long IDPatient, string Allergies)
            => await _db.InsertPatientAllergies(IDPatient, Allergies);

        public async Task InsertPsychiatricHistoryAsync(long IDPatient, int? FamilyHistory, string? FamilyHistoryData,
            string? AffectedAreas, string? PastAndCurrentTreatments, int? FamilySocialSupport,
            string? FamilySocialSupportData, string? WorkLifeAspects, string? SocialLifeAspects,
            string? AuthorityRelationship, string? ImpulseControl, string? FrustrationManagement)
            => await _db.InsertPsychiatricHistory(IDPatient, FamilyHistory, FamilyHistoryData,
                AffectedAreas, PastAndCurrentTreatments, FamilySocialSupport, FamilySocialSupportData,
                WorkLifeAspects, SocialLifeAspects, AuthorityRelationship, ImpulseControl,
                FrustrationManagement);
        #endregion

        #region Update
        public async Task UpdateActiveMedicationsAsync(long IDPatient, string AactiveMedicationsData, DateTime? DateTimeSnap)
            => await _db.UpdateActiveMedications(IDPatient, AactiveMedicationsData, DateTimeSnap);

        public async Task UpdateFamilyHistoryAsync(long IDPatient, int Diabetes, int Cardiopathies, int Hypertension,
            int ThyroidDiseases, int ChronicKidneyDisease, int Others, string OthersData, DateTime? DateTimeSnap)
            => await _db.UpdateFamilyHistory(IDPatient, Diabetes, Cardiopathies, Hypertension,
                ThyroidDiseases, ChronicKidneyDisease, Others, OthersData, DateTimeSnap);

        public async Task UpdateMedicalHistoryNotesAsync(long IDPatient, string MedicalHistoryNotesData, DateTime? DateTimeSnap)
            => await _db.UpdateMedicalHistoryNotes(IDPatient, MedicalHistoryNotesData, DateTimeSnap);

        public async Task UpdateNonPathologicalHistoryAsync(long IDPatient, int PhysicalActivity, int Smoking, int Alcoholism,
            int SubstanceAbuse, string SubstanceAbuseData, int RecentVaccination, string RecentVaccinationData,
            int Others, string OthersData, DateTime? DateTimeSnap)
            => await _db.UpdateNonPathologicalHistory(IDPatient, PhysicalActivity, Smoking, Alcoholism,
                SubstanceAbuse, SubstanceAbuseData, RecentVaccination, RecentVaccinationData, Others, OthersData, DateTimeSnap);

        public async Task UpdatePathologicalBackgroundAsync(long IDPatient, int PreviousHospitalization, int PreviousSurgeries,
            int Diabetes, int ThyroidDiseases, int Hypertension, int Cardiopathies, int Trauma,
            int Cancer, int Tuberculosis, int Transfusions, int RespiratoryDiseases,
            int GastrointestinalDiseases, int STDs, string STDsData, int ChronicKidneyDisease,
            string Others, DateTime? DateTimeSnap)
            => await _db.UpdatePathologicalBackground(IDPatient, PreviousHospitalization, PreviousSurgeries,
                Diabetes, ThyroidDiseases, Hypertension, Cardiopathies, Trauma, Cancer, Tuberculosis,
                Transfusions, RespiratoryDiseases, GastrointestinalDiseases, STDs, STDsData,
                ChronicKidneyDisease, Others, DateTimeSnap);

        public async Task UpdatePatientAllergiesAsync(long IDPatient, string Allergies, DateTime? DateTimeSnap)
            => await _db.UpdatePatientAllergies(IDPatient, Allergies, DateTimeSnap);

        public async Task UpdatePsychiatricHistoryAsync(long IDPatient, int FamilyHistory, string FamilyHistoryData,
            string AffectedAreas, string PastAndCurrentTreatments, int FamilySocialSupport,
            string FamilySocialSupportData, string WorkLifeAspects, string SocialLifeAspects,
            string AuthorityRelationship, string ImpulseControl, string FrustrationManagement, DateTime? DateTimeSnap)
            => await _db.UpdatePsychiatricHistory(IDPatient, FamilyHistory, FamilyHistoryData,
                AffectedAreas, PastAndCurrentTreatments, FamilySocialSupport, FamilySocialSupportData,
                WorkLifeAspects, SocialLifeAspects, AuthorityRelationship, ImpulseControl,
                FrustrationManagement, DateTimeSnap);
        #endregion
    }
}
