using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes.Response;

public record FailureObtenerTodosLosCortesResponse(string Message) : ObtenerTodosLosCortesResponse, IFailure;