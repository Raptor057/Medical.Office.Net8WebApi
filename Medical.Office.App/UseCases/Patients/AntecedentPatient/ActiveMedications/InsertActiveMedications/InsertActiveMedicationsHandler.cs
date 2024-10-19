using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
    internal sealed class InsertActiveMedicationsHandler : IInteractor<InsertActiveMedicationsRequest, InsertActiveMedicationsResponse>
    {
        public InsertActiveMedicationsHandler()
        {
            
        }

        public async Task<InsertActiveMedicationsResponse> Handle(InsertActiveMedicationsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
