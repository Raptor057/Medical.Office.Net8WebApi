using Common.Common;
using Medical.Office.App.Dtos.EspressPos.Viesw;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerVentasPorDia.Response;

public record SuccessObtenerVentasPorDiaResponse(IEnumerable<VentasPorDiaDto> VentasPorDia) : ObtenerVentasPorDiaResponse, ISuccess;