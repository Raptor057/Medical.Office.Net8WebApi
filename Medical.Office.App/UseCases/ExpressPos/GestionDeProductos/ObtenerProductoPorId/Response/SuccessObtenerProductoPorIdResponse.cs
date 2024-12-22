using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductoPorId.Request;

public record SuccessObtenerProductoPorIdResponse(ProductosDto Producto) : ObtenerProductoPorIdResponse, ISuccess;