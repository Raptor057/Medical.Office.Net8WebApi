using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Doctors.InsertDoctors.Response;

namespace Medical.Office.App.UseCases.Configurations.Doctors.InsertDoctors
{
    internal class InsertDoctorsRequest : IRequest<InsertDoctorsResponse>
    {

        public DoctorsDto Doctor { get; set; }
        public InsertDoctorsRequest(DoctorsDto doctor)
        {
            Doctor=doctor;
        }
        public static void Validations(DoctorsDto Doctor, out ErrorList errors)
        {
            errors = [];

            if (Doctor == null)
            {
                errors.Add("");
                return;
            }
            if (string.IsNullOrEmpty(Doctor.FirstName))
            {
                errors.Add("Nombre Obligatorio");
            }
            if (string.IsNullOrEmpty(Doctor.LastName))
            {
                errors.Add("Apellido Obligatorio");
            }
            if (string.IsNullOrEmpty(Doctor.Specialty))
            {
                errors.Add("Especialidad Obligatorio");
            }
        }

        public static bool CanInsert(DoctorsDto doctor, out ErrorList errors)
        {
            errors=[];
            Validations(doctor, out errors);
            return errors.IsEmpty;
        }

        public static InsertDoctorsRequest Insert(DoctorsDto doctor)
        {
            if (!CanInsert(doctor,out ErrorList errors)) throw errors.AsException();
                return new InsertDoctorsRequest(doctor);
        }
    }
}
