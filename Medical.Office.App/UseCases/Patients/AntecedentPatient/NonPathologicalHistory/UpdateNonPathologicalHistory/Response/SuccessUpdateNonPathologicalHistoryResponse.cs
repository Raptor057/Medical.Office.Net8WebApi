using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.NonPathologicalHistory;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.NonPathologicalHistory.UpdateNonPathologicalHistory.Response;

public record SuccessUpdateNonPathologicalHistoryResponse(NonPathologicalHistoryDto NonPathologicalHistory ) : UpdateNonPathologicalHistoryResponse, ISuccess;