using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory
{
    //public sealed class GetNonPathologicalHistoryRequest : IRequest<GetNonPathologicalHistoryResponse>
    //{
    //    public GetNonPathologicalHistoryRequest()
    //    {

    //    }
    //    public long IdPatient {  get; set; }
    //}
    public sealed record GetNonPathologicalHistoryRequest(long IdPatient) : IRequest<GetNonPathologicalHistoryResponse>;
}
