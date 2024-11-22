namespace Medical.Office.App.Dtos.Configurations
{
    public record WorkingHoursDto(int Id,
    string Days,
    bool Laboral,
    TimeSpan OpeningTime,
    TimeSpan ClosingTime);
}
