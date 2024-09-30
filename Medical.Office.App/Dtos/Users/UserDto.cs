namespace Medical.Office.App.Dtos.Users
{
    public record UserDto(
        long Id,
        string Usr,
        //string Psswd,
        string Name,
        string Lastname,
        string Role,
        string Position,
        string Status,
        string Specialtie,
        DateTime TimeSnap
    );
}
