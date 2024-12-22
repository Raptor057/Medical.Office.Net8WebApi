using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentaPorId.Response;

public record FailureObtenerVentaPorIdResponse(string Message) : ObtenerVentaPorIdResponse, IFailure;