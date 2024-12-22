using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango;

public record ObtenerCortesPorRangoRequest(DateTime FechaInicio, DateTime FechaFin) : IRequest<ObtenerCortesPorRangoResponse>;