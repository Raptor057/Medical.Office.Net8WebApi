using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies
{
    public sealed record GetPatientAllergiesRequest(long IdPatient) : IRequest<GetPatientAllergiesResponse>;
}
