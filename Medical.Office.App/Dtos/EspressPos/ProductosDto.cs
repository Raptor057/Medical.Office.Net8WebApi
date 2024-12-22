namespace Medical.Office.App.Dtos.EspressPos;

public record ProductosDto(

    int ProductoID,
    string Nombre,
    double Precio,
    int Stock
);