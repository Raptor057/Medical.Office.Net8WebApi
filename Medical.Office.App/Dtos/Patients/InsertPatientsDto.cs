namespace Medical.Office.App.Dtos.Patients
{
    public record InsertPatientsDto(
        string Name,
        string FathersSurname,
        string MothersSurname,
        DateTime? DateOfBirth,
        string Gender,
        string Address,
        string Country,
        string City,
        string State,
        string ZipCode,
        string OutsideNumber,
        string InsideNumber,
        string PhoneNumber,
        string Email,
        string EmergencyContactName,
        string EmergencyContactPhone,
        string InsuranceProvider,
        string PolicyNumber,
        string BloodType,
        byte[] Photo,
        string InternalNotes
    );
}
