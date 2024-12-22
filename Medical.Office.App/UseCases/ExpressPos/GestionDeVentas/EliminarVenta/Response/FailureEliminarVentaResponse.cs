using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.EliminarVenta.Response;

public record FailureEliminarVentaResponse(string Message) : EliminarVentaResponse, IFailure;