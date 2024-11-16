using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PathologicalBackground;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground.Responses;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PathologicalBackground.GetPathologicalBackground
{
    internal class GetPathologicalBackgroundHandler : IInteractor<GetPathologicalBackgroundRequest, GetPathologicalBackgroundResponse>
    {
        private readonly ILogger<GetPathologicalBackgroundHandler> _logger;
        private readonly IAntecedentPatient _antecedent;

        public GetPathologicalBackgroundHandler(ILogger<GetPathologicalBackgroundHandler> logger, IAntecedentPatient antecedent)
        {
            _logger=logger;
            _antecedent=antecedent;
        }

        public async Task<GetPathologicalBackgroundResponse> Handle(GetPathologicalBackgroundRequest request, CancellationToken cancellationToken)
        {
            var PathologicalBackground = await _antecedent.GetPathologicalBackgroundByPatientIdAsync(request.IdPatient).ConfigureAwait(false);

            if (PathologicalBackground == null) 
            {
                return new FailureGetPathologicalBackgroundResponse("No se encontro informacion para este paciente");
            }
            PathologicalBackground = await _antecedent.GetPathologicalBackgroundByPatientIdAsync(request.IdPatient).ConfigureAwait(false);

            return new SuccessGetPathologicalBackgroundResponse(new PathologicalBackgroundDto(
                PathologicalBackground.Id,
                PathologicalBackground.IDPatient,
                PathologicalBackground.PreviousHospitalization,
                PathologicalBackground.PreviousHospitalization,
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
    }
}
