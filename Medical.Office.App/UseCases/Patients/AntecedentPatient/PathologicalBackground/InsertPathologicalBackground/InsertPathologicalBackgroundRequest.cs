using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground.Responses;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground
{
    public sealed record InsertPathologicalBackgroundRequest(long IDPatient,
          bool? PreviousHospitalization,
          bool? PreviousSurgeries,
          bool? Diabetes,
          bool? ThyroidDiseases,
          bool? Hypertension,
          bool? Cardiopathies,
          bool? Trauma,
          bool? Cancer,
          bool? Tuberculosis,
          bool? Transfusions,
          bool? RespiratoryDiseases,
          bool? GastrointestinalDiseases,
          bool? STDs,
          string STDsData,
          bool? ChronicKidneyDisease,
          string Others) : IRequest<InsertPathologicalBackgroundResponse>;
}
