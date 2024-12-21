using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.UpdatePatiensData.Response;

namespace Medical.Office.App.UseCases.Patients.UpdatePatiensData;

public record UpdatePatiensDataRequest(PatientDataAndAntecedentsDto PatientDataAndAntecedents) : IRequest<UpdatePatiensDataResponse>;