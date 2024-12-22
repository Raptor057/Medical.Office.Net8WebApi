using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortePorId;

public record FailureObtenerCortePorIdResponse(string Message) : ObtenerCortePorIdResponse, IFailure;