using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.GetFamilyHistory
{
    public sealed class GetFamilyHistoryRequest : IRequest<GetFamilyHistoryResponse>
    {
        public GetFamilyHistoryRequest() { }
        public long IdPatient { get; set; }
    }
}
