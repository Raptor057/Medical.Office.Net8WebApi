using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.RegistrarVenta.Response.Response;

public record SuccessRegistrarVentaResponse(VentasDto Venta) : RegistrarVentaResponse, ISuccess;