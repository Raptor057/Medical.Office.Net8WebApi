using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.EliminarVenta.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.EliminarVenta;

public record EliminarVentaRequest(int VentaID) : IRequest<EliminarVentaResponse>;