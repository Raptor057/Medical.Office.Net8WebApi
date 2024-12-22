using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.AgregarProducto.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.AgregarProducto;

public record AgregarProductoRequest(string Nombre, double Precio, int Stock) : IRequest<AgregarProductoResponse>;