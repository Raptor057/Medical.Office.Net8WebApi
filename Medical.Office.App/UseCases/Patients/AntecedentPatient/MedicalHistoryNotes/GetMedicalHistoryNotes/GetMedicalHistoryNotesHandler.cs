using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications.Responses;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes
{
    internal sealed class GetMedicalHistoryNotesHandler : IInteractor<GetMedicalHistoryNotesRequest,GetMedicalHistoryNotesResponse>
    {
        private readonly ILogger<GetMedicalHistoryNotesHandler> _logger;
        private readonly IAntecedentPatient _antecedent;

        public GetMedicalHistoryNotesHandler(ILogger<GetMedicalHistoryNotesHandler> logger, IAntecedentPatient antecedent)
        {
            _logger=logger;
            _antecedent=antecedent;
        }

        public async Task<GetMedicalHistoryNotesResponse> Handle(GetMedicalHistoryNotesRequest request, CancellationToken cancellationToken)
        {
            var MedicalHistoryNotes = await _antecedent.GetMedicalHistoryNotesByPatientIdAsync(request.IdPatient).ConfigureAwait(false);

            if (MedicalHistoryNotes == null)
            {
                return new FailureGetMedicalHistoryNotesResponse("No se encontro informacion para este paciente.");
            }

            return new SuccessGetMedicalHistoryNotesResponse(new MedicalHistoryNotesDto(
                MedicalHistoryNotes.Id,
                MedicalHistoryNotes.IDPatient ?? 0,
                MedicalHistoryNotes.MedicalHistoryNotesData,
                MedicalHistoryNotes.DateTimeSnap));
        }
    }
}
