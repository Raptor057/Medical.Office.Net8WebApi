using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentasPorRango.Response;

public record FailureObtenerVentasPorRangoResponse(string Message) : ObtenerVentasPorRangoResponse, IFailure;