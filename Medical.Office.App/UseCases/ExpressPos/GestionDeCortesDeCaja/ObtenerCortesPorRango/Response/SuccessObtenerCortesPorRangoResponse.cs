using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango.Response;

public record SuccessObtenerCortesPorRangoResponse(IEnumerable<CortesDto> Cortes) : ObtenerCortesPorRangoResponse, ISuccess;