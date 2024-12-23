using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.RegistrarVenta.Response.Response;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.RegistrarVenta.Response;

public record RegistrarVentaRequest(DateTime FechaHora,
    //double Total, 
    IEnumerable<(int ProductoID, int Cantidad)> Productos) : IRequest<RegistrarVentaResponse>;
