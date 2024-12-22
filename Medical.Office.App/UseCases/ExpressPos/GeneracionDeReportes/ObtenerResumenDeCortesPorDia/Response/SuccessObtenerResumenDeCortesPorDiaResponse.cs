using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia.Response;

public record SuccessObtenerResumenDeCortesPorDiaResponse(IEnumerable<CortesDto> ResumenDeCortes) : ObtenerResumenDeCortesPorDiaResponse, ISuccess;