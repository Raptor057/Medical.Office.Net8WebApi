using Medical.Office.App.Dtos.Patients.AntecedentPatient.PathologicalBackground;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground.Responses
{
    public record SuccessInsertPathologicalBackgroundResponse(PathologicalBackgroundDto pathologicalBackgroundDto) : InsertPathologicalBackgroundResponse;
}
