using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas.Response;

public record FailureObtenerDetalleDeVentasResponse(string Message) : ObtenerDetalleDeVentasResponse, IFailure;