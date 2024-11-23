using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.GetPatientDataAndAntecedents.Responses;

namespace Medical.Office.App.UseCases.Patients.GetPatientDataAndAntecedents
{
    public sealed record GetPatientDataAndAntecedentsRequest(long IdPatient) : IRequest<GetPatientDataAndAntecedentsResponse>;
   
}
