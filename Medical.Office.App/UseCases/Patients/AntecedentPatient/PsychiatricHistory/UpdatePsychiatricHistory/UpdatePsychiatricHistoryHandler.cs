using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory.Response;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.UpdatePsychiatricHistory
{
    internal sealed class UpdatePsychiatricHistoryHandler : IInteractor<UpdatePsychiatricHistoryRequest, UpdatePsychiatricHistoryResponse>
    {
        private readonly IAntecedentPatient _patient;
        private readonly IPatientsData _patients;

        public UpdatePsychiatricHistoryHandler(IAntecedentPatient patient, IPatientsData patients)
        {
            _patient = patient;
            _patients = patients;
        }

        public async Task<UpdatePsychiatricHistoryResponse> Handle(UpdatePsychiatricHistoryRequest request, CancellationToken cancellationToken)
        {
            var data = request.PsychiatricHistory;

            await _patient.UpdatePsychiatricHistoryAsync(
                data.IDPatient,
                data.FamilyHistory.HasValue ? (data.FamilyHistory.Value ? 1 : 0) : 0,
                data.FamilyHistoryData ?? string.Empty,
                data.AffectedAreas ?? string.Empty,
                data.PastAndCurrentTreatments ?? string.Empty,
                data.FamilySocialSupport.HasValue ? (data.FamilySocialSupport.Value ? 1 : 0) : 0,
                data.FamilySocialSupportData ?? string.Empty,
                data.WorkLifeAspects ?? string.Empty,
                data.SocialLifeAspects ?? string.Empty,
                data.AuthorityRelationship ?? string.Empty,
                data.ImpulseControl ?? string.Empty,
                data.FrustrationManagement ?? string.Empty,
                DateTime.UtcNow
            ).ConfigureAwait(false);

            var patient = await _patients.GetPatientDataByIDPatientAsync(data.IDPatient).ConfigureAwait(false);

            if (patient == null)
            {
                return new FailureUpdatePsychiatricHistoryResponse("Patient not found");
            }

            var updatedData = new PsychiatricHistoryDto
            (
                data.Id,
                data.IDPatient,
                data.FamilyHistory,
                data.FamilyHistoryData,
                data.AffectedAreas,
                data.PastAndCurrentTreatments,
                data.FamilySocialSupport,
                data.FamilySocialSupportData,
                data.WorkLifeAspects,
                data.SocialLifeAspects,
                data.AuthorityRelationship,
                data.ImpulseControl,
                data.FrustrationManagement,
                data.DateTimeSnap
            );
            return new SuccessUpdatePsychiatricHistoryResponse(updatedData);
        }
    }
}