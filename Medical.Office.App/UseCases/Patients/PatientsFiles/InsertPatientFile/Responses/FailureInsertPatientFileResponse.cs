using Common.Common;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.InsertPatientFile.Responses;

public record FailureInsertPatientFileResponse(string Message) : InsertPatientFileResponse, IFailure;