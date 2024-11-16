namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.FamilyHistory.InsertFamilyHistory
{
    public sealed class InsertFamilyHistoryRequestBody
    {
        public long IDPatient { get; set; }
        public int? Diabetes { get; set; }
        public int? Cardiopathies { get; set; }
        public int? Hypertension { get; set; }
        public int? ThyroidDiseases { get; set; }
        public int? ChronicKidneyDisease { get; set; }
        public int? Others { get; set; }
        public string? OthersData { get; set; }
    }
}
