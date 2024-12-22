using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.EliminarProducto.Response;

public record FailureEliminarProductoResponse(string Message) : EliminarProductoResponse, IFailure;