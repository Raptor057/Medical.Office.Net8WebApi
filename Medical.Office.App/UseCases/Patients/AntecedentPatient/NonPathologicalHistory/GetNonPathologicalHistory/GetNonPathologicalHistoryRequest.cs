using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.GetNonPathologicalHistory
{
    internal sealed class GetNonPathologicalHistoryRequest : IRequest<GetNonPathologicalHistoryResponse>
    {
        public GetNonPathologicalHistoryRequest()
        {
            
        }
        public long IdPatient {  get; set; }
    }
}
