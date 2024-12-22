using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.RegistrarVenta.Response.Response;

public record FailureRegistrarVentaResponse(string Message) : RegistrarVentaResponse, IFailure;