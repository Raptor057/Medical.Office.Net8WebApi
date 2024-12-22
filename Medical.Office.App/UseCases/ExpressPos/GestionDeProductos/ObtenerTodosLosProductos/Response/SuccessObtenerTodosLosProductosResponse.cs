using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos.Response;

public record SuccessObtenerTodosLosProductosResponse(IEnumerable<ProductosDto> Productos) : ObtenerTodosLosProductosResponse, ISuccess;