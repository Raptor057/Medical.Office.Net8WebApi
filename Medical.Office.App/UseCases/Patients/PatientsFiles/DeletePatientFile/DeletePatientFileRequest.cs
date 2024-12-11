using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.FilesPatients.DeletePatientFile.Responses;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.DeletePatientFile;

public sealed record DeletePatientFileRequest(long IDPatient, int Id) : IRequest<DeletePatientFileResponse>;