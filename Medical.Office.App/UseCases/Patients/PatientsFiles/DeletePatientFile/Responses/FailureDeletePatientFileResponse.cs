using Common.Common;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.DeletePatientFile.Responses;

public record FailureDeletePatientFileResponse(string Message):DeletePatientFileResponse, IFailure;