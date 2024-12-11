using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.FilesPatients.GetPatientFile.Responses;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.GetPatientFile;

public sealed record GetPatientFileRequest(long IDPatient , long Id) : IRequest<GetPatientFileResponse>;