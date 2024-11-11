using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications
{
    public sealed class GetActiveMedicationsRequest : IRequest<GetActiveMedicationsResponse>
    {
        public GetActiveMedicationsRequest() { }
        public long PatientID { get; set; }
    }
}
