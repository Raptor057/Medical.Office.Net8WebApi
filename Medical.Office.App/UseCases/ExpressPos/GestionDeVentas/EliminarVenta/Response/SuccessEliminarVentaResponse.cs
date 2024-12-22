using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.EliminarVenta.Response;

public record SuccessEliminarVentaResponse(int VentaID) : EliminarVentaResponse, ISuccess;