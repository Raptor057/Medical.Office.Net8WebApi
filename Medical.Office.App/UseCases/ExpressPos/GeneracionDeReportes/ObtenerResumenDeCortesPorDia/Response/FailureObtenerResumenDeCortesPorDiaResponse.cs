using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia.Response;

public record FailureObtenerResumenDeCortesPorDiaResponse(string Message) : ObtenerResumenDeCortesPorDiaResponse, IFailure;