using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory
{
    internal sealed class UpdatePsychiatricHistoryHandler : IInteractor<UpdatePsychiatricHistoryRequest, UpdatePsychiatricHistoryResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdatePsychiatricHistoryHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdatePsychiatricHistoryResponse> Handle(UpdatePsychiatricHistoryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}