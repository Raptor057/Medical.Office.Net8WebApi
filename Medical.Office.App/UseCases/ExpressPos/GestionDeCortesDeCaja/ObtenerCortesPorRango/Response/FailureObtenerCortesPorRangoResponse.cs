using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango.Response;

public record FailureObtenerCortesPorRangoResponse(string Message) : ObtenerCortesPorRangoResponse, IFailure;