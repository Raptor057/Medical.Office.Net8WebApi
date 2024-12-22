using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarProducto;

public record SuccessActualizarProductoResponse(ProductosDto Producto) : ActualizarProductoResponse, ISuccess;