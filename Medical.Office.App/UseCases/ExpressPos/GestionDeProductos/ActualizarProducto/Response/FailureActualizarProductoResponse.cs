using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarProducto;

public record FailureActualizarProductoResponse(string Message) : ActualizarProductoResponse, IFailure;