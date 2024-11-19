namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes
{
    public class InsertMedicalHistoryNotesRequestBody
    {
        public long IDPatient { get; set; }
        public string? MedicalHistoryNotesData { get; set; }
    }
}
