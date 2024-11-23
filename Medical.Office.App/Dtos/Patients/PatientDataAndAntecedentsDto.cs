using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PathologicalBackground;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory;

namespace Medical.Office.App.Dtos.Patients
{
    public record PatientDataAndAntecedentsDto(
        GetPatientsDto PatientsData,
        ActiveMedicationsDto ActiveMedications,
        FamilyHistoryDto FamilyHistory,
        MedicalHistoryNotesDto MedicalHistoryNotes,
        NonPathologicalHistoryDto NonPathologicalHistory,
        PathologicalBackgroundDto PathologicalBackground,
        PatientAllergiesDto PatientAllergies,
        PsychiatricHistoryDto PsychiatricHistory,
        IEnumerable<PatientsFilesDto> PatientsFilesList,
        IEnumerable<MedicalAppointmentCalendarDto> MedicalAppointments
        );
}
