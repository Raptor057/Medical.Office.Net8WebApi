using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies
{
    internal sealed class GetPatientAllergiesHandler : IInteractor<GetPatientAllergiesRequest,GetPatientAllergiesResponse>
    {
        private readonly ILogger<GetPatientAllergiesHandler> _logger;
        private readonly IAntecedentPatient _antecedent;

        public GetPatientAllergiesHandler(ILogger<GetPatientAllergiesHandler> logger, IAntecedentPatient antecedent)
        {
            _logger=logger;
            _antecedent=antecedent;
        }

        public async Task<GetPatientAllergiesResponse> Handle(GetPatientAllergiesRequest request, CancellationToken cancellationToken)
        {

            var GetPatientAllergies = await _antecedent.GetPatientAllergiesByPatientIdAsync(request.IdPatient).ConfigureAwait(false);

            if (GetPatientAllergies == null)
            {
                return new FailureGetPatientAllergiesResponse("No se encontro informacion para este paciente");
            }

            return new SuccessGetPatientAllergiesResponse(new PatientAllergiesDto(
                GetPatientAllergies.Id,
                GetPatientAllergies.IDPatient,
                GetPatientAllergies.Allergies,
                GetPatientAllergies.DateTimeSnap));
        }
    }
}
