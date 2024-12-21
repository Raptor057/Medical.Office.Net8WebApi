using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.FamilyHistory;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.UpdateFamilyHistory;

public sealed record UpdateFamilyHistoryRequest(FamilyHistoryDto FamilyHistory):IRequest<UpdateFamilyHistoryResponse>;