using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
    internal sealed class InsertActiveMedicationsHandler : IInteractor<InsertActiveMedicationsRequest, InsertActiveMedicationsResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patientsData;

        public InsertActiveMedicationsHandler(IAntecedentPatient patient, IPatientsData patientsData)
        {
            _patient=patient;
            _patientsData=patientsData;
        }

        public async Task<InsertActiveMedicationsResponse> Handle(InsertActiveMedicationsRequest request, CancellationToken cancellationToken)
        {
           var GetPatient = await _patientsData.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
            if (GetPatient == null)
            {
                return new FailureInsertActiveMedicationsResponse("No se puede agregar informacion a este paciente debido a que no esta dado de alta");
            }

           var GetLastActiveMedications = await _patient.GetActiveMedicationsByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            if (GetLastActiveMedications == null)
            {
                await _patient.InsertActiveMedicationsAsync(request.IDPatient, request.ActiveMedicationsData).ConfigureAwait(false);
            }
            else if (GetLastActiveMedications.IDPatient.Equals(request.IDPatient))
            {
                return new FailureInsertActiveMedicationsResponse($"El paciente {GetPatient.Name} {GetPatient.FathersSurname} con numero {GetPatient.ID} ya cuenta con este registro del dia {GetLastActiveMedications.DateTimeSnap}");
            }
            else
            {
                await _patient.InsertActiveMedicationsAsync(request.IDPatient, request.ActiveMedicationsData).ConfigureAwait(false);

            }

            GetLastActiveMedications = await _patient.GetActiveMedicationsByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            return new SuccessInsertActiveMedicationsResponse(new ActiveMedicationsDto(
                GetLastActiveMedications.Id,
                GetLastActiveMedications.IDPatient,
                GetLastActiveMedications.ActiveMedicationsData,
                GetLastActiveMedications.DateTimeSnap));
        }
    }
}
