using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies
{
    public sealed class GetPatientAllergiesRequest : IRequest<GetPatientAllergiesResponse>
    {
        public GetPatientAllergiesRequest()
        { }
        public long IdPatient { get; set; }
    }
}
