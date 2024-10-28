using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
    internal sealed class InsertActiveMedicationsHandler : IInteractor<InsertActiveMedicationsRequest, InsertActiveMedicationsResponse>
    {
        private readonly IAntecedentPatient _antecedentPatient;

        public InsertActiveMedicationsHandler(IAntecedentPatient antecedentPatient)
        {
            _antecedentPatient=antecedentPatient;
        }

        public async Task<InsertActiveMedicationsResponse> Handle(InsertActiveMedicationsRequest request, CancellationToken cancellationToken)
        {
            var ActiveMedications = new ActiveMedicationsDto(0,request.IDPatient,request.ActiveMedicationsData,DateTime.Now);
            await _antecedentPatient.InsertActiveMedicationsAsync(ActiveMedications.IDPatient, ActiveMedications.AactiveMedicationsData).ConfigureAwait(false);
            var GetLastActiveMedications = await _antecedentPatient.GetActiveMedicationsByPatientIdAsync(ActiveMedications.IDPatient);
            var SuccessGetLastActiveMedications = new ActiveMedicationsDto(GetLastActiveMedications.Id, GetLastActiveMedications.IDPatient, GetLastActiveMedications.AactiveMedicationsData, GetLastActiveMedications.DateTimeSnap);
            
            if (!Equals(ActiveMedications.IDPatient, GetLastActiveMedications.IDPatient))
                return new FailureInsertActiveMedicationsResponse("Hubo un error al insertar el paciente");
            else            
                return new SuccessInsertActiveMedicationsResponse(SuccessGetLastActiveMedications);
        }
    }
}
