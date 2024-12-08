using Common.Common;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.InsertPatientFile.Responses;

public record SuccessInsertPatientFileResponse(string Message) : InsertPatientFileResponse,ISuccess;