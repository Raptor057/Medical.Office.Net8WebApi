using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerVentasPorDia.Response;

public record FailureObtenerVentasPorDiaResponse(string Message) : ObtenerVentasPorDiaResponse, IFailure;