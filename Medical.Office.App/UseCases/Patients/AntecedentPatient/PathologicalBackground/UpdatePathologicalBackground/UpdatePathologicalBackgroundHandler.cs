using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.UpdatePathologicalBackground
{
    internal sealed class UpdatePathologicalBackgroundHandler : IInteractor<UpdatePathologicalBackgroundRequest, UpdatePathologicalBackgroundResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdatePathologicalBackgroundHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdatePathologicalBackgroundResponse> Handle(UpdatePathologicalBackgroundRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}