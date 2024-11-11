using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications
{
    internal sealed class GetActiveMedicationsHandler : IInteractor<GetActiveMedicationsRequest,GetActiveMedicationsResponse>
    {
        private readonly ILogger<GetActiveMedicationsHandler> _logger;
        private readonly IAntecedentPatient _antecedentpatient;
        private readonly IPatientsData _patient;

        public GetActiveMedicationsHandler( ILogger<GetActiveMedicationsHandler> logger,IAntecedentPatient antecedentpatient, IPatientsData patient) 
        {
            _logger=logger;
            _antecedentpatient = antecedentpatient;
            _patient = patient;
        }

        public async Task<GetActiveMedicationsResponse> Handle(GetActiveMedicationsRequest request, CancellationToken cancellationToken)
        {
            var Patient = await _patient.GetPatientDataByIDPatientAsync(request.PatientID).ConfigureAwait(false);

            if (Patient == null) 
            {
                return new FailureGetActiveMedicationsResponse("No se puede agregar registro a este paciente ya que no existe");
            }

            var ActiveMedications = await _antecedentpatient.GetActiveMedicationsByPatientIdAsync(request.PatientID).ConfigureAwait(false);

            if (ActiveMedications == null) 
            {
                return new FailureGetActiveMedicationsResponse("No se encontro informacion de medicamentos activos para este paciente");
            }

            var ActiveMedicationsDto = new ActiveMedicationsDto
                (
                    ActiveMedications.Id,
                    ActiveMedications.IDPatient,
                    ActiveMedications.ActiveMedicationsData,
                    ActiveMedications.DateTimeSnap
                );

            return new SuccessGetActiveMedicationsResponse(ActiveMedicationsDto);
        }
    }
}
