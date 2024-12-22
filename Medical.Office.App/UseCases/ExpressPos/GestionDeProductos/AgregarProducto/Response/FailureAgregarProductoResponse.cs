using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.AgregarProducto.Response;

public record FailureAgregarProductoResponse(string Message) : AgregarProductoResponse, IFailure;