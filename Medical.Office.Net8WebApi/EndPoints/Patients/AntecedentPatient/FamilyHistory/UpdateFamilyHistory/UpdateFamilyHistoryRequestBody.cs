namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.FamilyHistory.UpdateFamilyHistory;

public class UpdateFamilyHistoryRequestBody
{
    public bool? Diabetes { get; set; }
    public bool? Cardiopathies { get; set; }
    public bool? Hypertension { get; set; }
    public bool? ThyroidDiseases { get; set; }
    public bool? ChronicKidneyDisease { get; set; }
    public bool? Others { get; set; }
    public string? OthersData { get; set; }
}