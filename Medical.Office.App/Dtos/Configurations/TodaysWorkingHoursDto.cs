namespace Medical.Office.App.Dtos.Configurations
{
    public record TodaysWorkingHoursDto(
    int Id,
    string Days,
    bool Laboral,
    TimeSpan OpeningTime,
    TimeSpan ClosingTime);

}
