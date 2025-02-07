﻿using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.MedicalHistoryNotes;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.MedicalHistoryNotes.GetMedicalHistoryNotes.Responses
{
    public record SuccessGetMedicalHistoryNotesResponse(MedicalHistoryNotesDto MedicalHistoryNotes) : GetMedicalHistoryNotesResponse, ISuccess;
}
