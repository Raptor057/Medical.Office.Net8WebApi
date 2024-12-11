using Common.Common;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.DeletePatientFile.Responses;

public record SucessDeletePatientFileResponse(string Message): DeletePatientFileResponse,ISuccess;