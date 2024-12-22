using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia;

public record ObtenerResumenDeCortesPorDiaRequest(DateTime FechaInicio, DateTime FechaFin) : IRequest<ObtenerResumenDeCortesPorDiaResponse>;