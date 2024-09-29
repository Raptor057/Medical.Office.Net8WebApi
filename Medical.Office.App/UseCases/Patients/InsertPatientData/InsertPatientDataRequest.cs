using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.InsertPatientData.Responses;

namespace Medical.Office.App.UseCases.Patients.InsertPatientData
{
    public sealed class InsertPatientDataRequest : IRequest<InsertPatientDataResponse>
    {
        public static bool CanCreatePatient(InsertPatientsDto insertPatientsDto, out ErrorList errors)
        {
            errors = new();
            ValidPatientName(insertPatientsDto.Name, errors);
            ValidPatientFathersSurname(insertPatientsDto.FathersSurname, errors);
            ValidPatientDateOfBirth(insertPatientsDto.DateOfBirth, errors);
            ValidPatientGender(insertPatientsDto.Gender, errors);
            return errors.IsEmpty;
        }

        public static InsertPatientDataRequest CreatePatient(InsertPatientsDto insertPatientsDto)
        {
            if(!CanCreatePatient(insertPatientsDto, out ErrorList errors)) throw errors.AsException();
            return new InsertPatientDataRequest(insertPatientsDto);
        }

        private static void ValidPatientName(string patientName, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(patientName))
            {
                errors.Add("El nombre del usuario se encuentra vacío y es obligatorio");
            }
        }

        private static void ValidPatientFathersSurname(string patientFathersSurname, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(patientFathersSurname))
            {
                errors.Add("El apellido paterno del usuario se encuentra vacío y es obligatorio");
            }
        }

        private static void ValidPatientGender(string patientGender, ErrorList errors)
        {
            if (string.IsNullOrWhiteSpace(patientGender))
            {
                errors.Add("El genero del usuario se encuentra vacío y es obligatorio");
            }
        }

        private static void ValidPatientDateOfBirth(DateTime? patientDateOfBirth, ErrorList errors)
        {
            if (patientDateOfBirth == null)
            {
                errors.Add("La fecha de nacimiento del usuario se encuentra vacía y es obligatoria");
            }
        }

        private InsertPatientDataRequest(InsertPatientsDto insertPatientsDto)
        {
            // Asignación con verificación de null y vacío para los opcionales
            Name = insertPatientsDto.Name;
            FathersSurname = string.IsNullOrWhiteSpace(insertPatientsDto.FathersSurname) ? null : insertPatientsDto.FathersSurname;
            MothersSurname = string.IsNullOrWhiteSpace(insertPatientsDto.MothersSurname) ? null : insertPatientsDto.MothersSurname;
            DateOfBirth = insertPatientsDto.DateOfBirth;
            Gender = string.IsNullOrWhiteSpace(insertPatientsDto.Gender) ? null : insertPatientsDto.Gender;
            Address = string.IsNullOrWhiteSpace(insertPatientsDto.Address) ? null : insertPatientsDto.Address;
            Country = string.IsNullOrWhiteSpace(insertPatientsDto.Country) ? null : insertPatientsDto.Country;
            City = string.IsNullOrWhiteSpace(insertPatientsDto.City) ? null : insertPatientsDto.City;
            State = string.IsNullOrWhiteSpace(insertPatientsDto.State) ? null : insertPatientsDto.State;
            ZipCode = string.IsNullOrWhiteSpace(insertPatientsDto.ZipCode) ? null : insertPatientsDto.ZipCode;
            OutsideNumber = string.IsNullOrWhiteSpace(insertPatientsDto.OutsideNumber) ? null : insertPatientsDto.OutsideNumber;
            InsideNumber = string.IsNullOrWhiteSpace(insertPatientsDto.InsideNumber) ? null : insertPatientsDto.InsideNumber;
            PhoneNumber = string.IsNullOrWhiteSpace(insertPatientsDto.PhoneNumber) ? null : insertPatientsDto.PhoneNumber;
            Email = string.IsNullOrWhiteSpace(insertPatientsDto.Email) ? null : insertPatientsDto.Email;
            EmergencyContactName = string.IsNullOrWhiteSpace(insertPatientsDto.EmergencyContactName) ? null : insertPatientsDto.EmergencyContactName;
            EmergencyContactPhone = string.IsNullOrWhiteSpace(insertPatientsDto.EmergencyContactPhone) ? null : insertPatientsDto.EmergencyContactPhone;
            InsuranceProvider = string.IsNullOrWhiteSpace(insertPatientsDto.InsuranceProvider) ? null : insertPatientsDto.InsuranceProvider;
            PolicyNumber = string.IsNullOrWhiteSpace(insertPatientsDto.PolicyNumber) ? null : insertPatientsDto.PolicyNumber;
            BloodType = string.IsNullOrWhiteSpace(insertPatientsDto.BloodType) ? null : insertPatientsDto.BloodType;
            Photo = insertPatientsDto.Photo ?? Array.Empty<byte>();  // Si no hay foto, asignar un array vacío.
            //Photo = string.IsNullOrWhiteSpace(insertPatientsDto.Photo) ? Array.Empty<byte>() : Convert.FromBase64String(insertPatientsDto.Photo); // Conversión de Base64 a byte[]
            InternalNotes = string.IsNullOrWhiteSpace(insertPatientsDto.InternalNotes) ? null : insertPatientsDto.InternalNotes;
        }

        // Propiedades
        public string Name { get; }
        public string FathersSurname { get; }
        public string MothersSurname { get; }
        public DateTime? DateOfBirth { get; }
        public string Gender { get; }
        public string Address { get; }
        public string Country { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }
        public string OutsideNumber { get; }
        public string InsideNumber { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string EmergencyContactName { get; }
        public string EmergencyContactPhone { get; }
        public string InsuranceProvider { get; }
        public string PolicyNumber { get; }
        public string BloodType { get; }
        public byte[] Photo { get; }
        public string InternalNotes { get; }
    }
}
