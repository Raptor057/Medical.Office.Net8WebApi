using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarStock.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarStock;

public record ActualizarStockRequest(int ProductoID, int NuevoStock) : IRequest<ActualizarStockResponse>;