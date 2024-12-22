using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerVentasPorDia.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerVentasPorDia;

public record ObtenerVentasPorDiaRequest(DateTime FechaInicio, DateTime FechaFin) : IRequest<ObtenerVentasPorDiaResponse>;