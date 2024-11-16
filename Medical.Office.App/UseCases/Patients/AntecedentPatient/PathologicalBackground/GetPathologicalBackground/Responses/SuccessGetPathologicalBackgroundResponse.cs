using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PathologicalBackground;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground.Responses
{
    public record SuccessGetPathologicalBackgroundResponse(PathologicalBackgroundDto PathologicalBackground) : GetPathologicalBackgroundResponse, ISuccess;
}
