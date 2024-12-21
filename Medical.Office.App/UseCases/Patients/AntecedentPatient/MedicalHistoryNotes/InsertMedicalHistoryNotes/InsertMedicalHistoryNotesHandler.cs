using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.InsertMedicalHistoryNotes.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

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
            
            var MedicalHistoryNotes = await _antecedent.GetMedicalHistoryNotesByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            var PatientsData = await _patients.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);

            if (PatientsData == null || !Equals(request.IDPatient, PatientsData.ID) || string.IsNullOrEmpty(Convert.ToString(request.IDPatient)))
            {
                return new FailureInsertMedicalHistoryNotesResponse ($"No se encontro al paciente {request.IDPatient} o no es valido con el registo que se quiere ingresar");
            }

            if (MedicalHistoryNotes != null) 
            {
                return new FailureInsertMedicalHistoryNotesResponse("Este paciente ya cuenta con un registro");
            }

            await _antecedent.InsertMedicalHistoryNotesAsync(
                request.IDPatient,
                request.MedicalHistoryNotesData
                ).ConfigureAwait(false);

            MedicalHistoryNotes = await _antecedent.GetMedicalHistoryNotesByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            return new SuccessInsertMedicalHistoryNotesResponse(new MedicalHistoryNotesDto(MedicalHistoryNotes.Id,
                MedicalHistoryNotes.IDPatient ?? 0,
                MedicalHistoryNotes.MedicalHistoryNotesData,
                MedicalHistoryNotes.DateTimeSnap));
        }
    }
}
