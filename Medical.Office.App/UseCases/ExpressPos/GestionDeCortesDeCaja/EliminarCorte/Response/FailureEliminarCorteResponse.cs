using Common.Common;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.EliminarCorte.Response;

public record FailureEliminarCorteResponse(string Message) : EliminarCorteResponse, IFailure;