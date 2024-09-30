using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.GetPatientDataList.Responses;

namespace Medical.Office.App.UseCases.Patients.GetPatientDataList
{
    public sealed class GetPatientDataListRequest : IRequest<GetPatientDataListResponse>
    {
        public GetPatientDataListRequest()
        {
            
        }
        public long IDPatient {  get; set; }
    }
}
