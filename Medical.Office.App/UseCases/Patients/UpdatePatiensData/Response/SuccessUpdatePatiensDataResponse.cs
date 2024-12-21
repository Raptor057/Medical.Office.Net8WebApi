using Common.Common;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.UpdatePatiensData.Response;

public record SuccessUpdatePatiensDataResponse(PatientDataAndAntecedentsDto PatientDataAndAntecedents) : UpdatePatiensDataResponse,ISuccess;