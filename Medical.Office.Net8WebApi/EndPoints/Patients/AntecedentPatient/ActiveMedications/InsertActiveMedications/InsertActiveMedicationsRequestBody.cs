namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
    public class InsertActiveMedicationsRequestBody
    {
        public long IDPatient { get; set; }
        public string ActiveMedicationsData { get; set; }
    }
}
