using Common.Common;
using Medical.Office.App.Dtos.EspressPos.Viesw;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas.Response;

public record SuccessObtenerDetalleDeVentasResponse(IEnumerable<DetalleDeVentasDto> DetallesDeVenta) : ObtenerDetalleDeVentasResponse, ISuccess;