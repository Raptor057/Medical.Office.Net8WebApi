using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PsychiatricHistory;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PsychiatricHistory.InsertPsychiatricHistory
{
    public sealed class InsertPsychiatricHistoryHandler : IInteractor<InsertPsychiatricHistoryRequest, InsertPsychiatricHistoryResponse>
    {
        private readonly ILogger<InsertPsychiatricHistoryHandler> _logger;
        private readonly IAntecedentPatient _antecedent;
        private readonly IPatientsData _patients;

        public InsertPsychiatricHistoryHandler(ILogger<InsertPsychiatricHistoryHandler> logger, IAntecedentPatient antecedent, IPatientsData patients)
        {
            _logger=logger;
            _antecedent=antecedent;
            _patients=patients;
        }
        public async Task<InsertPsychiatricHistoryResponse> Handle(InsertPsychiatricHistoryRequest request, CancellationToken cancellationToken)
        {
            var PsychiatricHistory = await _antecedent.GetPsychiatricHistoryByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            var PatientsData = await _patients.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);

            if (PatientsData == null || !Equals(request.IDPatient, PatientsData.ID) || string.IsNullOrEmpty(Convert.ToString(request.IDPatient)))
            {
                return new FailureInsertPsychiatricHistoryResponse ($"No se encontro al paciente {request.IDPatient} o no es valido con el registo que se quiere ingresar");
            }

            if (PsychiatricHistory != null)
            {
                return new FailureInsertPsychiatricHistoryResponse("Este paciente ya cuenta con este registro");
            }

            await _antecedent.InsertPsychiatricHistoryAsync(
                request.IDPatient,
                ConvertBoolToInt(request.FamilyHistory),
                request.FamilyHistoryData,
                request.AffectedAreas,
                request.PastAndCurrentTreatments,
                ConvertBoolToInt(request.FamilySocialSupport),
                request.FamilySocialSupportData,
                request.WorkLifeAspects,
                request.SocialLifeAspects,
                request.AuthorityRelationship,
                request.ImpulseControl,
                request.FrustrationManagement
                ).ConfigureAwait(false);

            PsychiatricHistory = await _antecedent.GetPsychiatricHistoryByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            return new SuccessInsertPsychiatricHistoryResponse(new PsychiatricHistoryDto(
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
        private static int? ConvertBoolToInt(bool? value)
        {
            return value.HasValue ? (value.Value ? 1 : 0) : (int?)null;
        }
    }
}
