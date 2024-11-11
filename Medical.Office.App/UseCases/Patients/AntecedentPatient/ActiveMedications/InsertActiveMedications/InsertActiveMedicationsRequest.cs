using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses;
using System;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications
{
    public sealed class InsertActiveMedicationsRequest : IRequest<InsertActiveMedicationsResponse>
    {
        public long? Id { get; set; }
        public long IDPatient { get; set; }
        public string? ActiveMedicationsData { get; set; }
        public DateTime? DateTimeSnap { get; set; }

        public InsertActiveMedicationsRequest(long? id, long idPatient, string? activeMedicationsData, DateTime? dateTimeSnap)
        {
            Id = id;
            IDPatient = idPatient;
            ActiveMedicationsData = activeMedicationsData;
            DateTimeSnap = dateTimeSnap;
        }

        public static bool CanInsert(ActiveMedicationsDto activeMedicationsDto, out ErrorList errors)
        {
            errors = new ErrorList();
            ValidateIDPatient(activeMedicationsDto.IDPatient, errors);
            return errors.IsEmpty;
        }

        public static InsertActiveMedicationsRequest Create(ActiveMedicationsDto activeMedicationsDto)
        {
            if (!CanInsert(activeMedicationsDto, out ErrorList errors)) throw errors.AsException();
            return new InsertActiveMedicationsRequest(
                activeMedicationsDto.Id,
                activeMedicationsDto.IDPatient,
                activeMedicationsDto.ActiveMedicationsData,
                activeMedicationsDto.DateTimeSnap
            );
        }

        private static void ValidateIDPatient(long idPatient, ErrorList errors)
        {
            if (idPatient <= 0)
            {
                errors.Add("El ID del paciente es obligatorio y debe ser mayor que cero.");
            }
        }
    }
}
