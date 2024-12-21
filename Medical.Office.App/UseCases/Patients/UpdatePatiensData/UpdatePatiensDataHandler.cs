using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.UpdatePatiensData.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.UpdatePatiensData
{
    internal sealed class UpdatePatiensDataHandler : IInteractor<UpdatePatiensDataRequest, UpdatePatiensDataResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdatePatiensDataHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdatePatiensDataResponse> Handle(UpdatePatiensDataRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}