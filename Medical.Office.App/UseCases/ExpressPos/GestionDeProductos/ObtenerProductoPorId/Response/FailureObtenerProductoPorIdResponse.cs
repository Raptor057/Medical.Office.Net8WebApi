using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductoPorId.Request;

public record FailureObtenerProductoPorIdResponse(string Message) : ObtenerProductoPorIdResponse, IFailure;