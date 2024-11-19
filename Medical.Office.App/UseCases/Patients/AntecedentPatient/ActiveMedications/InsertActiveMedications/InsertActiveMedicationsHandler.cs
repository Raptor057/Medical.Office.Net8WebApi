using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
    internal sealed class InsertActiveMedicationsHandler : IInteractor<InsertActiveMedicationsRequest, InsertActiveMedicationsResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public InsertActiveMedicationsHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient=patient;
            _patients=patients;
        }

        public async Task<InsertActiveMedicationsResponse> Handle(InsertActiveMedicationsRequest request, CancellationToken cancellationToken)
        {
            var PatientsData = await _patients.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);

            if (PatientsData == null || !Equals(request.IDPatient, PatientsData.ID) || string.IsNullOrEmpty(Convert.ToString(request.IDPatient)))
            {
                return new FailureInsertActiveMedicationsResponse ($"No se encontro al paciente {request.IDPatient} o no es valido con el registo que se quiere ingresar");
            }

            var GetLastActiveMedications = await _patient.GetActiveMedicationsByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            if (GetLastActiveMedications == null)
            {
                await _patient.InsertActiveMedicationsAsync(request.IDPatient, request.ActiveMedicationsData).ConfigureAwait(false);
            }
            else if (GetLastActiveMedications.IDPatient.Equals(request.IDPatient))
            {
                return new FailureInsertActiveMedicationsResponse($"El paciente {PatientsData.Name} {PatientsData.FathersSurname} con numero {PatientsData.ID} ya cuenta con este registro del dia {GetLastActiveMedications.DateTimeSnap}");
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
