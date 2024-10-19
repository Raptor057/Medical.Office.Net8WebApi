using Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient;

namespace Medical.Office.Domain.Repository
{
    public interface IAntecedentPatient
    {
        #region ActiveMedications
        // Insert
        Task InsertActiveMedicationsAsync(long IDPatient, string AactiveMedicationsData);

        // Get
        Task<ActiveMedications> GetActiveMedicationsByPatientIdAsync(long IDPatient);

        // Update
        Task UpdateActiveMedicationsAsync(long IDPatient, string AactiveMedicationsData, DateTime? DateTimeSnap);
        #endregion

        #region FamilyHistory
        // Insert
        Task InsertFamilyHistoryAsync(long IDPatient, int Diabetes, int Cardiopathies, int Hypertension,
            int ThyroidDiseases, int ChronicKidneyDisease, int Others, string OthersData);

        // Get
        Task<FamilyHistory> GetFamilyHistoryByPatientIdAsync(long IDPatient);

        // Update
        Task UpdateFamilyHistoryAsync(long IDPatient, int Diabetes, int Cardiopathies, int Hypertension,
            int ThyroidDiseases, int ChronicKidneyDisease, int Others, string OthersData, DateTime? DateTimeSnap);
        #endregion

        #region MedicalHistoryNotes
        // Insert
        Task InsertMedicalHistoryNotesAsync(long IDPatient, string MedicalHistoryNotesData);

        // Get
        Task<MedicalHistoryNotes> GetMedicalHistoryNotesByPatientIdAsync(long IDPatient);

        // Update
        Task UpdateMedicalHistoryNotesAsync(long IDPatient, string MedicalHistoryNotesData, DateTime? DateTimeSnap);
        #endregion

        #region NonPathologicalHistory
        // Insert
        Task InsertNonPathologicalHistoryAsync(long IDPatient, int PhysicalActivity, int Smoking, int Alcoholism,
            int SubstanceAbuse, string SubstanceAbuseData, int RecentVaccination, string RecentVaccinationData,
            int Others, string OthersData);

        // Get
        Task<NonPathologicalHistory> GetNonPathologicalHistoryByPatientIdAsync(long IDPatient);

        // Update
        Task UpdateNonPathologicalHistoryAsync(long IDPatient, int PhysicalActivity, int Smoking, int Alcoholism,
            int SubstanceAbuse, string SubstanceAbuseData, int RecentVaccination, string RecentVaccinationData,
            int Others, string OthersData, DateTime? DateTimeSnap);
        #endregion

        #region PathologicalBackground
        // Insert
        Task InsertPathologicalBackgroundAsync(long IDPatient, int PreviousHospitalization, int PreviousSurgeries,
            int Diabetes, int ThyroidDiseases, int Hypertension, int Cardiopathies, int Trauma,
            int Cancer, int Tuberculosis, int Transfusions, int RespiratoryDiseases,
            int GastrointestinalDiseases, int STDs, string STDsData, int ChronicKidneyDisease,
            string Others);

        // Get
        Task<PathologicalBackground> GetPathologicalBackgroundByPatientIdAsync(long IDPatient);

        // Update
        Task UpdatePathologicalBackgroundAsync(long IDPatient, int PreviousHospitalization, int PreviousSurgeries,
            int Diabetes, int ThyroidDiseases, int Hypertension, int Cardiopathies, int Trauma,
            int Cancer, int Tuberculosis, int Transfusions, int RespiratoryDiseases,
            int GastrointestinalDiseases, int STDs, string STDsData, int ChronicKidneyDisease,
            string Others, DateTime? DateTimeSnap);
        #endregion

        #region PatientAllergies
        // Insert
        Task InsertPatientAllergiesAsync(long IDPatient, string Allergies);

        // Get
        Task<PatientAllergies> GetPatientAllergiesByPatientIdAsync(long IDPatient);

        // Update
        Task UpdatePatientAllergiesAsync(long IDPatient, string Allergies, DateTime? DateTimeSnap);
        #endregion

        #region PsychiatricHistory
        // Insert
        Task InsertPsychiatricHistoryAsync(long IDPatient, int FamilyHistory, string FamilyHistoryData,
            string AffectedAreas, string PastAndCurrentTreatments, int FamilySocialSupport,
            string FamilySocialSupportData, string WorkLifeAspects, string SocialLifeAspects,
            string AuthorityRelationship, string ImpulseControl, string FrustrationManagement);

        // Get
        Task<PsychiatricHistory> GetPsychiatricHistoryByPatientIdAsync(long IDPatient);

        // Update
        Task UpdatePsychiatricHistoryAsync(long IDPatient, int FamilyHistory, string FamilyHistoryData,
            string AffectedAreas, string PastAndCurrentTreatments, int FamilySocialSupport,
            string FamilySocialSupportData, string WorkLifeAspects, string SocialLifeAspects,
            string AuthorityRelationship, string ImpulseControl, string FrustrationManagement, DateTime? DateTimeSnap);
        #endregion
    }
}
