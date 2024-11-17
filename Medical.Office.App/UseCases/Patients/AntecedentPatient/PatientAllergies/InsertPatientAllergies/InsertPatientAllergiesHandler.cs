using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.GetPatientAllergies.Responses;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.InsertPatientAllergies
{
    internal sealed class InsertPatientAllergiesHandler : IInteractor<InsertPatientAllergiesRequest,InsertPatientAllergiesResponse>
    {
        private readonly ILogger<InsertPatientAllergiesHandler> _logger;
        private readonly IAntecedentPatient _antecedent;

        public InsertPatientAllergiesHandler(ILogger<InsertPatientAllergiesHandler> logger, IAntecedentPatient antecedent)
        {
            _logger=logger;
            _antecedent=antecedent;
        }

        public async Task<InsertPatientAllergiesResponse> Handle(InsertPatientAllergiesRequest request, CancellationToken cancellationToken)
        {
            var PatientAllergies = await _antecedent.GetPatientAllergiesByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            if (PatientAllergies != null)
            {
                return new FailureInsertPatientAllergiesResponse("Este paciente ya cuenta con un registo");
            }

            await _antecedent.InsertPatientAllergiesAsync(
                request.IDPatient,
                request.Allergies
                ).ConfigureAwait(false);
            
            PatientAllergies = await _antecedent.GetPatientAllergiesByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            return new SuccessInsertPatientAllergiesResponse(new PatientAllergiesDto(
                PatientAllergies.Id,
                PatientAllergies.IDPatient,
                PatientAllergies.Allergies,
                PatientAllergies.DateTimeSnap));
        }
    }
}
