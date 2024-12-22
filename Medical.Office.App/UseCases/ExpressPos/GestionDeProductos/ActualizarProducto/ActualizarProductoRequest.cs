using Common.Common.CleanArch;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarProducto;

public record ActualizarProductoRequest(int ProductoID, string Nombre, double Precio, int Stock) : IRequest<ActualizarProductoResponse>;