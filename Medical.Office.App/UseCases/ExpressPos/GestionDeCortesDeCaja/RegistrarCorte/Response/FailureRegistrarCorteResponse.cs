using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte.Response;

public record FailureRegistrarCorteResponse(string Message) : RegistrarCorteResponse, IFailure;