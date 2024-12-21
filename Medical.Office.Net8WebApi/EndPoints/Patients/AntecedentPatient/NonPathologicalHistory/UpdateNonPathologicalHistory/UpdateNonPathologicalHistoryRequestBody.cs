namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory;

public class UpdateNonPathologicalHistoryRequestBody
{
    public bool? PhysicalActivity { get; set; }
    public bool? Smoking { get; set; }
    public bool? Alcoholism { get; set; }
    public bool? SubstanceAbuse { get; set; }
    public string? SubstanceAbuseData { get; set; }
    public bool? RecentVaccination { get; set; }
    public string? RecentVaccinationData { get; set; }
    public bool? Others { get; set; }
    public string? OthersData { get; set; }
}