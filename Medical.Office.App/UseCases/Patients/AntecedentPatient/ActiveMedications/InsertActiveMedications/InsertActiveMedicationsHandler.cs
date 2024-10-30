using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
    internal sealed class InsertActiveMedicationsHandler : IInteractor<InsertActiveMedicationsRequest, InsertActiveMedicationsResponse>
    {
        private readonly IAntecedentPatient _patient;

        public InsertActiveMedicationsHandler(IAntecedentPatient patient)
        {
            _patient=patient;
        }

        public async Task<InsertActiveMedicationsResponse> Handle(InsertActiveMedicationsRequest request, CancellationToken cancellationToken)
        {
           await _patient.InsertActiveMedicationsAsync(request.IDPatient,request.ActiveMedicationsData);
           var GetLastActiveMedications = await _patient.GetActiveMedicationsByPatientIdAsync(request.IDPatient);
            if (GetLastActiveMedications == null) 
            { 
                return new FailureInsertActiveMedicationsResponse("Falla al agregar informacion del paciente");
            }
            if (!GetLastActiveMedications.IDPatient.Equals(request.IDPatient))
            {
                return new FailureInsertActiveMedicationsResponse("Error en obtener datos");
            }
            return new SuccessInsertActiveMedicationsResponse(new ActiveMedicationsDto(
                GetLastActiveMedications.Id,
                GetLastActiveMedications.IDPatient,
                GetLastActiveMedications.AactiveMedicationsData,
                GetLastActiveMedications.DateTimeSnap));
        }
    }
}
