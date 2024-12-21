using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications;

internal sealed class UpdateActiveMedicationsHandler : IInteractor<UpdateActiveMedicationsRequest, UpdateActiveMedicationsResponse>
{
    private readonly IAntecedentPatient _patient;
    private readonly IPatientsData _patients;

    public UpdateActiveMedicationsHandler(IAntecedentPatient patient, IPatientsData patients)
    {
        _patient = patient;
        _patients = patients;
    }
    public async Task<UpdateActiveMedicationsResponse> Handle(UpdateActiveMedicationsRequest request, CancellationToken cancellationToken)
    {
        var data = request.activeMedications;

        await _patient.UpdateActiveMedicationsAsync(data.IDPatient,data.ActiveMedicationsData,DateTime.Now).ConfigureAwait(false);
        var patient = await _patients.GetPatientDataByIDPatientAsync(data.IDPatient).ConfigureAwait(false);
        var  Patientdata = new ActiveMedicationsDto
        (
            data.Id,
            data.IDPatient,
            data.ActiveMedicationsData,
            data.DateTimeSnap
        );
        return new SuccessUpdateActiveMedicationsResponse(Patientdata);
    }
}