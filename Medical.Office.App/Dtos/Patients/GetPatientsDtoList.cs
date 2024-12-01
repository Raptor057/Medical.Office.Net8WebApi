namespace Medical.Office.App.Dtos.Patients
{
    public record  GetPatientsDtoList(IEnumerable<GetPatientsDto> GetPatientsDtolist);

    public record  GetShortPatientsDtoList(IEnumerable<GetShortPatientsDto> GetShortPatientsDtolist);

}
