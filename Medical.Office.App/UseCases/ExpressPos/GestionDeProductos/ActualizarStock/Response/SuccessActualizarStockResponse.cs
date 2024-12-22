using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarStock.Response;

public record SuccessActualizarStockResponse(int ProductoID, int NuevoStock) : ActualizarStockResponse, ISuccess;
