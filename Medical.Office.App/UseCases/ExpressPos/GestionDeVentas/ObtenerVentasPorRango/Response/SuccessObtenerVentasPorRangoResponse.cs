using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentasPorRango.Response;

public record SuccessObtenerVentasPorRangoResponse(IEnumerable<VentasDto> Ventas) : ObtenerVentasPorRangoResponse, ISuccess;