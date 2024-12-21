using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory
{
    internal sealed class UpdateNonPathologicalHistoryHandler : IInteractor<UpdateNonPathologicalHistoryRequest, UpdateNonPathologicalHistoryResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdateNonPathologicalHistoryHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdateNonPathologicalHistoryResponse> Handle(UpdateNonPathologicalHistoryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}