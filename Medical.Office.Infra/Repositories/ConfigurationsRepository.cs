﻿using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;

namespace Medical.Office.Infra.Repositories
{
    public class ConfigurationsRepository : IConfigurationsRepository
    {
        private readonly MedicalOfficeSqlLocalDB _db;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public ConfigurationsRepository(MedicalOfficeSqlLocalDB db)
        {
            _db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Genders>> GetGendersAsync()
        {
            //var GetGenders = await _db.GetGenders().ConfigureAwait(false);
            //if (GetGenders == null || GetGenders.Count() == 0) 
            //{
            //    await _db.StartInsertGenders().ConfigureAwait(false);
            //    return await _db.GetGenders().ConfigureAwait(false);
            //}
            return await _db.GetGenders().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Positions>> GetPositionsAsync()
        {
            //var GetStartPositions = await _db.GetPositions().ConfigureAwait(false);
            //if (GetStartPositions == null || GetStartPositions.Count() == 0) 
            //{
            //    await _db.StartInsertPositions().ConfigureAwait(false);
            //    return await _db.GetPositions().ConfigureAwait(false);
            //}
            return await _db.GetPositions().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Roles>> GetRolesAsync()
        {
            //var GetStartRoles = await _db.GetRoles().ConfigureAwait(false);
            //if (GetStartRoles == null || GetStartRoles.Count() == 0)
            //{
            //    await _db.StartInsertRoles().ConfigureAwait(false);
            //    return await _db.GetRoles().ConfigureAwait(false);
            //}
            return await _db.GetRoles().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Specialties>> GetSpecialtiesAsync()
        {
            //var GetStartSpecialities = await _db.GetSpecialties().ConfigureAwait(false);
            //if (GetStartSpecialities == null || GetStartSpecialities.Count() == 0)
            //{
            //    await _db.StartInsertSpecialties().ConfigureAwait(false);
            //    return await _db.GetSpecialties().ConfigureAwait(false);
            //}
            return await _db.GetSpecialties().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserStatuses>> GetUserStatusesAsync()
        {
            //var GetStartUserStatuses = await _db.GetUserStatuses().ConfigureAwait(false);
            //if(GetStartUserStatuses == null || GetStartUserStatuses.Count() == 0)
            //{
            //    await _db.StartInsertUserStatuses().ConfigureAwait(false);
            //    return await _db.GetUserStatuses().ConfigureAwait(false);
            //}
            return await _db.GetUserStatuses().ConfigureAwait(false);
        }

        public async Task<IEnumerable<LoginHistory>> GetLoginHistoryAsync()
            => await _db.GetLoginHistory().ConfigureAwait(false);


        public async Task<IEnumerable<LoginHistory>> GetLoginHistoryByParamsAsync(string Param, DateTime StartDate, DateTime EndDate)
            => await _db.GetLoginHistoryByParams(Param, StartDate, EndDate).ConfigureAwait(false);


        public async Task<IEnumerable<UsersMovements>> GetUsersMovementsAsync()
            => await _db.GetUsersMovements().ConfigureAwait(false);


        public async Task<IEnumerable<UsersMovements>> GetUsersMovementsByParamsAsync(string Param, DateTime StartDate, DateTime EndDate)
            => await _db.GetUsersMovementsByParams(Param,StartDate,EndDate).ConfigureAwait(false);


        public async Task InsertLoginHistoryAsync(string Usr, string UsrName, string? Token)
            => await _db.InsertLoginHistory(Usr, UsrName, Token).ConfigureAwait(false);


        public async Task InsertUsersMovementsAsync(string Usr, string UsrName, string UsrRole, string UsrMovement, string? Token)
            => await _db.InsertUsersMovements(Usr,UsrName, UsrRole, UsrMovement, Token).ConfigureAwait(false);

        public async Task<OfficeSetup> GetOfficeSetupAsync()
            => await _db.GetOfficeSetup().ConfigureAwait(false);

        public async Task InsertOfficeSetupAsync(string NameOfOffice, string Address)
            => await _db.InsertOfficeSetup(NameOfOffice, Address).ConfigureAwait(true);

        public async Task InsertPositionsAsync(string PositionName)
            => await _db.InsertPositions(PositionName).ConfigureAwait(false);

        public async Task InsertSpecialtiesAsync(string Specialty)
            => await _db.InsertSpecialties(Specialty).ConfigureAwait(false);

        public async Task<LaboralDays> GetTodaysWorkScheduleAsync()
            => await _db.GetTodaysWorkSchedule().ConfigureAwait(false);

        public async Task<IEnumerable<LaboralDays>> GetWorkScheduleAsync()
            => await _db.GetWorkSchedule().ConfigureAwait(false);

        public async Task UpdateOfficeSetupAsync(string NameOfOffice, string Address)
        {
            OfficeSetup OfficeSetupData = new()
            {
                NameOfOffice = NameOfOffice,
                Address = Address
            };

            await _db.UpdateOfficeSetup(OfficeSetupData).ConfigureAwait(false);
        }
        public async Task UpdateWorkScheduleAsync(LaboralDays laboralDays)
            => await _db.UpdateWorkSchedule(laboralDays).ConfigureAwait(false);

        public async Task<IEnumerable<Doctors>> GetDoctorsAsync()
            => await _db.GetDoctors().ConfigureAwait(false);

        public async Task<Doctors> GetDoctorAsync(long IDDoctor)
        => await _db.GetDoctor(IDDoctor).ConfigureAwait(false);

        public async Task<IEnumerable<TypeOfAppointment>> GetTypeOfAppointmentsListAsync()
            => await _db.GetTypeOfAppointmentsList().ConfigureAwait(false);

        public async Task InsertTypeOfAppointmentAsync(string typeOfAppointment)
        => await _db.InsertTypeOfAppointment(typeOfAppointment).ConfigureAwait(false);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="laboralDays"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //public Task UpdateLaboralDaysByIdAsync(LaboralDays laboralDays)
        //    => _db.UpdateLaboralDaysById(laboralDays);
        public async Task UpdateLaboralDaysByIdAsync(int Id, bool Laboral, TimeSpan OpeningTime, TimeSpan ClosingTime)
        {

            LaboralDays laboralDays = new();
            {
                laboralDays.Id = Id;
                laboralDays.Laboral= Laboral;
                laboralDays.OpeningTime = OpeningTime;
                laboralDays.ClosingTime = ClosingTime;
            };

           await _db.UpdateLaboralDaysById(laboralDays).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<LaboralDays>> GetLaboralDaysListAsync()
            => _db.GetLaboralDaysList();

        public async Task<LaboralDays> GetLaboralDayByIdAsync(int Id)
            => await _db.GetLaboralDayByID(Id).ConfigureAwait(false);


        public async Task InsertDoctorAsync(string FirstName, string LastName, string Specialty, string PhoneNumber, string Email)
            => await _db.InsertDoctors(FirstName, LastName, Specialty, PhoneNumber,Email).ConfigureAwait(false);

        public Task DeleteDoctorAsync(long IDDoctor)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateDoctorAsync(long Id, string FirstName, string LastName, string Specialty, string PhoneNumber, string Email)
        {
            Doctors doctors = new();
            {
                doctors.ID = Id;
                doctors.FirstName = FirstName;
                doctors.LastName = LastName;
                doctors.Specialty = Specialty;
                doctors.PhoneNumber = PhoneNumber;
                doctors.Email = Email;
            }
            await _db.UpdateDoctor(doctors).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TypeOfAppointment>> GetTypeOfAppointmentAsync()
            => await _db.GetTypeOfAppointment().ConfigureAwait(false);
    }
}
