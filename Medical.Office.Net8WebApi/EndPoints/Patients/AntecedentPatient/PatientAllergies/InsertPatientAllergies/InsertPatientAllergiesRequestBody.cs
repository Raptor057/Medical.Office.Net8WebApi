namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies
{
    public class InsertPatientAllergiesRequestBody
    {
        public long IDPatient { get; set; }
        public string? Allergies { get; set; }
    }
}
