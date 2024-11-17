using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies
{
    public sealed record InsertPatientAllergiesRequest(long IDPatient,
        string Allergies) : IRequest<InsertPatientAllergiesResponse>;
}
