using Common.Common;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.GetPatientFile.Responses;

public record FailureGetPatientFileResponse(string Message) : GetPatientFileResponse,IFailure;