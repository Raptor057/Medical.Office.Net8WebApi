using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.FilesPatients.InsertPatientFile.Responses;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.InsertPatientFile;

public sealed record InsertPatientFileRequest(PatientsFilesDto PatientsFilesData): IRequest<InsertPatientFileResponse>;