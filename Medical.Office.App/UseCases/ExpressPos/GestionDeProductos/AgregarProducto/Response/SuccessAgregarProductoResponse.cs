using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.AgregarProducto.Response;

public record SuccessAgregarProductoResponse(ProductosDto Producto) : AgregarProductoResponse, ISuccess;