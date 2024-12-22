using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos.Response;

public record FailureObtenerTodosLosProductosResponse(string Message) : ObtenerTodosLosProductosResponse, IFailure;