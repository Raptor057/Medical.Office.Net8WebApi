using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies
{
    internal sealed class UpdatePatientAllergiesHandler : IInteractor<UpdatePatientAllergiesRequest, UpdatePatientAllergiesResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdatePatientAllergiesHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdatePatientAllergiesResponse> Handle(UpdatePatientAllergiesRequest request, CancellationToken cancellationToken)
        {
            var data = request.PatientAllergies;

            await _patient.UpdatePatientAllergiesAsync(
                data.IDPatient,
                data.Allergies ?? string.Empty,
                DateTime.Now
            ).ConfigureAwait(false);

            var patient = await _patients.GetPatientDataByIDPatientAsync(data.IDPatient).ConfigureAwait(false);

            if (patient == null)
            {
                return new FailureUpdatePatientAllergiesResponse("Patient not found");
            }

            var updatedData = new PatientAllergiesDto
            (
                data.Id,
                data.IDPatient,
                data.Allergies,
                data.DateTimeSnap
            );
            
            return new SuccessUpdatePatientAllergiesResponse(updatedData);
        }
    }
}