using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.UpdateFamilyHistory;

public record SuccessUpdateFamilyHistoryResponse(FamilyHistoryDto FamilyHistory) : UpdateFamilyHistoryResponse,ISuccess;