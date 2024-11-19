using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground
{
    public sealed record GetPathologicalBackgroundRequest(long IdPatient) : IRequest<GetPathologicalBackgroundResponse>;
}
