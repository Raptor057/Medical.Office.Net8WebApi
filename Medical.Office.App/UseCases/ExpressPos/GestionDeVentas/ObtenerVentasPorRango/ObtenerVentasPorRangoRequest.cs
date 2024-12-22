using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentasPorRango.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentasPorRango;

public record ObtenerVentasPorRangoRequest(DateTime FechaInicio, DateTime FechaFin) : IRequest<ObtenerVentasPorRangoResponse>;