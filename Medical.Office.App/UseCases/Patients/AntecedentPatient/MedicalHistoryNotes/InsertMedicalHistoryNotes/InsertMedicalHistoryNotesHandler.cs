using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes
{
    internal class InsertMedicalHistoryNotesHandler : IInteractor<InsertMedicalHistoryNotesRequest, InsertMedicalHistoryNotesResponse>
    {
        private readonly IAntecedentPatient _antecedent;
        private readonly IPatientsData _patients;

        public InsertMedicalHistoryNotesHandler(ILogger<InsertMedicalHistoryNotesHandler> logger, IAntecedentPatient antecedent, IPatientsData patients)
        {
            _antecedent=antecedent;
            _patients=patients;
        }

        public async Task<InsertMedicalHistoryNotesResponse> Handle(InsertMedicalHistoryNotesRequest request, CancellationToken cancellationToken)
        {
            var PatientData = await _patients.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
            throw new NotImplementedException();
        }
    }
}
