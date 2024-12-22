using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.EliminarProducto.Response;

public record SuccessEliminarProductoResponse(int ProductoID) : EliminarProductoResponse, ISuccess;