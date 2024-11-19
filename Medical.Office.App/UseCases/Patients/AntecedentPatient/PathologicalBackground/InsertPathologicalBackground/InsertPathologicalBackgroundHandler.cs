using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PathologicalBackground;
using Medical.Office.App.Methods;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.InsertPathologicalBackground
{
    internal sealed class InsertPathologicalBackgroundHandler : IInteractor<InsertPathologicalBackgroundRequest, InsertPathologicalBackgroundResponse>
    {
        private readonly ILogger<InsertPathologicalBackgroundHandler> _logger;
        private readonly IAntecedentPatient _antecedent;
        private readonly IPatientsData _patients;

        public InsertPathologicalBackgroundHandler(ILogger<InsertPathologicalBackgroundHandler> logger, IAntecedentPatient antecedent, IPatientsData patients)
        {
            _logger=logger;
            _antecedent=antecedent;
            _patients=patients;
        }

        public async Task<InsertPathologicalBackgroundResponse> Handle(InsertPathologicalBackgroundRequest request, CancellationToken cancellationToken)
        {
            var PathologicalBackground = await _antecedent.GetPathologicalBackgroundByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            var PatientsData = await _patients.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);

            if (PatientsData == null || !Equals(request.IDPatient, PatientsData.ID) || string.IsNullOrEmpty(Convert.ToString(request.IDPatient)))
            {
                return new FailureInsertPathologicalBackgroundResponse ($"No se encontro al paciente {request.IDPatient} o no es valido con el registo que se quiere ingresar");
            }

            if (PathologicalBackground != null)
            {
                return new FailureInsertPathologicalBackgroundResponse("Este paciente ya cuenta con historial");
            }

            await _antecedent.InsertPathologicalBackgroundAsync(
            request.IDPatient,
            ConvertBoolToInt(request.PreviousHospitalization),
            ConvertBoolToInt(request.PreviousSurgeries),
            ConvertBoolToInt(request.Diabetes),
            ConvertBoolToInt(request.ThyroidDiseases),
            ConvertBoolToInt(request.Hypertension),
            ConvertBoolToInt(request.Cardiopathies),
            ConvertBoolToInt(request.Trauma),
            ConvertBoolToInt(request.Cancer),
            ConvertBoolToInt(request.Tuberculosis),
            ConvertBoolToInt(request.Transfusions),
            ConvertBoolToInt(request.RespiratoryDiseases),
            ConvertBoolToInt(request.GastrointestinalDiseases),
            ConvertBoolToInt(request.STDs),
            request.STDsData ?? string.Empty, // Maneja el caso en que sea null
            ConvertBoolToInt(request.ChronicKidneyDisease),
            request.Others ?? string.Empty // Maneja el caso en que sea null
            ).ConfigureAwait(false);

            PathologicalBackground = await _antecedent.GetPathologicalBackgroundByPatientIdAsync(request.IDPatient).ConfigureAwait(false);

            return new SuccessInsertPathologicalBackgroundResponse(new PathologicalBackgroundDto(
                PathologicalBackground.Id,
                PathologicalBackground.IDPatient,
                PathologicalBackground.PreviousHospitalization,
                PathologicalBackground.PreviousSurgeries,
                PathologicalBackground.Diabetes,
                PathologicalBackground.ThyroidDiseases,
                PathologicalBackground.Hypertension,
                PathologicalBackground.Cardiopathies,
                PathologicalBackground.Trauma,
                PathologicalBackground.Cancer,
                PathologicalBackground.Tuberculosis,
                PathologicalBackground.Transfusions,
                PathologicalBackground.RespiratoryDiseases,
                PathologicalBackground.GastrointestinalDiseases,
                PathologicalBackground.STDs,
                PathologicalBackground.STDsData,
                PathologicalBackground.ChronicKidneyDisease,
                PathologicalBackground.Others,
                PathologicalBackground.DateTimeSnap));
        }
        private static int? ConvertBoolToInt(bool? value)
        {
            return value.HasValue ? (value.Value ? 1 : 0) : (int?)null;
        }
    }
}
