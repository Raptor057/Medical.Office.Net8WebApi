using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock.Response;

public record SuccessObtenerProductosConBajoStockResponse(IEnumerable<ProductosDto> Productos) : ObtenerProductosConBajoStockResponse, ISuccess;