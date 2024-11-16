using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground.Responses;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground
{
    internal sealed class GetPathologicalBackgroundRequest : IRequest<GetPathologicalBackgroundResponse>
    {
        public GetPathologicalBackgroundRequest()
        {
            
        }
        public long IdPatient { get; set; }

    }
}
