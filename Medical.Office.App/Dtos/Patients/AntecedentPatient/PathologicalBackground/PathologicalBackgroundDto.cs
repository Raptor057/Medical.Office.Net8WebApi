namespace Medical.Office.App.Dtos.Patients.AntecedentPatient.PathologicalBackground
{
    public record PathologicalBackgroundDto(
          long Id,
          long IDPatient,
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
          string Others,
          DateTime? DateTimeSnap
      );
}
