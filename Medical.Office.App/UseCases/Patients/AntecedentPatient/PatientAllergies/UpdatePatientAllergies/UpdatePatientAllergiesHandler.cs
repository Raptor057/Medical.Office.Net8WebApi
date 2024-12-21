using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies
{
    internal sealed class UpdatePatientAllergiesHandler : IInteractor<UpdatePatientAllergiesRequest, UpdatePatientAllergiesResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdatePatientAllergiesHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdatePatientAllergiesResponse> Handle(UpdatePatientAllergiesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}