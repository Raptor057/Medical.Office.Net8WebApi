using Common.Common;
using Medical.Office.App.Dtos.EspressPos;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortePorId;

public record SuccessObtenerCortePorIdResponse(CortesDto Corte) : ObtenerCortePorIdResponse, ISuccess;