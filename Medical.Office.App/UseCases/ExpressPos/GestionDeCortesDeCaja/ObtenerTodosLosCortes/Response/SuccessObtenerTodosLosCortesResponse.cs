using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes.Response;

public record SuccessObtenerTodosLosCortesResponse(IEnumerable<CortesDto> Cortes) : ObtenerTodosLosCortesResponse, ISuccess;