namespace Medical.Office.App.Dtos.Patients
{
    public record PatientsFilesDto(

        long Id,
        long IDPatient,
        string FileName,
        string FileType,
        string FileExtension,
        string Description,
        byte[] FileData,
        DateTime DateTimeUploaded
    );
}
