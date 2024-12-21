using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications;

internal sealed class UpdateActiveMedicationsHandler : IInteractor<UpdateActiveMedicationsRequest, UpdateActiveMedicationsResponse>
{
    public UpdateActiveMedicationsHandler(IAntecedentPatient AntecedentPatient, IPatientsData PatientsData)
    {
        
    }
    public Task<UpdateActiveMedicationsResponse> Handle(UpdateActiveMedicationsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}