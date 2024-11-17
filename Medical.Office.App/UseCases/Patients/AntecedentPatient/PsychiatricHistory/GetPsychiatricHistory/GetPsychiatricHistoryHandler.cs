using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.GetPsychiatricHistory
{
    public sealed class GetPsychiatricHistoryHandler : IInteractor<GetPsychiatricHistoryRequest,GetPsychiatricHistoryResponse>
    {
        private readonly ILogger<GetPsychiatricHistoryHandler> _logger;
        private readonly IAntecedentPatient _antecedent;

        public GetPsychiatricHistoryHandler(ILogger<GetPsychiatricHistoryHandler> logger, IAntecedentPatient antecedent)
        {
            _logger=logger;
            _antecedent=antecedent;
        }

        public async Task<GetPsychiatricHistoryResponse> Handle(GetPsychiatricHistoryRequest request, CancellationToken cancellationToken)
        {
            var PsychiatricHistory = await _antecedent.GetPsychiatricHistoryByPatientIdAsync(request.IdPatient).ConfigureAwait(false);

            if (PsychiatricHistory == null)
            {
                return new FailureGetPsychiatricHistoryResponse("No se encontro informacion para este paciente");
            }

            return new SuccessGetPsychiatricHistoryResponse(new PsychiatricHistoryDto(
                PsychiatricHistory.id,
                PsychiatricHistory.IDPatient,
                PsychiatricHistory.FamilyHistory,
                PsychiatricHistory.FamilyHistoryData,
                PsychiatricHistory.AffectedAreas,
                PsychiatricHistory.PastAndCurrentTreatments,
                PsychiatricHistory.FamilySocialSupport,
                PsychiatricHistory.FamilySocialSupportData,
                PsychiatricHistory.WorkLifeAspects,
                PsychiatricHistory.SocialLifeAspects,
                PsychiatricHistory.AuthorityRelationship,
                PsychiatricHistory.ImpulseControl,
                PsychiatricHistory.FrustrationManagement,
                PsychiatricHistory.DateTimeSnap));
        }
    }
}
