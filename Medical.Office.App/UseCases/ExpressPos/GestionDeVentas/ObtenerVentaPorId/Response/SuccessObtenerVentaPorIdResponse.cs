using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentaPorId.Response;

public record SuccessObtenerVentaPorIdResponse(VentasDto Venta) : ObtenerVentaPorIdResponse, ISuccess;