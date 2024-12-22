using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock;

public record ObtenerProductosConBajoStockRequest(int LimiteStock) : IRequest<ObtenerProductosConBajoStockResponse>;