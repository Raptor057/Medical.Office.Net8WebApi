namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground;

public class UpdatePathologicalBackgroundRequestBody
{
    public bool? PreviousHospitalization { get; set; }
    public bool? PreviousSurgeries { get; set; }
    public bool? Diabetes { get; set; }
    public bool? ThyroidDiseases { get; set; }
    public bool? Hypertension { get; set; }
    public bool? Cardiopathies { get; set; }
    public bool? Trauma { get; set; }
    public bool? Cancer { get; set; }
    public bool? Tuberculosis { get; set; }
    public bool? Transfusions { get; set; }
    public bool? RespiratoryDiseases { get; set; }
    public bool? GastrointestinalDiseases { get; set; }
    public bool? STDs { get; set; }
    public string? STDsData { get; set; }
    public bool? ChronicKidneyDisease { get; set; }
    public string? Others { get; set; }
}