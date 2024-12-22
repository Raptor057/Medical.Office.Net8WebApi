using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.EliminarProducto.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.EliminarProducto;

public record EliminarProductoRequest(int ProductoID) : IRequest<EliminarProductoResponse>;