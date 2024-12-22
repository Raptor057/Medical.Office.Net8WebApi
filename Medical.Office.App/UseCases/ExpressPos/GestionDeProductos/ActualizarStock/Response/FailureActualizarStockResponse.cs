using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarStock.Response;

public record FailureActualizarStockResponse(string Message) : ActualizarStockResponse, IFailure;