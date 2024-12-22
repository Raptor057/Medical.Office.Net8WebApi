using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.EliminarCorte.Response;

public record SuccessEliminarCorteResponse(int CorteID) : EliminarCorteResponse, ISuccess;