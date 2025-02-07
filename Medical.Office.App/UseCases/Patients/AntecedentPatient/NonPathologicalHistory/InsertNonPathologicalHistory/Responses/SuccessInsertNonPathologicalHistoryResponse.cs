﻿using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.InsertNonPathologicalHistory.Responses
{
    public record SuccessInsertNonPathologicalHistoryResponse(NonPathologicalHistoryDto NonPathologicalHistory) : InsertNonPathologicalHistoryResponse, ISuccess;
}
