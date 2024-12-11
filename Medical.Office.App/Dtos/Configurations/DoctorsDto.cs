namespace Medical.Office.App.Dtos.Configurations
{
    public record DoctorsDto(

        long ID,
        string FirstName,
        string LastName,
        string Specialty,
        string PhoneNumber,
        string Email,
        DateTime? CreatedAt,
        DateTime? UpdatedAt
    );

}
