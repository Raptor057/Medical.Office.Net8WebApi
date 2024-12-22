using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock.Response;

public record FailureObtenerProductosConBajoStockResponse(string Message) : ObtenerProductosConBajoStockResponse, IFailure;