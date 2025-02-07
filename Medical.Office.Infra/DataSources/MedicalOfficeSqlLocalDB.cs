﻿using Medical.Office.Domain.Entities.ExpressPos;
using Medical.Office.Domain.Entities.ExpressPos.Views;
using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient;
using Medical.Office.Domain.Entities.POS;
using Microsoft.Extensions.Logging;

namespace Medical.Office.Infra.DataSources
{
    /// <summary>
    ///
    /// </summary>
    public class MedicalOfficeSqlLocalDB
    {
        private readonly ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> _con;
        private readonly ILogger<MedicalOfficeSqlLocalDB> _logger;

        public MedicalOfficeSqlLocalDB(ILogger<MedicalOfficeSqlLocalDB> logger,ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> con)
        {
            _con = con;
            _logger=logger;
        }

        #region Hosted Services
        public async Task UpdateAppointmentStatus()
            => await _con.ExecuteAsync(@"UPDATE MedicalAppointmentCalendar SET AppointmentStatus = 'Inactiva' WHERE EndOfAppointmentDateTime <= GETUTCDATE() AND AppointmentStatus = 'Activa';").ConfigureAwait(false);
        #endregion
        
        #region MedicalAppointmentCalendar

        public async Task<int> MedicalAppointmentCalendarIsOverlapping(long IDDoctor, DateTime AppointmentDateTime)
            => await _con.QueryFirstAsync<int>(@"SELECT CASE
    WHEN EXISTS (
        SELECT 1
        FROM MedicalAppointmentCalendar
        WHERE IDDoctor = @IDDoctor
          AND (
              (dbo.UfnToUniversalTime(@AppointmentDateTime) >= AppointmentDateTime AND dbo.UfnToUniversalTime(@AppointmentDateTime) < EndOfAppointmentDateTime)
              OR (DATEADD(MINUTE, 
                   (SELECT TOP 1 MedicalConsultationMinutesForPatients FROM ConsultingTime), dbo.UfnToUniversalTime(@AppointmentDateTime)) 
                  > AppointmentDateTime 
                  AND DATEADD(MINUTE, 
                   (SELECT TOP 1 MedicalConsultationMinutesForPatients FROM ConsultingTime), dbo.UfnToUniversalTime(@AppointmentDateTime)) 
                  <= EndOfAppointmentDateTime)
              OR (dbo.UfnToUniversalTime(@AppointmentDateTime) <= AppointmentDateTime AND DATEADD(MINUTE, 
                   (SELECT TOP 1 MedicalConsultationMinutesForPatients FROM ConsultingTime), dbo.UfnToUniversalTime(@AppointmentDateTime)) 
                  >= EndOfAppointmentDateTime)
          )
    )
    THEN 1
    ELSE 0
    END AS IsOverlapping", new {IDDoctor,AppointmentDateTime }).ConfigureAwait(false);

        public async Task InsertMedicalAppointmentCalendar(MedicalAppointmentCalendar medicalAppointmentCalendar)
            => await _con.ExecuteAsync(@"INSERT INTO MedicalAppointmentCalendar 
                (IDPatient,IDDoctor,AppointmentDateTime,ReasonForVisit,Notes,EndOfAppointmentDateTime,TypeOfAppointment) 
                VALUES(@IDPatient,@IDDoctor,dbo.UfnToUniversalTime(@AppointmentDateTime),@ReasonForVisit,@Notes,(SELECT DATEADD(MINUTE, (SELECT TOP 1 MedicalConsultationMinutesForPatients  FROM ConsultingTime), dbo.UfnToUniversalTime(@AppointmentDateTime))),@TypeOfAppointment)", 
                new
                {
                    medicalAppointmentCalendar.IDPatient,
                    medicalAppointmentCalendar.IDDoctor,
                    medicalAppointmentCalendar.AppointmentDateTime,
                    medicalAppointmentCalendar.ReasonForVisit,
                    medicalAppointmentCalendar.Notes,
                    medicalAppointmentCalendar.TypeOfAppointment
                }).ConfigureAwait(false);

        public async Task UpdateMedicalAppointmentCalendar(MedicalAppointmentCalendar medicalAppointmentCalendar)
            => await _con.ExecuteAsync(@"UPDATE MedicalAppointmentCalendar 
                SET 
                IDDoctor = @IDDoctor, 
                AppointmentDateTime = dbo.UfnToUniversalTime(@AppointmentDateTime), 
                ReasonForVisit = @ReasonForVisit, 
                AppointmentStatus = 'Activa', 
                EndOfAppointmentDateTime = (SELECT DATEADD(MINUTE, (SELECT TOP 1 MedicalConsultationMinutesForPatients  FROM ConsultingTime), dbo.UfnToUniversalTime(@AppointmentDateTime))), 
                UpdatedAt = GETUTCDATE(), 
                TypeOfAppointment = @TypeOfAppointment 
            WHERE Id = @Id;", new
            {
                medicalAppointmentCalendar.IDDoctor,
                medicalAppointmentCalendar.AppointmentDateTime,
                medicalAppointmentCalendar.ReasonForVisit,
                medicalAppointmentCalendar.TypeOfAppointment,
                medicalAppointmentCalendar.Id
            }).ConfigureAwait(false);
        
        public async Task <IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDPatient(long IdPatient)
            => await _con.QueryAsync<MedicalAppointmentCalendar>(@"
            SELECT 
            Mac.[Id]
            ,Mac.[IDPatient]
            ,CONCAT(Pd.Name,' ',Pd.FathersSurname,' ',Pd.MothersSurname) AS [patientName]
            ,Mac.[IDDoctor]
            ,CONCAT(Doc.FirstName,' ',Doc.LastName) AS [doctorName]
            ,dbo.[UfnToLocalTime](Mac.[AppointmentDateTime]) AS [AppointmentDateTime]
            ,Mac.[ReasonForVisit]
            ,Mac.[AppointmentStatus]
            ,Mac.[Notes]
            ,dbo.[UfnToLocalTime](Mac.[EndOfAppointmentDateTime]) AS [EndOfAppointmentDateTime]
            ,dbo.[UfnToLocalTime](Mac.[CreatedAt]) AS [CreatedAt]
            ,dbo.[UfnToLocalTime](Mac.[UpdatedAt]) AS [UpdatedAt]
            ,Mac.[TypeOfAppointment]
            FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] Mac
            INNER JOIN PatientData Pd
            ON Mac.IDPatient = [Pd].ID
            INNER JOIN Doctors Doc
            ON Mac.IDDoctor = Doc.ID
            WHERE Mac.IDPatient = @IdPatient 
            ORDER BY Mac.AppointmentDateTime DESC",
            new { IdPatient }).ConfigureAwait(false);
        /*
        public async Task <IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDPatient(long IdPatient)
            => await _con.QueryAsync<MedicalAppointmentCalendar>(@"
            SELECT [Id]
                  ,[IDPatient]
                  ,[IDDoctor]
                  ,dbo.[UfnToLocalTime]([AppointmentDateTime]) AS [AppointmentDateTime]
                  ,[ReasonForVisit]
                  ,[AppointmentStatus]
                  ,[Notes]
                  ,dbo.[UfnToLocalTime]([EndOfAppointmentDateTime]) AS [EndOfAppointmentDateTime]
                  ,dbo.[UfnToLocalTime]([CreatedAt]) AS [CreatedAt]
                  ,dbo.[UfnToLocalTime]([UpdatedAt]) AS [UpdatedAt]
                  ,[TypeOfAppointment]
              FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] 
              WHERE IDPatient = @IdPatient ORDER BY AppointmentDateTime DESC", new { IdPatient }).ConfigureAwait(false);
*/
        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDDoctor(long IdDoctor)
            => await _con.QueryAsync<MedicalAppointmentCalendar>(@"
            SELECT 
            Mac.[Id]
            ,Mac.[IDPatient]
            ,CONCAT(Pd.Name,' ',Pd.FathersSurname,' ',Pd.MothersSurname) AS [patientName]
            ,Mac.[IDDoctor]
            ,CONCAT(Doc.FirstName,' ',Doc.LastName) AS [doctorName]
            ,dbo.[UfnToLocalTime](Mac.[AppointmentDateTime]) AS [AppointmentDateTime]
            ,Mac.[ReasonForVisit]
            ,Mac.[AppointmentStatus]
            ,Mac.[Notes]
            ,dbo.[UfnToLocalTime](Mac.[EndOfAppointmentDateTime]) AS [EndOfAppointmentDateTime]
            ,dbo.[UfnToLocalTime](Mac.[CreatedAt]) AS [CreatedAt]
            ,dbo.[UfnToLocalTime](Mac.[UpdatedAt]) AS [UpdatedAt]
            ,Mac.[TypeOfAppointment]
            FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] Mac
            INNER JOIN PatientData Pd
            ON Mac.IDPatient = [Pd].ID
            INNER JOIN Doctors Doc
            ON Mac.IDDoctor = Doc.ID
            WHERE Mac.IDDoctor = @IdDoctor AND Mac.AppointmentStatus = 'Activa' 
            ORDER BY Mac.AppointmentDateTime DESC",
            new { IdDoctor }).ConfigureAwait(false);
        
        /*
        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarListByIDDoctor(long IdDoctor)
            => await _con.QueryAsync<MedicalAppointmentCalendar>(@"
        SELECT [Id]
      ,[IDPatient]
      ,[IDDoctor]
      ,dbo.[UfnToLocalTime]([AppointmentDateTime]) AS [AppointmentDateTime]
      ,[ReasonForVisit]
      ,[AppointmentStatus]
      ,[Notes]
      ,dbo.[UfnToLocalTime]([EndOfAppointmentDateTime]) AS [EndOfAppointmentDateTime]
      ,dbo.[UfnToLocalTime]([CreatedAt]) AS [CreatedAt]
      ,dbo.[UfnToLocalTime]([UpdatedAt]) AS [UpdatedAt]
      ,[TypeOfAppointment]
        FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] 
        WHERE IDDoctor = @IdDoctor AND AppointmentStatus = 'Activa' 
        ORDER BY AppointmentDateTime DESC", new { IdDoctor }).ConfigureAwait(false);
*/
        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetAllsMedicalAppointmentCalendar()
            => await _con.QueryAsync<MedicalAppointmentCalendar>(@"
            SELECT Mac.[Id]
            ,Mac.[IDPatient]
            ,CONCAT(Pd.Name,' ',Pd.FathersSurname,' ',Pd.MothersSurname) AS [patientName]
            ,Mac.[IDDoctor]
            ,CONCAT(Doc.FirstName,' ',Doc.LastName) AS [doctorName]
            ,dbo.[UfnToLocalTime](Mac.[AppointmentDateTime]) AS [AppointmentDateTime]
            ,Mac.[ReasonForVisit]
            ,Mac.[AppointmentStatus]
            ,Mac.[Notes]
            ,dbo.[UfnToLocalTime]([EndOfAppointmentDateTime]) AS [EndOfAppointmentDateTime]
            ,dbo.[UfnToLocalTime](Mac.[CreatedAt]) AS [CreatedAt]
            ,dbo.[UfnToLocalTime](Mac.[UpdatedAt]) AS [UpdatedAt]
            ,Mac.[TypeOfAppointment]
            FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] Mac
            INNER JOIN PatientData Pd
            ON Mac.IDPatient = [Pd].ID
            INNER JOIN Doctors Doc
            ON Mac.IDDoctor = Doc.ID
            ORDER BY Mac.AppointmentDateTime DESC",
            new { }).ConfigureAwait(false);

        /*
        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetAllsMedicalAppointmentCalendar()
            => await _con.QueryAsync<MedicalAppointmentCalendar>(@"
        SELECT 
        [Id]
      ,[IDPatient]
      ,[IDDoctor]
      ,dbo.[UfnToLocalTime]([AppointmentDateTime]) AS [AppointmentDateTime]
      ,[ReasonForVisit]
      ,[AppointmentStatus]
      ,[Notes]
      ,dbo.[UfnToLocalTime]([EndOfAppointmentDateTime]) AS [EndOfAppointmentDateTime]
      ,dbo.[UfnToLocalTime]([CreatedAt]) AS [CreatedAt]
      ,dbo.[UfnToLocalTime]([UpdatedAt]) AS [UpdatedAt]
      ,[TypeOfAppointment]
  FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar] 
  ORDER BY AppointmentDateTime DESC", new { }).ConfigureAwait(false);
        */
        #endregion

        #region Configuracion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<LaboralDays> GetLaboralDayByID(int Id)
            => await _con.QuerySingleAsync<LaboralDays>("SELECT * FROM LaboralDays WHERE Id = @Id", new { Id }).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LaboralDays>> GetLaboralDaysList()
            => await _con.QueryAsync<LaboralDays>("SELECT *  FROM [Medical.Office.SqlLocalDB].[dbo].[LaboralDays]").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="laboralDays"></param>
        /// <returns></returns>
        public async Task UpdateLaboralDaysById(LaboralDays laboralDays)
            => await _con.ExecuteAsync("UPDATE [LaboralDays] SET [Laboral] = @Laboral, [OpeningTime] = @OpeningTime, [ClosingTime] = @ClosingTime WHERE [Id] = @Id;", new { laboralDays .Laboral, laboralDays.OpeningTime, laboralDays .ClosingTime, laboralDays .Id}).ConfigureAwait(false);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeOfAppointment"></param>
        /// <returns></returns>
        public async Task InsertTypeOfAppointment(string typeOfAppointment)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[TypeOfAppointment]([NameTypeOfAppointment])VALUES(@typeOfAppointment)", new {typeOfAppointment}).ConfigureAwait(false);

        public async Task <IEnumerable<TypeOfAppointment>> GetTypeOfAppointmentsList()
            => await _con.QueryAsync<TypeOfAppointment>("SELECT [Id] ,[NameTypeOfAppointment] FROM [Medical.Office.SqlLocalDB].[dbo].[TypeOfAppointment]").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usr"></param>
        /// <returns></returns>
        public async Task<LoginHistory> GetLoginHistoryByUsr(string Usr)
            => await _con.QueryFirstAsync<LoginHistory>(@"SELECT TOP (1) [Id]
              ,[Usr]
              ,[UsrName]
              ,[UsrToken]
              ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
          FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] WHERE Usr = @Usr ORDER BY DateTimeSnap DESC", new { Usr }).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<LaboralDays> GetTodaysWorkSchedule()
            => await _con.QuerySingleAsync<LaboralDays>("SELECT *  FROM [Medical.Office.SqlLocalDB].[dbo].[LaboralDays] WHERE [Days] = (SELECT * FROM TodayInLettersView);").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LaboralDays>> GetWorkSchedule()
            => await _con.QueryAsync<LaboralDays>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[LaboralDays] ORDER BY Id ASC;").ConfigureAwait(false);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="laboralDays"></param>
        /// <returns></returns>
        public async Task UpdateWorkSchedule(LaboralDays laboralDays)
            => await _con.ExecuteAsync("UPDATE LaboralDays SET [Laboral] = @Laboral,OpeningTime = @OpeningTime, ClosingTime = @ClosingTime WHERE [Days] = @Days", new {laboralDays.Laboral,laboralDays.OpeningTime,laboralDays.ClosingTime, laboralDays.Days}).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<OfficeSetup> GetOfficeSetup()
            => await _con.QueryFirstAsync<OfficeSetup>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[OfficeSetup]").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="NameOfOffice"></param>
        /// <param name="Address"></param>
        /// <param name="OpeningTime"></param>
        /// <param name="ClosingTime"></param>
        /// <returns></returns>
        public async Task InsertOfficeSetup(string NameOfOffice, string Address)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[OfficeSetup]" +
                "([NameOfOffice],[Address])" +
                "VALUES(@NameOfOffice, @Address)",
                new { NameOfOffice, Address }).ConfigureAwait(false);

        public async Task UpdateOfficeSetup(OfficeSetup officeSetup)
            => await _con.ExecuteAsync("UPDATE OfficeSetup SET NameOfOffice = @NameOfOffice , [Address] = @Address WHERE Id = 1", new {officeSetup.NameOfOffice,officeSetup.Address }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Genders>> GetGenders()
            => await _con.QueryAsync<Genders>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Genders]").ConfigureAwait(false);

        public async Task StartInsertGenders()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Genders] (Gender) VALUES ('Masculino'),('Femenino');").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserStatuses>> GetUserStatuses()
            => await _con.QueryAsync<UserStatuses>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[UserStatuses]").ConfigureAwait(false);

        public async Task StartInsertUserStatuses()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[UserStatuses] (TypeUserStatuses) VALUES ('Activo'),('Inactivo');").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Roles>> GetRoles()
            => await _con.QueryAsync<Roles>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Roles]").ConfigureAwait(false);

        public async Task StartInsertRoles()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Roles] (RolesName) VALUES ('Programador'),('Doctor'),('Enfermera'),('Secretaria'),('Asistente');").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Positions>> GetPositions()
            => await _con.QueryAsync<Positions>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Positions]").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task StartInsertPositions()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Positions] (PositionName) VALUES ('Programador');").ConfigureAwait(false);

        public async Task StartInsertPositions(string PositionName)
    => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Positions] (PositionName) VALUES (@PositionName);", new { PositionName }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public async Task InsertPositions(string position)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Positions] (PositionName) VALUES (@position);", new { position }).ConfigureAwait(false);


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Specialties>> GetSpecialties()
            => await _con.QueryAsync<Specialties>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Specialties]").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task InsertSpecialties()
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Specialties] (Specialty) VALUES ('Desarollador');").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="specialtie"></param>
        /// <returns></returns>
        public async Task InsertSpecialties(string specialtie)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Specialties] (Specialty) VALUES (@specialtie);", new { specialtie }).ConfigureAwait(false);

        public async Task<IEnumerable<TypeOfAppointment>> GetTypeOfAppointment()
            => await _con.QueryAsync<TypeOfAppointment>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[TypeOfAppointment]").ConfigureAwait(false);

        #region Users
        /// <summary>
        ///
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Users> GetDataUserById(long Id) =>
                        await _con.QuerySingleAsync<Users>(@"SELECT [Id]
                      ,[Usr]
                      ,[Psswd]
                      ,[Name]
                      ,[Lastname]
                      ,[Role]
                      ,[Position]
                      ,[Status]
                      ,[Specialtie]
                      ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap]
                  FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Id = @Id;", new { Id }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <returns></returns>
                    public async Task<Users> GetDataUserByUsr(string Usr) =>
                    await _con.QuerySingleAsync<Users>(@"SELECT TOP (1) [Id]
      ,[Usr]
      ,[Psswd]
      ,[Name]
      ,[Lastname]
      ,[Role]
      ,[Position]
      ,[Status]
      ,[Specialtie]
      ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr;", new { Usr }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <returns></returns>
                    public async Task<IEnumerable<Users>> GetDataUserByUsrList(string Usr) =>
                    await _con.QueryAsync<Users>(@"SELECT [Id]
                      ,[Usr]
                      ,[Name]
                      ,[Lastname]
                      ,[Role]
                      ,[Position]
                      ,[Status]
                      ,[Specialtie]
                      ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap]
                  FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr Like @Usr;", new { Usr = $"%{Usr}%" }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <returns></returns>
                    public async Task<IEnumerable<Users>> GetUsers() =>
                                await _con.QueryAsync<Users>(@"SELECT [Id]
                                  ,[Usr]
                                  ,[Psswd]
                                  ,[Name]
                                  ,[Lastname]
                                  ,[Role]
                                  ,[Position]
                                  ,[Status]
                                  ,[Specialtie]
                                  ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap]
                              FROM [Medical.Office.SqlLocalDB].[dbo].[Users]", new { }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <param name="Psswd"></param>
                    /// <returns></returns>
                    public async Task<Users> LoginUser(string Usr, string Psswd) =>
                        await _con.QuerySingleAsync<Users>(@"SELECT TOP (1) 
                            [Id]
                          ,[Usr]
                          ,[Psswd]
                          ,[Name]
                          ,[Lastname]
                          ,[Role]
                          ,[Position]
                          ,[Status]
                          ,[Specialtie]
                          ,dbo.ufntolocaltime([TimeSnap]) AS [TimeSnap] 
                            FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr AND Psswd = @Psswd;", new { Usr, Psswd }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <param name="Psswd"></param>
                    /// <param name="Name"></param>
                    /// <param name="Lastname"></param>
                    /// <param name="Role"></param>
                    /// <param name="Position"></param>
                    /// <param name="Status"></param>
                    /// <param name="Specialtie"></param>
                    /// <returns></returns>
                    public async Task<Users> RegisterUsers(string Usr, string Psswd, string Name, string Lastname, string Role, string Position, string Specialtie) =>
                        await _con.QuerySingleAsync<Users>("INSERT INTO [dbo].[Users] " +
                            "([Usr], [Psswd] ,[Name] ,[Lastname] ,[Role] ,[Position],[Specialtie]) " +
                            "VALUES(@Usr, @Psswd, @Name, @Lastname, @Role, @Position, @Specialtie);", new { Usr, Psswd, Name, Lastname, Role, Position, Specialtie }).ConfigureAwait(false);

                    public async Task UpdateUsers(Users users)
                        => await _con.ExecuteAsync(@"UPDATE [Medical.Office.SqlLocalDB].[dbo].[Users] 
                        SET Psswd = @Psswd, [Name] = @Name, [Role] = @Role, [Position] = @Position, [Status] = @Status, Specialtie = @Specialtie, TimeSnap = GETUTCDATE() 
                        WHERE Id = @Id", new {users.Psswd,users.Name,users.Role,users.Position,users.Status,users.Specialtie,users.Id }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <returns></returns>
                    public async Task<IEnumerable<LoginHistory>> GetLoginHistory()
                        => await _con.QueryAsync<LoginHistory>(@"SELECT  [Id]
                          ,[Usr]
                          ,[UsrName]
                          ,[UsrToken]
                          ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
                      FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] ORDER BY DateTimeSnap DESC;").ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Param"></param>
                    /// <param name="StartDate"></param>
                    /// <param name="EndDate"></param>
                    /// <returns></returns>
                    public async Task<IEnumerable<LoginHistory>> GetLoginHistoryByParams(string Param, DateTime StartDate, DateTime EndDate)
                        => await _con.QueryAsync<LoginHistory>(@"
                        SELECT [Id]
                        ,[Usr]
                        ,[UsrName]
                        ,[UsrToken]
                        ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
                        FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] 
                        WHERE (Usr LIKE @Param OR UsrName LIKE @Param) 
                        AND (@StartDate IS NULL OR @EndDate IS NULL OR DateTimeSnap 
                        BETWEEN @StartDate AND @EndDate) 
                        ORDER BY DateTimeSnap ASC;", new { Param = $"%{Param}%", StartDate, EndDate }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <param name="UsrName"></param>
                    /// <param name="Token"></param>
                    /// <returns></returns>
                    public async Task InsertLoginHistory(string Usr, string UsrName, string Token)
                        => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] " +
                            "(Usr,UsrName,UsrToken) " +
                            "VALUES(@Usr,@UsrName,@Token);", new { Usr, UsrName, Token }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <returns></returns>
                    public async Task<IEnumerable<UsersMovements>> GetUsersMovements()
                        => await _con.QueryAsync<UsersMovements>(@"
                        SELECT
                        [Id]
                        ,[Usr]
                        ,[UsrName]
                        ,[UsrRole]
                        ,[UsrMovement]
                        ,[UsrToken]
                        ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
                        FROM [Medical.Office.SqlLocalDB].[dbo].[UsersMovements];").ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Param"></param>
                    /// <param name="StartDate"></param>
                    /// <param name="EndDate"></param>
                    /// <returns></returns>
                    public async Task<IEnumerable<UsersMovements>> GetUsersMovementsByParams(string Param, DateTime StartDate, DateTime EndDate)
                        => await _con.QueryAsync<UsersMovements>(@"SELECT 
                            [Id]
                            ,[Usr]
                            ,[UsrName]
                            ,[UsrRole]
                            ,[UsrMovement]
                            ,[UsrToken]
                            ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
                            FROM [Medical.Office.SqlLocalDB].[dbo].[UsersMovements]
                            WHERE (Usr LIKE @Param OR UsrName 
                            LIKE @Param) AND (@StartDate IS NULL OR @EndDate IS NULL OR DateTimeSnap 
                            BETWEEN @StartDate AND @EndDate) 
                            ORDER BY DateTimeSnap ASC", new { Param = $"%{Param}%", StartDate, EndDate }).ConfigureAwait(false);

                    /// <summary>
                    ///
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <param name="UsrName"></param>
                    /// <param name="UsrRole"></param>
                    /// <param name="UsrMovement"></param>
                    /// <param name="Token"></param>
                    /// <returns></returns>
                    public async Task InsertUsersMovements(string Usr, string UsrName, string UsrRole, string UsrMovement, string? Token)
                        => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[UsersMovements] " +
                            "(Usr,UsrName,UsrRole,UsrMovement,UsrToken) " +
                            "VALUES (@Usr,@UsrName,@UsrRole,@UsrMovement,@Token);", new { Usr, UsrName, UsrRole, UsrMovement, Token }).ConfigureAwait(false);

                    #endregion



        #endregion

        #region MedicalOffice

        /// <summary>
        ///
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Specialty"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public async Task InsertDoctors(string FirstName, string LastName, string Specialty, string PhoneNumber, string Email)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Doctors]" +
                "([FirstName],[LastName],[Specialty],[PhoneNumber],[Email])" +
                "VALUES(@FirstName,@LastName,@Specialty,@PhoneNumber,@Email);",
            new { FirstName, LastName, Specialty, PhoneNumber, Email }).ConfigureAwait(false);

        public async Task UpdateDoctor(Doctors doctor)
            => await _con.ExecuteAsync(@"Update Doctors SET FirstName = @FirstName, LastName = @LastName, Specialty = @Specialty, PhoneNumber = @PhoneNumber, Email = @Email, UpdatedAt = GETUTCDATE() WHERE ID = @ID;", new {doctor.FirstName, doctor.LastName, doctor.Specialty, doctor .PhoneNumber, doctor.Email,doctor.ID}).ConfigureAwait(false);


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Doctors>> GetDoctors()
            => await _con.QueryAsync<Doctors>(@"SELECT [ID]
                                                  ,[FirstName]
                                                  ,[LastName]
                                                  ,[Specialty]
                                                  ,[PhoneNumber]
                                                  ,[Email]
                                                  ,dbo.ufntolocaltime([CreatedAt]) AS [CreatedAt]
                                                  ,dbo.ufntolocaltime([UpdatedAt]) AS [UpdatedAt]
                                              FROM [Medical.Office.SqlLocalDB].[dbo].[Doctors]").ConfigureAwait(false);

        public async Task<Doctors> GetDoctor(long IDDoctor)
            => await _con.QuerySingleAsync<Doctors>(@"SELECT [ID]
                                                      ,[FirstName]
                                                      ,[LastName]
                                                      ,[Specialty]
                                                      ,[PhoneNumber]
                                                      ,[Email]
                                                      ,dbo.ufntolocaltime([CreatedAt]) AS [CreatedAt]
                                                        ,dbo.ufntolocaltime([UpdatedAt]) AS [UpdatedAt]
                                                  FROM [Medical.Office.SqlLocalDB].[dbo].[Doctors] WHERE ID = @IDDoctor", new { IDDoctor }).ConfigureAwait(false);
        
      
        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>


        /// <summary>
        ///
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="FathersSurname"></param>
        /// <param name="MothersSurname"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="Gender"></param>
        /// <param name="Address"></param>
        /// <param name="Country"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="ZipCode"></param>
        /// <param name="OutsideNumber"></param>
        /// <param name="InsideNumber"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
        /// <param name="EmergencyContactName"></param>
        /// <param name="EmergencyContactPhone"></param>
        /// <param name="InsuranceProvider"></param>
        /// <param name="PolicyNumber"></param>
        /// <param name="BloodType"></param>
        /// <param name="DateCreated"></param>
        /// <param name="LastUpdated"></param>
        /// <param name="Photo"></param>
        /// <param name="InternalNotes"></param>
        /// <returns></returns>
        public async Task InsertPatientData(string Name, string FathersSurname, string MothersSurname, DateTime? DateOfBirth, string Gender, string Address, string Country, string City, string State, string ZipCode, string OutsideNumber, string InsideNumber, string PhoneNumber, string Email, string EmergencyContactName, string EmergencyContactPhone, string InsuranceProvider, string PolicyNumber, string BloodType, byte[] Photo, string InternalNotes)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientData] " +
                "([Name], [FathersSurname], [MothersSurname], [DateOfBirth], [Gender], [Address], [Country], [City], [State], [ZipCode], [OutsideNumber], [InsideNumber], [PhoneNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], [InsuranceProvider], [PolicyNumber], [BloodType], [Photo], [InternalNotes]) " +
                "VALUES(@Name, @FathersSurname, @MothersSurname, @DateOfBirth, @Gender, @Address, @Country, @City, @State, @ZipCode, @OutsideNumber, @InsideNumber, @PhoneNumber, @Email, @EmergencyContactName, @EmergencyContactPhone, @InsuranceProvider, @PolicyNumber, @BloodType, @Photo, @InternalNotes)",
                new{Name,FathersSurname,MothersSurname,DateOfBirth,Gender,Address,Country,City,State,ZipCode,OutsideNumber,InsideNumber,PhoneNumber,Email,
                    EmergencyContactName,EmergencyContactPhone,InsuranceProvider,PolicyNumber,BloodType,Photo,InternalNotes}).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<PatientData> GetLastPatientsData()
             => await _con.QuerySingleAsync<PatientData>(@"SELECT TOP (1) [ID]
      ,[Name]
      ,[FathersSurname]
      ,[MothersSurname]
      ,[DateOfBirth]
      ,[Gender]
      ,[Address]
      ,[Country]
      ,[City]
      ,[State]
      ,[ZipCode]
      ,[OutsideNumber]
      ,[InsideNumber]
      ,[PhoneNumber]
      ,[Email]
      ,[EmergencyContactName]
      ,[EmergencyContactPhone]
      ,[InsuranceProvider]
      ,[PolicyNumber]
      ,[BloodType]
      ,dbo.ufntolocaltime([DateCreated]) AS [DateCreated]
      ,dbo.ufntolocaltime([LastUpdated]) AS [LastUpdated]
      ,[Photo]
      ,[InternalNotes]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientData] 
  ORDER BY ID DESC").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PatientData>> GetPatientsDataList()
            => await _con.QueryAsync<PatientData>(@"SELECT [ID]
      ,[Name]
      ,[FathersSurname]
      ,[MothersSurname]
      ,[DateOfBirth]
      ,[Gender]
      ,[Address]
      ,[Country]
      ,[City]
      ,[State]
      ,[ZipCode]
      ,[OutsideNumber]
      ,[InsideNumber]
      ,[PhoneNumber]
      ,[Email]
      ,[EmergencyContactName]
      ,[EmergencyContactPhone]
      ,[InsuranceProvider]
      ,[PolicyNumber]
      ,[BloodType]
      ,dbo.ufntolocaltime([DateCreated]) AS [DateCreated]
      ,dbo.ufntolocaltime([LastUpdated]) AS [LastUpdated]
      ,[Photo]
      ,[InternalNotes]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientData]").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<PatientData> GetPatientDataByIDPatient(long ID)
            => await _con.QuerySingleAsync<PatientData>(@"SELECT [ID]
      ,[Name]
      ,[FathersSurname]
      ,[MothersSurname]
      ,[DateOfBirth]
      ,[Gender]
      ,[Address]
      ,[Country]
      ,[City]
      ,[State]
      ,[ZipCode]
      ,[OutsideNumber]
      ,[InsideNumber]
      ,[PhoneNumber]
      ,[Email]
      ,[EmergencyContactName]
      ,[EmergencyContactPhone]
      ,[InsuranceProvider]
      ,[PolicyNumber]
      ,[BloodType]
      ,dbo.ufntolocaltime([DateCreated]) AS [DateCreated]
      ,dbo.ufntolocaltime([LastUpdated]) AS [LastUpdated]
      ,[Photo]
      ,[InternalNotes]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientData] WHERE ID = @ID", new {ID}).ConfigureAwait(false);

        #endregion

        #region AntecedentPatient
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientsFiles"></param>
        public async Task InsertPatientFiles(PatientsFiles patientsFiles)
            => await _con.ExecuteAsync(
                "INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientsFiles]([IDPatient],[FileName],[FileType],[FileExtension],[Description],[FileData])VALUES(@IDPatient,@FileName,@FileType,@FileExtension,@Description,@FileData)",
                new {patientsFiles.IDPatient,
                    patientsFiles.FileName,patientsFiles.FileType,patientsFiles.FileExtension,patientsFiles.Description,patientsFiles.FileData }).ConfigureAwait(false);

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="FileName"></param>
        /// <param name="FileType"></param>
        public async Task DeletePatientFiles(long IDPatient ,long Id)
            => await _con.ExecuteAsync("DELETE PatientsFiles WHERE IDPatient = @IDPatient AND [Id] = @Id",new {IDPatient,Id}).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PatientsFiles>> GetPatientsFilesListByIDPatient(long IDPatient)
        => await _con.QueryAsync<PatientsFiles>(@"SELECT [Id]
      ,[IDPatient]
      ,[FileName]
      ,[FileType]
      ,[FileExtension]
      ,[Description]
      ,dbo.ufntolocaltime([DateTimeUploaded]) AS [DateTimeUploaded]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientsFiles] WHERE IDPatient = @IDPatient", new {IDPatient}).ConfigureAwait(false);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<PatientsFiles> GetPatientFileByIDPatient(long IDPatient, long Id)
            => await _con.QueryFirstAsync<PatientsFiles>(@"SELECT [Id]
      ,[IDPatient]
      ,[FileName]
      ,[FileType]
      ,[FileExtension]
      ,[Description]
      ,[FileData]
      ,dbo.ufntolocaltime([DateTimeUploaded]) AS [DateTimeUploaded]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientsFiles] WHERE IDPatient = @IDPatient AND Id = @Id", new {IDPatient,Id}).ConfigureAwait(false);

        
        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="ActiveMedicationsData"></param>
        /// <returns></returns>
        public async Task InsertActiveMedications(long IDPatient, string ActiveMedicationsData)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[ActiveMedications] " +
                "([IDPatient],[ActiveMedicationsData]) " +
                "VALUES (@IDPatient,@ActiveMedicationsData)",
                new {IDPatient, ActiveMedicationsData }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<ActiveMedications> GetActiveMedicationsByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<ActiveMedications>(@"SELECT TOP 1 [Id]
      ,[IDPatient]
      ,[ActiveMedicationsData]
      ,dbo.ufntolocaltime([DateTimeSnap]) as [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[ActiveMedications] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Diabetes"></param>
        /// <param name="Cardiopathies"></param>
        /// <param name="Hypertension"></param>
        /// <param name="ThyroidDiseases"></param>
        /// <param name="ChronicKidneyDisease"></param>
        /// <param name="Others"></param>
        /// <param name="OthersData"></param>
        /// <returns></returns>
        public async Task InsertFamilyHistory(long IDPatient, bool? Diabetes, bool? Cardiopathies, bool? Hypertension, bool? ThyroidDiseases, bool? ChronicKidneyDisease, bool? Others, string? OthersData)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[FamilyHistory]" +
                "([IDPatient],[Diabetes],[Cardiopathies],[Hypertension],[ThyroidDiseases],[ChronicKidneyDisease],[Others],[OthersData])" +
                "VALUES(@IDPatient, @Diabetes, @Cardiopathies, @Hypertension, @ThyroidDiseases, @ChronicKidneyDisease, @Others, @OthersData)", 
                new { IDPatient, Diabetes, Cardiopathies, Hypertension, ThyroidDiseases, ChronicKidneyDisease, Others, OthersData }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<FamilyHistory> GetFamilyHistoryByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<FamilyHistory>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[Diabetes]
      ,[Cardiopathies]
      ,[Hypertension]
      ,[ThyroidDiseases]
      ,[ChronicKidneyDisease]
      ,[Others]
      ,[OthersData]
      ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[FamilyHistory] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="MedicalHistoryNotesData"></param>
        /// <returns></returns>
        public async Task InsertMedicalHistoryNotes(long IDPatient, string MedicalHistoryNotesData)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[MedicalHistoryNotes]" +
                "([IDPatient],[MedicalHistoryNotesData])" +
                "VALUES(@IDPatient,@MedicalHistoryNotesData);",
                new {IDPatient,MedicalHistoryNotesData}).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<MedicalHistoryNotes> GetMedicalHistoryNotesByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<MedicalHistoryNotes>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[MedicalHistoryNotesData]
      ,dbo.ufntolocaltime([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[MedicalHistoryNotes] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="PhysicalActivity"></param>
        /// <param name="Smoking"></param>
        /// <param name="Alcoholism"></param>
        /// <param name="SubstanceAbuse"></param>
        /// <param name="SubstanceAbuseData"></param>
        /// <param name="RecentVaccination"></param>
        /// <param name="RecentVaccinationData"></param>
        /// <param name="Others"></param>
        /// <param name="OthersData"></param>
        /// <returns></returns>
        public async Task InsertNonPathologicalHistory(long IDPatient, int? PhysicalActivity, int? Smoking, int? Alcoholism, int? SubstanceAbuse, string? SubstanceAbuseData, int? RecentVaccination, string? RecentVaccinationData, int? Others, string? OthersData)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[NonPathologicalHistory]" +
                "([IDPatient],[PhysicalActivity],[Smoking],[Alcoholism],[SubstanceAbuse],[SubstanceAbuseData],[RecentVaccination],[RecentVaccinationData],[Others],[OthersData])" +
                "VALUES(@IDPatient, @PhysicalActivity, @Smoking, @Alcoholism, @SubstanceAbuse, @SubstanceAbuseData, @RecentVaccination, @RecentVaccinationData, @Others, @OthersData )",
                new { IDPatient, PhysicalActivity, Smoking, Alcoholism, SubstanceAbuse, SubstanceAbuseData, RecentVaccination, RecentVaccinationData, Others, OthersData }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<NonPathologicalHistory> GetNonPathologicalHistoryByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<NonPathologicalHistory>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[PhysicalActivity]
      ,[Smoking]
      ,[Alcoholism]
      ,[SubstanceAbuse]
      ,[SubstanceAbuseData]
      ,[RecentVaccination]
      ,[RecentVaccinationData]
      ,[Others]
      ,[OthersData]
      ,dbo.[UfnToLocalTime]([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[NonPathologicalHistory] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="PreviousHospitalization"></param>
        /// <param name="PreviousSurgeries"></param>
        /// <param name="Diabetes"></param>
        /// <param name="ThyroidDiseases"></param>
        /// <param name="Hypertension"></param>
        /// <param name="Cardiopathies"></param>
        /// <param name="Trauma"></param>
        /// <param name="Cancer"></param>
        /// <param name="Tuberculosis"></param>
        /// <param name="Transfusions"></param>
        /// <param name="RespiratoryDiseases"></param>
        /// <param name="GastrointestinalDiseases"></param>
        /// <param name="STDs"></param>
        /// <param name="STDsData"></param>
        /// <param name="ChronicKidneyDisease"></param>
        /// <param name="Others"></param>
        /// <returns></returns>
        public async Task InsertPathologicalBackground(long IDPatient, int? PreviousHospitalization, int? PreviousSurgeries, int? Diabetes, int? ThyroidDiseases, int? Hypertension, int? Cardiopathies, int? Trauma, int? Cancer, int? Tuberculosis, int? Transfusions, int? RespiratoryDiseases, int? GastrointestinalDiseases, int? STDs, string? STDsData, int? ChronicKidneyDisease, string? Others)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PathologicalBackground]" +
                "([IDPatient],[PreviousHospitalization],[PreviousSurgeries],[Diabetes],[ThyroidDiseases],[Hypertension],[Cardiopathies],[Trauma],[Cancer],[Tuberculosis],[Transfusions],[RespiratoryDiseases],[GastrointestinalDiseases],[STDs],[STDsData],[ChronicKidneyDisease],[Others])" +
                "VALUES(@IDPatient, @PreviousHospitalization, @PreviousSurgeries, @Diabetes, @ThyroidDiseases, @Hypertension, @Cardiopathies, @Trauma, @Cancer, @Tuberculosis, @Transfusions, @RespiratoryDiseases, @GastrointestinalDiseases, @STDs, @STDsData, @ChronicKidneyDisease, @Others )",
                new { IDPatient, PreviousHospitalization, PreviousSurgeries, Diabetes, ThyroidDiseases,  Hypertension, Cardiopathies, Trauma, Cancer, Tuberculosis, Transfusions, RespiratoryDiseases, GastrointestinalDiseases, STDs, STDsData, ChronicKidneyDisease, Others }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<PathologicalBackground> GetPathologicalBackgroundByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<PathologicalBackground>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[PreviousHospitalization]
      ,[PreviousSurgeries]
      ,[Diabetes]
      ,[ThyroidDiseases]
      ,[Hypertension]
      ,[Cardiopathies]
      ,[Trauma]
      ,[Cancer]
      ,[Tuberculosis]
      ,[Transfusions]
      ,[RespiratoryDiseases]
      ,[GastrointestinalDiseases]
      ,[STDs]
      ,[STDsData]
      ,[ChronicKidneyDisease]
      ,[Others]
      ,dbo.[UfnToLocalTime]([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PathologicalBackground] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Allergies"></param>
        /// <returns></returns>
        public async Task InsertPatientAllergies(long IDPatient, string Allergies)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientAllergies]" +
                "([IDPatient],[Allergies])" +
                "VALUES(@IDPatient , @Allergies )",
                new { IDPatient , Allergies }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<PatientAllergies> GetPatientAllergiesByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<PatientAllergies>(@"SELECT TOP (1) [Id]
      ,[IDPatient]
      ,[Allergies]
      ,dbo.[UfnToLocalTime]([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientAllergies] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="FamilyHistory"></param>
        /// <param name="FamilyHistoryData"></param>
        /// <param name="AffectedAreas"></param>
        /// <param name="PastAndCurrentTreatments"></param>
        /// <param name="FamilySocialSupport"></param>
        /// <param name="FamilySocialSupportData"></param>
        /// <param name="WorkLifeAspects"></param>
        /// <param name="SocialLifeAspects"></param>
        /// <param name="AuthorityRelationship"></param>
        /// <param name="ImpulseControl"></param>
        /// <param name="FrustrationManagement"></param>
        /// <returns></returns>
        public async Task InsertPsychiatricHistory(long IDPatient, int? FamilyHistory, string? FamilyHistoryData, string? AffectedAreas, string? PastAndCurrentTreatments, int? FamilySocialSupport, string? FamilySocialSupportData, string? WorkLifeAspects, string? SocialLifeAspects, string? AuthorityRelationship, string? ImpulseControl, string? FrustrationManagement)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PsychiatricHistory]" +
                "([IDPatient],[FamilyHistory],[FamilyHistoryData],[AffectedAreas],[PastAndCurrentTreatments],[FamilySocialSupport],[FamilySocialSupportData],[WorkLifeAspects],[SocialLifeAspects],[AuthorityRelationship],[ImpulseControl],[FrustrationManagement])" +
                "VALUES(@IDPatient, @FamilyHistory, @FamilyHistoryData, @AffectedAreas, @PastAndCurrentTreatments, @FamilySocialSupport, @FamilySocialSupportData, @WorkLifeAspects, @SocialLifeAspects, @AuthorityRelationship, @ImpulseControl, @FrustrationManagement )",
                new { IDPatient, FamilyHistory, FamilyHistoryData, AffectedAreas, PastAndCurrentTreatments, FamilySocialSupport, FamilySocialSupportData, WorkLifeAspects, SocialLifeAspects, AuthorityRelationship, ImpulseControl, FrustrationManagement }).ConfigureAwait(false);
        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<PsychiatricHistory> GetPsychiatricHistoryByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<PsychiatricHistory>(@"SELECT TOP (1) [id]
      ,[IDPatient]
      ,[FamilyHistory]
      ,[FamilyHistoryData]
      ,[AffectedAreas]
      ,[PastAndCurrentTreatments]
      ,[FamilySocialSupport]
      ,[FamilySocialSupportData]
      ,[WorkLifeAspects]
      ,[SocialLifeAspects]
      ,[AuthorityRelationship]
      ,[ImpulseControl]
      ,[FrustrationManagement]
      ,dbo.[UfnToLocalTime]([DateTimeSnap]) AS [DateTimeSnap]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PsychiatricHistory] WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        #region Update Methods

        /// <summary>
        /// Actualiza la información de los medicamentos activos de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="ActiveMedicationsData"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdateActiveMedications(long IDPatient, string ActiveMedicationsData, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[ActiveMedications]
                            SET ActiveMedicationsData = @ActiveMedicationsData,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, ActiveMedicationsData, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza la historia familiar de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Diabetes"></param>
        /// <param name="Cardiopathies"></param>
        /// <param name="Hypertension"></param>
        /// <param name="ThyroidDiseases"></param>
        /// <param name="ChronicKidneyDisease"></param>
        /// <param name="Others"></param>
        /// <param name="OthersData"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdateFamilyHistory(long IDPatient, bool? Diabetes, bool? Cardiopathies, bool? Hypertension,
            bool? ThyroidDiseases, bool? ChronicKidneyDisease, bool? Others, string OthersData, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[FamilyHistory]
                            SET Diabetes = @Diabetes,
                                Cardiopathies = @Cardiopathies,
                                Hypertension = @Hypertension,
                                ThyroidDiseases = @ThyroidDiseases,
                                ChronicKidneyDisease = @ChronicKidneyDisease,
                                Others = @Others,
                                OthersData = @OthersData,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, Diabetes, Cardiopathies, Hypertension, ThyroidDiseases, ChronicKidneyDisease, Others, OthersData, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza las notas de la historia médica de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="MedicalHistoryNotesData"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdateMedicalHistoryNotes(long IDPatient, string MedicalHistoryNotesData, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[MedicalHistoryNotes]
                                SET MedicalHistoryNotesData = @MedicalHistoryNotesData,
                                    DateTimeSnap = @DateTimeSnap
                                WHERE IDPatient = @IDPatient;",
                                        new { IDPatient, MedicalHistoryNotesData, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza la historia no patológica de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="PhysicalActivity"></param>
        /// <param name="Smoking"></param>
        /// <param name="Alcoholism"></param>
        /// <param name="SubstanceAbuse"></param>
        /// <param name="SubstanceAbuseData"></param>
        /// <param name="RecentVaccination"></param>
        /// <param name="RecentVaccinationData"></param>
        /// <param name="Others"></param>
        /// <param name="OthersData"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdateNonPathologicalHistory(long IDPatient, int PhysicalActivity, int Smoking, int Alcoholism,
            int SubstanceAbuse, string SubstanceAbuseData, int RecentVaccination, string RecentVaccinationData,
            int Others, string OthersData, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[NonPathologicalHistory]
                            SET PhysicalActivity = @PhysicalActivity,
                                Smoking = @Smoking,
                                Alcoholism = @Alcoholism,
                                SubstanceAbuse = @SubstanceAbuse,
                                SubstanceAbuseData = @SubstanceAbuseData,
                                RecentVaccination = @RecentVaccination,
                                RecentVaccinationData = @RecentVaccinationData,
                                Others = @Others,
                                OthersData = @OthersData,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, PhysicalActivity, Smoking, Alcoholism, SubstanceAbuse, SubstanceAbuseData, RecentVaccination, RecentVaccinationData, Others, OthersData, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza el historial patológico de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="PreviousHospitalization"></param>
        /// <param name="PreviousSurgeries"></param>
        /// <param name="Diabetes"></param>
        /// <param name="ThyroidDiseases"></param>
        /// <param name="Hypertension"></param>
        /// <param name="Cardiopathies"></param>
        /// <param name="Trauma"></param>
        /// <param name="Cancer"></param>
        /// <param name="Tuberculosis"></param>
        /// <param name="Transfusions"></param>
        /// <param name="RespiratoryDiseases"></param>
        /// <param name="GastrointestinalDiseases"></param>
        /// <param name="STDs"></param>
        /// <param name="STDsData"></param>
        /// <param name="ChronicKidneyDisease"></param>
        /// <param name="Others"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdatePathologicalBackground(long IDPatient, int PreviousHospitalization, int PreviousSurgeries,
            int Diabetes, int ThyroidDiseases, int Hypertension, int Cardiopathies, int Trauma,
            int Cancer, int Tuberculosis, int Transfusions, int RespiratoryDiseases,
            int GastrointestinalDiseases, int STDs, string STDsData, int ChronicKidneyDisease,
            string Others, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[PathologicalBackground]
                            SET PreviousHospitalization = @PreviousHospitalization,
                                PreviousSurgeries = @PreviousSurgeries,
                                Diabetes = @Diabetes,
                                ThyroidDiseases = @ThyroidDiseases,
                                Hypertension = @Hypertension,
                                Cardiopathies = @Cardiopathies,
                                Trauma = @Trauma,
                                Cancer = @Cancer,
                                Tuberculosis = @Tuberculosis,
                                Transfusions = @Transfusions,
                                RespiratoryDiseases = @RespiratoryDiseases,
                                GastrointestinalDiseases = @GastrointestinalDiseases,
                                STDs = @STDs,
                                STDsData = @STDsData,
                                ChronicKidneyDisease = @ChronicKidneyDisease,
                                Others = @Others,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, PreviousHospitalization, PreviousSurgeries, Diabetes, ThyroidDiseases, Hypertension, Cardiopathies, Trauma, Cancer, Tuberculosis, Transfusions, RespiratoryDiseases, GastrointestinalDiseases, STDs, STDsData, ChronicKidneyDisease, Others, DateTimeSnap }).ConfigureAwait(false);
    }

        /// <summary>
        /// Actualiza las alergias de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="Allergies"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdatePatientAllergies(long IDPatient, string Allergies, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[PatientAllergies]
                            SET Allergies = @Allergies,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                                    new { IDPatient, Allergies, DateTimeSnap }).ConfigureAwait(false);
        }

        /// <summary>
        /// Actualiza la historia psiquiátrica de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="FamilyHistory"></param>
        /// <param name="FamilyHistoryData"></param>
        /// <param name="AffectedAreas"></param>
        /// <param name="PastAndCurrentTreatments"></param>
        /// <param name="FamilySocialSupport"></param>
        /// <param name="FamilySocialSupportData"></param>
        /// <param name="WorkLifeAspects"></param>
        /// <param name="SocialLifeAspects"></param>
        /// <param name="AuthorityRelationship"></param>
        /// <param name="ImpulseControl"></param>
        /// <param name="FrustrationManagement"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdatePsychiatricHistory(long IDPatient, int FamilyHistory, string FamilyHistoryData,
            string AffectedAreas, string PastAndCurrentTreatments, int FamilySocialSupport,
            string FamilySocialSupportData, string WorkLifeAspects, string SocialLifeAspects,
            string AuthorityRelationship, string ImpulseControl, string FrustrationManagement, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[PsychiatricHistory]
                            SET FamilyHistory = @FamilyHistory,
                                FamilyHistoryData = @FamilyHistoryData,
                                AffectedAreas = @AffectedAreas,
                                PastAndCurrentTreatments = @PastAndCurrentTreatments,
                                FamilySocialSupport = @FamilySocialSupport,
                                FamilySocialSupportData = @FamilySocialSupportData,
                                WorkLifeAspects = @WorkLifeAspects,
                                SocialLifeAspects = @SocialLifeAspects,
                                AuthorityRelationship = @AuthorityRelationship,
                                ImpulseControl = @ImpulseControl,
                                FrustrationManagement = @FrustrationManagement,
                                DateTimeSnap = @DateTimeSnap
                            WHERE IDPatient = @IDPatient;",
                            new { IDPatient, FamilyHistory, FamilyHistoryData, AffectedAreas, PastAndCurrentTreatments, FamilySocialSupport, FamilySocialSupportData, WorkLifeAspects, SocialLifeAspects, AuthorityRelationship, ImpulseControl, FrustrationManagement, DateTimeSnap }).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region POS
        // Obtener todos los registros
        public async Task<IEnumerable<CashMovements>> GetCashMovementsAsync()
            => await _con.QueryAsync<CashMovements>("SELECT * FROM CashMovements").ConfigureAwait(false);

        // Obtener un registro por ID
        public async Task<CashMovements> GetCashMovementByIdAsync(CashMovements cashMovements)
            => await _con.QuerySingleAsync<CashMovements>(
                "SELECT * FROM CashMovements WHERE CashMovementId = @CashMovementId",
                new { cashMovements.CashMovementId }).ConfigureAwait(false);

        // Insertar un registro
        public async Task InsertCashMovementAsync(CashMovements cashMovements)
            => await _con.ExecuteAsync(
                @"INSERT INTO CashMovements (CashRegisterId, MovementDate, MovementType, Amount, Description)
                  VALUES (@CashRegisterId, @MovementDate, @MovementType, @Amount, @Description)",
                cashMovements).ConfigureAwait(false);

        // Actualizar un registro
        public async Task UpdateCashMovementAsync(CashMovements cashMovements)
            => await _con.ExecuteAsync(
                @"UPDATE CashMovements
                  SET CashRegisterId = @CashRegisterId,
                      MovementDate = @MovementDate,
                      MovementType = @MovementType,
                      Amount = @Amount,
                      Description = @Description
                  WHERE CashMovementId = @CashMovementId",
                cashMovements).ConfigureAwait(false);

        // Eliminar un registro
        public async Task DeleteCashMovementAsync(CashMovements cashMovements)
            => await _con.ExecuteAsync(
                "DELETE FROM CashMovements WHERE CashMovementId = @CashMovementId",
                new { cashMovements.CashMovementId }).ConfigureAwait(false);

        // Obtener todos los registros
        public async Task<IEnumerable<CashRegisters>> GetCashRegistersAsync()
            => await _con.QueryAsync<CashRegisters>("SELECT * FROM CashRegisters").ConfigureAwait(false);

        // Obtener un registro por ID
        public async Task<CashRegisters> GetCashRegisterByIdAsync(CashRegisters cashRegisters)
            => await _con.QuerySingleAsync<CashRegisters>(
                "SELECT * FROM CashRegisters WHERE CashRegisterId = @CashRegisterId",
                new { cashRegisters.CashRegisterId }).ConfigureAwait(false);

        // Insertar un registro
        public async Task InsertCashRegisterAsync(CashRegisters cashRegisters)
            => await _con.ExecuteAsync(
                @"INSERT INTO CashRegisters (RegisterName, RegisterStatus, OpeningDate, ClosingDate, InitialBalance, FinalBalance)
                  VALUES (@RegisterName, @RegisterStatus, @OpeningDate, @ClosingDate, @InitialBalance, @FinalBalance)",
                cashRegisters).ConfigureAwait(false);

        // Actualizar un registro
        public async Task UpdateCashRegisterAsync(CashRegisters cashRegisters)
            => await _con.ExecuteAsync(
                @"UPDATE CashRegisters
                  SET RegisterName = @RegisterName,
                      RegisterStatus = @RegisterStatus,
                      OpeningDate = @OpeningDate,
                      ClosingDate = @ClosingDate,
                      InitialBalance = @InitialBalance,
                      FinalBalance = @FinalBalance
                  WHERE CashRegisterId = @CashRegisterId",
                cashRegisters).ConfigureAwait(false);

        // Eliminar un registro
        public async Task DeleteCashRegisterAsync(CashRegisters cashRegisters)
            => await _con.ExecuteAsync(
                "DELETE FROM CashRegisters WHERE CashRegisterId = @CashRegisterId",
                new { cashRegisters.CashRegisterId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de InventoryMovements.
        /// </summary>
        /// <returns>Una lista de InventoryMovements.</returns>
        public async Task<IEnumerable<InventoryMovements>> GetInventoryMovementsAsync()
            => await _con.QueryAsync<InventoryMovements>("SELECT * FROM InventoryMovements").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de InventoryMovements por ID.
        /// </summary>
        /// <param name="inventoryMovements">El objeto InventoryMovements con el ID especificado.</param>
        /// <returns>El registro de InventoryMovements encontrado.</returns>
        public async Task<InventoryMovements> GetInventoryMovementByIdAsync(InventoryMovements inventoryMovements)
            => await _con.QuerySingleAsync<InventoryMovements>(
                "SELECT * FROM InventoryMovements WHERE MovementId = @MovementId",
                new { inventoryMovements.MovementId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en InventoryMovements.
        /// </summary>
        /// <param name="inventoryMovements">El objeto InventoryMovements a insertar.</param>
        public async Task InsertInventoryMovementAsync(InventoryMovements inventoryMovements)
            => await _con.ExecuteAsync(
                @"INSERT INTO InventoryMovements (ProductId, MovementType, Quantity, MovementDate, Description)
          VALUES (@ProductId, @MovementType, @Quantity, @MovementDate, @Description)",
                inventoryMovements).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en InventoryMovements.
        /// </summary>
        /// <param name="inventoryMovements">El objeto InventoryMovements con los datos actualizados.</param>
        public async Task UpdateInventoryMovementAsync(InventoryMovements inventoryMovements)
            => await _con.ExecuteAsync(
                @"UPDATE InventoryMovements
          SET ProductId = @ProductId,
              MovementType = @MovementType,
              Quantity = @Quantity,
              MovementDate = @MovementDate,
              Description = @Description
          WHERE MovementId = @MovementId",
                inventoryMovements).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de InventoryMovements por ID.
        /// </summary>
        /// <param name="inventoryMovements">El objeto InventoryMovements con el ID especificado.</param>
        public async Task DeleteInventoryMovementAsync(InventoryMovements inventoryMovements)
            => await _con.ExecuteAsync(
                "DELETE FROM InventoryMovements WHERE MovementId = @MovementId",
                new { inventoryMovements.MovementId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de PaymentTypes.
        /// </summary>
        /// <returns>Una lista de PaymentTypes.</returns>
        public async Task<IEnumerable<PaymentTypes>> GetPaymentTypesAsync()
            => await _con.QueryAsync<PaymentTypes>("SELECT * FROM PaymentTypes").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de PaymentTypes por ID.
        /// </summary>
        /// <param name="paymentTypes">El objeto PaymentTypes con el ID especificado.</param>
        /// <returns>El registro de PaymentTypes encontrado.</returns>
        public async Task<PaymentTypes> GetPaymentTypeByIdAsync(PaymentTypes paymentTypes)
            => await _con.QuerySingleAsync<PaymentTypes>(
                "SELECT * FROM PaymentTypes WHERE Id = @Id",
                new { paymentTypes.Id }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en PaymentTypes.
        /// </summary>
        /// <param name="paymentTypes">El objeto PaymentTypes a insertar.</param>
        public async Task InsertPaymentTypeAsync(PaymentTypes paymentTypes)
            => await _con.ExecuteAsync(
                @"INSERT INTO PaymentTypes (PaymentTypeName)
          VALUES (@PaymentTypeName)",
                paymentTypes).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en PaymentTypes.
        /// </summary>
        /// <param name="paymentTypes">El objeto PaymentTypes con los datos actualizados.</param>
        public async Task UpdatePaymentTypeAsync(PaymentTypes paymentTypes)
            => await _con.ExecuteAsync(
                @"UPDATE PaymentTypes
          SET PaymentTypeName = @PaymentTypeName
          WHERE Id = @Id",
                paymentTypes).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de PaymentTypes por ID.
        /// </summary>
        /// <param name="paymentTypes">El objeto PaymentTypes con el ID especificado.</param>
        public async Task DeletePaymentTypeAsync(PaymentTypes paymentTypes)
            => await _con.ExecuteAsync(
                "DELETE FROM PaymentTypes WHERE Id = @Id",
                new { paymentTypes.Id }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de ProductCategories.
        /// </summary>
        /// <returns>Una lista de ProductCategories.</returns>
        public async Task<IEnumerable<ProductCategories>> GetProductCategoriesAsync()
            => await _con.QueryAsync<ProductCategories>("SELECT * FROM ProductCategories").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de ProductCategories por ID.
        /// </summary>
        /// <param name="productCategories">El objeto ProductCategories con el ID especificado.</param>
        /// <returns>El registro de ProductCategories encontrado.</returns>
        public async Task<ProductCategories> GetProductCategoryByIdAsync(ProductCategories productCategories)
            => await _con.QuerySingleAsync<ProductCategories>(
                "SELECT * FROM ProductCategories WHERE ProductCategoryId = @ProductCategoryId",
                new { productCategories.ProductCategoryId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en ProductCategories.
        /// </summary>
        /// <param name="productCategories">El objeto ProductCategories a insertar.</param>
        public async Task InsertProductCategoryAsync(ProductCategories productCategories)
            => await _con.ExecuteAsync(
                @"INSERT INTO ProductCategories (CategoryName)
          VALUES (@CategoryName)",
                productCategories).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en ProductCategories.
        /// </summary>
        /// <param name="productCategories">El objeto ProductCategories con los datos actualizados.</param>
        public async Task UpdateProductCategoryAsync(ProductCategories productCategories)
            => await _con.ExecuteAsync(
                @"UPDATE ProductCategories
          SET CategoryName = @CategoryName
          WHERE ProductCategoryId = @ProductCategoryId",
                productCategories).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de ProductCategories por ID.
        /// </summary>
        /// <param name="productCategories">El objeto ProductCategories con el ID especificado.</param>
        public async Task DeleteProductCategoryAsync(ProductCategories productCategories)
            => await _con.ExecuteAsync(
                "DELETE FROM ProductCategories WHERE ProductCategoryId = @ProductCategoryId",
                new { productCategories.ProductCategoryId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de Products.
        /// </summary>
        /// <returns>Una lista de Products.</returns>
        public async Task<IEnumerable<Products>> GetProductsAsync()
            => await _con.QueryAsync<Products>("SELECT * FROM Products").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de Products por ID.
        /// </summary>
        /// <param name="products">El objeto Products con el ID especificado.</param>
        /// <returns>El registro de Products encontrado.</returns>
        public async Task<Products> GetProductByIdAsync(Products products)
            => await _con.QuerySingleAsync<Products>(
                "SELECT * FROM Products WHERE ProductId = @ProductId",
                new { products.ProductId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en Products.
        /// </summary>
        /// <param name="products">El objeto Products a insertar.</param>
        public async Task InsertProductAsync(Products products)
            => await _con.ExecuteAsync(
                @"INSERT INTO Products (ProductName, Description, Price, Stock, ProductCategoryName, IDORBarcode)
          VALUES (@ProductName, @Description, @Price, @Stock, @ProductCategoryName, @IDORBarcode)",
                products).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en Products.
        /// </summary>
        /// <param name="products">El objeto Products con los datos actualizados.</param>
        public async Task UpdateProductAsync(Products products)
            => await _con.ExecuteAsync(
                @"UPDATE Products
          SET ProductName = @ProductName,
              Description = @Description,
              Price = @Price,
              Stock = @Stock,
              ProductCategoryName = @ProductCategoryName,
              IDORBarcode = @IDORBarcode
          WHERE ProductId = @ProductId",
                products).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de Products por ID.
        /// </summary>
        /// <param name="products">El objeto Products con el ID especificado.</param>
        public async Task DeleteProductAsync(Products products)
            => await _con.ExecuteAsync(
                "DELETE FROM Products WHERE ProductId = @ProductId",
                new { products.ProductId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de Promotions.
        /// </summary>
        /// <returns>Una lista de Promotions.</returns>
        public async Task<IEnumerable<Promotions>> GetPromotionsAsync()
            => await _con.QueryAsync<Promotions>("SELECT * FROM Promotions").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de Promotions por ID.
        /// </summary>
        /// <param name="promotions">El objeto Promotions con el ID especificado.</param>
        /// <returns>El registro de Promotions encontrado.</returns>
        public async Task<Promotions> GetPromotionByIdAsync(Promotions promotions)
            => await _con.QuerySingleAsync<Promotions>(
                "SELECT * FROM Promotions WHERE PromotionId = @PromotionId",
                new { promotions.PromotionId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en Promotions.
        /// </summary>
        /// <param name="promotions">El objeto Promotions a insertar.</param>
        public async Task InsertPromotionAsync(Promotions promotions)
            => await _con.ExecuteAsync(
                @"INSERT INTO Promotions (PromotionName, Description, StartDate, EndDate, PromotionType, Value)
          VALUES (@PromotionName, @Description, @StartDate, @EndDate, @PromotionType, @Value)",
                promotions).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en Promotions.
        /// </summary>
        /// <param name="promotions">El objeto Promotions con los datos actualizados.</param>
        public async Task UpdatePromotionAsync(Promotions promotions)
            => await _con.ExecuteAsync(
                @"UPDATE Promotions
          SET PromotionName = @PromotionName,
              Description = @Description,
              StartDate = @StartDate,
              EndDate = @EndDate,
              PromotionType = @PromotionType,
              Value = @Value
          WHERE PromotionId = @PromotionId",
                promotions).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de Promotions por ID.
        /// </summary>
        /// <param name="promotions">El objeto Promotions con el ID especificado.</param>
        public async Task DeletePromotionAsync(Promotions promotions)
            => await _con.ExecuteAsync(
                "DELETE FROM Promotions WHERE PromotionId = @PromotionId",
                new { promotions.PromotionId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de ReturnDetails.
        /// </summary>
        /// <returns>Una lista de ReturnDetails.</returns>
        public async Task<IEnumerable<ReturnDetails>> GetReturnDetailsAsync()
            => await _con.QueryAsync<ReturnDetails>("SELECT * FROM ReturnDetails").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de ReturnDetails por ID.
        /// </summary>
        /// <param name="returnDetails">El objeto ReturnDetails con el ID especificado.</param>
        /// <returns>El registro de ReturnDetails encontrado.</returns>
        public async Task<ReturnDetails> GetReturnDetailByIdAsync(ReturnDetails returnDetails)
            => await _con.QuerySingleAsync<ReturnDetails>(
                "SELECT * FROM ReturnDetails WHERE ReturnDetailId = @ReturnDetailId",
                new { returnDetails.ReturnDetailId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en ReturnDetails.
        /// </summary>
        /// <param name="returnDetails">El objeto ReturnDetails a insertar.</param>
        public async Task InsertReturnDetailAsync(ReturnDetails returnDetails)
            => await _con.ExecuteAsync(
                @"INSERT INTO ReturnDetails (ReturnId, ProductId, Quantity, UnitPrice, Subtotal)
          VALUES (@ReturnId, @ProductId, @Quantity, @UnitPrice, @Subtotal)",
                returnDetails).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en ReturnDetails.
        /// </summary>
        /// <param name="returnDetails">El objeto ReturnDetails con los datos actualizados.</param>
        public async Task UpdateReturnDetailAsync(ReturnDetails returnDetails)
            => await _con.ExecuteAsync(
                @"UPDATE ReturnDetails
          SET ReturnId = @ReturnId,
              ProductId = @ProductId,
              Quantity = @Quantity,
              UnitPrice = @UnitPrice,
              Subtotal = @Subtotal
          WHERE ReturnDetailId = @ReturnDetailId",
                returnDetails).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de ReturnDetails por ID.
        /// </summary>
        /// <param name="returnDetails">El objeto ReturnDetails con el ID especificado.</param>
        public async Task DeleteReturnDetailAsync(ReturnDetails returnDetails)
            => await _con.ExecuteAsync(
                "DELETE FROM ReturnDetails WHERE ReturnDetailId = @ReturnDetailId",
                new { returnDetails.ReturnDetailId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de ReturnsProducts.
        /// </summary>
        /// <returns>Una lista de ReturnsProducts.</returns>
        public async Task<IEnumerable<ReturnsProducts>> GetReturnsProductsAsync()
            => await _con.QueryAsync<ReturnsProducts>("SELECT * FROM ReturnsProducts").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de ReturnsProducts por ID.
        /// </summary>
        /// <param name="returnsProducts">El objeto ReturnsProducts con el ID especificado.</param>
        /// <returns>El registro de ReturnsProducts encontrado.</returns>
        public async Task<ReturnsProducts> GetReturnProductByIdAsync(ReturnsProducts returnsProducts)
            => await _con.QuerySingleAsync<ReturnsProducts>(
                "SELECT * FROM ReturnsProducts WHERE ReturnId = @ReturnId",
                new { returnsProducts.ReturnId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en ReturnsProducts.
        /// </summary>
        /// <param name="returnsProducts">El objeto ReturnsProducts a insertar.</param>
        public async Task InsertReturnProductAsync(ReturnsProducts returnsProducts)
            => await _con.ExecuteAsync(
                @"INSERT INTO ReturnsProducts (SaleId, ReturnDate, RefundedAmount, ReturnStatusName)
          VALUES (@SaleId, @ReturnDate, @RefundedAmount, @ReturnStatusName)",
                returnsProducts).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en ReturnsProducts.
        /// </summary>
        /// <param name="returnsProducts">El objeto ReturnsProducts con los datos actualizados.</param>
        public async Task UpdateReturnProductAsync(ReturnsProducts returnsProducts)
            => await _con.ExecuteAsync(
                @"UPDATE ReturnsProducts
          SET SaleId = @SaleId,
              ReturnDate = @ReturnDate,
              RefundedAmount = @RefundedAmount,
              ReturnStatusName = @ReturnStatusName
          WHERE ReturnId = @ReturnId",
                returnsProducts).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de ReturnsProducts por ID.
        /// </summary>
        /// <param name="returnsProducts">El objeto ReturnsProducts con el ID especificado.</param>
        public async Task DeleteReturnProductAsync(ReturnsProducts returnsProducts)
            => await _con.ExecuteAsync(
                "DELETE FROM ReturnsProducts WHERE ReturnId = @ReturnId",
                new { returnsProducts.ReturnId }).ConfigureAwait(false);

        /// <summary>
        /// Obtiene todos los registros de ReturnStatuses.
        /// </summary>
        /// <returns>Una lista de ReturnStatuses.</returns>
        public async Task<IEnumerable<ReturnStatuses>> GetReturnStatusesAsync()
            => await _con.QueryAsync<ReturnStatuses>("SELECT * FROM ReturnStatuses").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de ReturnStatuses por ID.
        /// </summary>
        /// <param name="returnStatuses">El objeto ReturnStatuses con el ID especificado.</param>
        /// <returns>El registro de ReturnStatuses encontrado.</returns>
        public async Task<ReturnStatuses> GetReturnStatusByIdAsync(ReturnStatuses returnStatuses)
            => await _con.QuerySingleAsync<ReturnStatuses>(
                "SELECT * FROM ReturnStatuses WHERE ReturnStatusId = @ReturnStatusId",
                new { returnStatuses.ReturnStatusId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en ReturnStatuses.
        /// </summary>
        /// <param name="returnStatuses">El objeto ReturnStatuses a insertar.</param>
        public async Task InsertReturnStatusAsync(ReturnStatuses returnStatuses)
            => await _con.ExecuteAsync(
                @"INSERT INTO ReturnStatuses (StatusName)
          VALUES (@StatusName)",
                returnStatuses).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en ReturnStatuses.
        /// </summary>
        /// <param name="returnStatuses">El objeto ReturnStatuses con los datos actualizados.</param>
        public async Task UpdateReturnStatusAsync(ReturnStatuses returnStatuses)
            => await _con.ExecuteAsync(
                @"UPDATE ReturnStatuses
          SET StatusName = @StatusName
          WHERE ReturnStatusId = @ReturnStatusId",
                returnStatuses).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de ReturnStatuses por ID.
        /// </summary>
        /// <param name="returnStatuses">El objeto ReturnStatuses con el ID especificado.</param>
        public async Task DeleteReturnStatusAsync(ReturnStatuses returnStatuses)
            => await _con.ExecuteAsync(
                "DELETE FROM ReturnStatuses WHERE ReturnStatusId = @ReturnStatusId",
                new { returnStatuses.ReturnStatusId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de SaleDetails.
        /// </summary>
        /// <returns>Una lista de SaleDetails.</returns>
        public async Task<IEnumerable<SaleDetails>> GetSaleDetailsAsync()
            => await _con.QueryAsync<SaleDetails>("SELECT * FROM SaleDetails").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de SaleDetails por ID.
        /// </summary>
        /// <param name="saleDetails">El objeto SaleDetails con el ID especificado.</param>
        /// <returns>El registro de SaleDetails encontrado.</returns>
        public async Task<SaleDetails> GetSaleDetailByIdAsync(SaleDetails saleDetails)
            => await _con.QuerySingleAsync<SaleDetails>(
                "SELECT * FROM SaleDetails WHERE SaleDetailId = @SaleDetailId",
                new { saleDetails.SaleDetailId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en SaleDetails.
        /// </summary>
        /// <param name="saleDetails">El objeto SaleDetails a insertar.</param>
        public async Task InsertSaleDetailAsync(SaleDetails saleDetails)
            => await _con.ExecuteAsync(
                @"INSERT INTO SaleDetails (SaleId, ProductId, Quantity, UnitPrice, Subtotal)
          VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice, @Subtotal)",
                saleDetails).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en SaleDetails.
        /// </summary>
        /// <param name="saleDetails">El objeto SaleDetails con los datos actualizados.</param>
        public async Task UpdateSaleDetailAsync(SaleDetails saleDetails)
            => await _con.ExecuteAsync(
                @"UPDATE SaleDetails
          SET SaleId = @SaleId,
              ProductId = @ProductId,
              Quantity = @Quantity,
              UnitPrice = @UnitPrice,
              Subtotal = @Subtotal
          WHERE SaleDetailId = @SaleDetailId",
                saleDetails).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de SaleDetails por ID.
        /// </summary>
        /// <param name="saleDetails">El objeto SaleDetails con el ID especificado.</param>
        public async Task DeleteSaleDetailAsync(SaleDetails saleDetails)
            => await _con.ExecuteAsync(
                "DELETE FROM SaleDetails WHERE SaleDetailId = @SaleDetailId",
                new { saleDetails.SaleDetailId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de Sales.
        /// </summary>
        /// <returns>Una lista de Sales.</returns>
        public async Task<IEnumerable<Sales>> GetSalesAsync()
            => await _con.QueryAsync<Sales>("SELECT * FROM Sales").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de Sales por ID.
        /// </summary>
        /// <param name="sales">El objeto Sales con el ID especificado.</param>
        /// <returns>El registro de Sales encontrado.</returns>
        public async Task<Sales> GetSaleByIdAsync(Sales sales)
            => await _con.QuerySingleAsync<Sales>(
                "SELECT * FROM Sales WHERE SaleId = @SaleId",
                new { sales.SaleId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en Sales.
        /// </summary>
        /// <param name="sales">El objeto Sales a insertar.</param>
        public async Task InsertSaleAsync(Sales sales)
            => await _con.ExecuteAsync(
                @"INSERT INTO Sales (IDPatient, SaleDate, TotalAmount, PaymentType, SaleStatus, UserId)
          VALUES (@IDPatient, @SaleDate, @TotalAmount, @PaymentType, @SaleStatus, @UserId)",
                sales).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en Sales.
        /// </summary>
        /// <param name="sales">El objeto Sales con los datos actualizados.</param>
        public async Task UpdateSaleAsync(Sales sales)
            => await _con.ExecuteAsync(
                @"UPDATE Sales
          SET IDPatient = @IDPatient,
              SaleDate = @SaleDate,
              TotalAmount = @TotalAmount,
              PaymentType = @PaymentType,
              SaleStatus = @SaleStatus,
              UserId = @UserId
          WHERE SaleId = @SaleId",
                sales).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de Sales por ID.
        /// </summary>
        /// <param name="sales">El objeto Sales con el ID especificado.</param>
        public async Task DeleteSaleAsync(Sales sales)
            => await _con.ExecuteAsync(
                "DELETE FROM Sales WHERE SaleId = @SaleId",
                new { sales.SaleId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de SalesPromotions.
        /// </summary>
        /// <returns>Una lista de SalesPromotions.</returns>
        public async Task<IEnumerable<SalesPromotions>> GetSalesPromotionsAsync()
            => await _con.QueryAsync<SalesPromotions>("SELECT * FROM SalesPromotions").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de SalesPromotions por ID.
        /// </summary>
        /// <param name="salesPromotions">El objeto SalesPromotions con el ID especificado.</param>
        /// <returns>El registro de SalesPromotions encontrado.</returns>
        public async Task<SalesPromotions> GetSalesPromotionByIdAsync(SalesPromotions salesPromotions)
            => await _con.QuerySingleAsync<SalesPromotions>(
                "SELECT * FROM SalesPromotions WHERE SalePromotionId = @SalePromotionId",
                new { salesPromotions.SalePromotionId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en SalesPromotions.
        /// </summary>
        /// <param name="salesPromotions">El objeto SalesPromotions a insertar.</param>
        public async Task InsertSalesPromotionAsync(SalesPromotions salesPromotions)
            => await _con.ExecuteAsync(
                @"INSERT INTO SalesPromotions (SaleId, PromotionId, DiscountApplied)
          VALUES (@SaleId, @PromotionId, @DiscountApplied)",
                salesPromotions).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en SalesPromotions.
        /// </summary>
        /// <param name="salesPromotions">El objeto SalesPromotions con los datos actualizados.</param>
        public async Task UpdateSalesPromotionAsync(SalesPromotions salesPromotions)
            => await _con.ExecuteAsync(
                @"UPDATE SalesPromotions
          SET SaleId = @SaleId,
              PromotionId = @PromotionId,
              DiscountApplied = @DiscountApplied
          WHERE SalePromotionId = @SalePromotionId",
                salesPromotions).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de SalesPromotions por ID.
        /// </summary>
        /// <param name="salesPromotions">El objeto SalesPromotions con el ID especificado.</param>
        public async Task DeleteSalesPromotionAsync(SalesPromotions salesPromotions)
            => await _con.ExecuteAsync(
                "DELETE FROM SalesPromotions WHERE SalePromotionId = @SalePromotionId",
                new { salesPromotions.SalePromotionId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de SaleStatuses.
        /// </summary>
        /// <returns>Una lista de SaleStatuses.</returns>
        public async Task<IEnumerable<SaleStatuses>> GetSaleStatusesAsync()
            => await _con.QueryAsync<SaleStatuses>("SELECT * FROM SaleStatuses").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de SaleStatuses por ID.
        /// </summary>
        /// <param name="saleStatuses">El objeto SaleStatuses con el ID especificado.</param>
        /// <returns>El registro de SaleStatuses encontrado.</returns>
        public async Task<SaleStatuses> GetSaleStatusByIdAsync(SaleStatuses saleStatuses)
            => await _con.QuerySingleAsync<SaleStatuses>(
                "SELECT * FROM SaleStatuses WHERE SaleStatusId = @SaleStatusId",
                new { saleStatuses.SaleStatusId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en SaleStatuses.
        /// </summary>
        /// <param name="saleStatuses">El objeto SaleStatuses a insertar.</param>
        public async Task InsertSaleStatusAsync(SaleStatuses saleStatuses)
            => await _con.ExecuteAsync(
                @"INSERT INTO SaleStatuses (StatusName)
          VALUES (@StatusName)",
                saleStatuses).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en SaleStatuses.
        /// </summary>
        /// <param name="saleStatuses">El objeto SaleStatuses con los datos actualizados.</param>
        public async Task UpdateSaleStatusAsync(SaleStatuses saleStatuses)
            => await _con.ExecuteAsync(
                @"UPDATE SaleStatuses
          SET StatusName = @StatusName
          WHERE SaleStatusId = @SaleStatusId",
                saleStatuses).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de SaleStatuses por ID.
        /// </summary>
        /// <param name="saleStatuses">El objeto SaleStatuses con el ID especificado.</param>
        public async Task DeleteSaleStatusAsync(SaleStatuses saleStatuses)
            => await _con.ExecuteAsync(
                "DELETE FROM SaleStatuses WHERE SaleStatusId = @SaleStatusId",
                new { saleStatuses.SaleStatusId }).ConfigureAwait(false);

        #endregion

     #region ExpressPoss

/// <summary>
/// Implementación de operaciones relacionadas con los productos.
/// </summary>
public async Task AgregarProducto(Productos producto)
{
    await _con.ExecuteAsync(
        "INSERT INTO Productos (Nombre, Precio, Stock) VALUES (@Nombre, @Precio, @Stock)",
        new { producto.Nombre, producto.Precio, producto.Stock }).ConfigureAwait(false);
}

public async Task ActualizarProducto(Productos producto)
{
    await _con.ExecuteAsync(
        "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Stock = @Stock WHERE ProductoID = @ProductoID",
        new { producto.ProductoID, producto.Nombre, producto.Precio, producto.Stock }).ConfigureAwait(false);
}

public async Task EliminarProducto(Productos producto)
{
    await _con.ExecuteAsync(
        "DELETE FROM Productos WHERE ProductoID = @ProductoID",
        new { producto.ProductoID }).ConfigureAwait(false);
}

public async Task<Productos> ObtenerProductoPorId(int productoId)
{
    return await _con.QuerySingleAsync<Productos>(
        "SELECT * FROM Productos WHERE ProductoID = @ProductoID",
        new { ProductoID = productoId }).ConfigureAwait(false);
}

public async Task<IEnumerable<Productos>> ObtenerTodosLosProductos()
{
    return await _con.QueryAsync<Productos>("SELECT * FROM Productos").ConfigureAwait(false);
}

public async Task ActualizarStock(Productos producto)
{
    await _con.ExecuteAsync(
        "UPDATE Productos SET Stock = @Stock WHERE ProductoID = @ProductoID",
        new { producto.ProductoID, producto.Stock }).ConfigureAwait(false);
}

public async Task<IEnumerable<Productos>> ObtenerProductosConBajoStock(int limiteStock)
{
    return await _con.QueryAsync<Productos>(
        "SELECT * FROM Productos WHERE Stock < @LimiteStock",
        new { LimiteStock = limiteStock }).ConfigureAwait(false);
}

public async Task<IEnumerable<Productos>> ObtenerProductosPorIdsAsync(IEnumerable<int> productoIds)
{
    var productos = await _con.QueryAsync<Productos>(
        "SELECT * FROM Productos WHERE ProductoID IN @ProductoIDs",
        new { ProductoIDs = productoIds }).ConfigureAwait(false);

    return productos;
}




/// <summary>
/// Implementación de operaciones relacionadas con las ventas.
/// </summary>
public async Task<int> RegistrarVenta(Ventas venta, IEnumerable<DetalleVentas> detalles)
{
    var ventaId = await _con.QuerySingleAsync<int>(
        "INSERT INTO Ventas (FechaHora, Total) OUTPUT INSERTED.VentaID VALUES (GETDATE(), @Total)",
        new { venta.FechaHora, venta.Total }).ConfigureAwait(false);

    foreach (var detalle in detalles)
    {
        await _con.ExecuteAsync(
            "INSERT INTO DetalleVentas (VentaID, ProductoID, Cantidad, Subtotal) VALUES (@VentaID, @ProductoID, @Cantidad, @Subtotal)",
            new { VentaID = ventaId, detalle.ProductoID, detalle.Cantidad, detalle.Subtotal }).ConfigureAwait(false);
    }

    return ventaId;
}

public async Task EliminarVenta(Ventas venta)
{
    await _con.ExecuteAsync(
        "DELETE FROM DetalleVentas WHERE VentaID = @VentaID",
        new { VentaID = venta.VentaID }).ConfigureAwait(false);
    await _con.ExecuteAsync(
        "DELETE FROM Ventas WHERE VentaID = @VentaID",
        new { VentaID = venta.VentaID }).ConfigureAwait(false);
}

public async Task<Ventas> ObtenerVentaPorId(int ventaId)
{
    return await _con.QuerySingleAsync<Ventas>(
        @"SELECT [VentaID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[Total]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Ventas] WHERE VentaID = @VentaID",
        new { VentaID = ventaId }).ConfigureAwait(false);
}

public async Task<IEnumerable<Ventas>> ObtenerVentas()
{
    return await _con.QueryAsync<Ventas>(@"SELECT [VentaID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[Total]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Ventas]").ConfigureAwait(false);
}

public async Task<IEnumerable<Ventas>> ObtenerVentasPorRango(DateTime fechaInicio, DateTime fechaFin)
{
    _logger.LogDebug($"Fecha Inicio: {fechaInicio}, Fecha Fin: {fechaFin}"); // Para depuración

    return await _con.QueryAsync<Ventas>(
        @"SELECT [VentaID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[Total]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Ventas] WHERE FechaHora BETWEEN CONVERT(datetime, @FechaInicio, 120) AND CONVERT(datetime, @FechaFin, 120)",
        new { FechaInicio = fechaInicio, FechaFin = fechaFin }
    ).ConfigureAwait(false);
}


public async Task<IEnumerable<DetalleVentas>> ObtenerDetalleDeVenta(int ventaId)
{
    return await _con.QueryAsync<DetalleVentas>(
        @"SELECT [VentaID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[Producto]
      ,[Cantidad]
      ,[Subtotal]
  FROM [Medical.Office.SqlLocalDB].[dbo].[DetalleDeVentas] WHERE VentaID = @VentaID",
        new { VentaID = ventaId }).ConfigureAwait(false);
}

/// <summary>
/// Implementación de operaciones relacionadas con los cortes de caja.
/// </summary>
public async Task RegistrarCorte(Cortes corte)
{
    await _con.ExecuteAsync(
        "INSERT INTO Cortes (FechaHora, TotalVendido, TotalVentas) VALUES (@FechaHora, @TotalVendido, @TotalVentas)",
        new { corte.FechaHora, corte.TotalVendido, corte.TotalVentas }).ConfigureAwait(false);
}

public async Task EliminarCorte(Cortes corte)
{
    await _con.ExecuteAsync(
        "DELETE FROM Cortes WHERE CorteID = @CorteID",
        new { corte.CorteID }).ConfigureAwait(false);
}

public async Task<Cortes> ObtenerCortePorId(int corteId)
{
    return await _con.QuerySingleAsync<Cortes>(
        @"SELECT [CorteID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora] AS [FechaHora]
      ,[TotalVendido]
      ,[TotalVentas]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Cortes] WHERE CorteID = @CorteID",
        new { CorteID = corteId }).ConfigureAwait(false);
}

public async Task<IEnumerable<Cortes>> ObtenerCortes()
{
    return await _con.QueryAsync<Cortes>(@"SELECT [CorteID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[TotalVendido]
      ,[TotalVentas]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Cortes]").ConfigureAwait(false);
}

public async Task<IEnumerable<Cortes>> ObtenerCortesPorRango(DateTime fechaInicio, DateTime fechaFin)
{
    return await _con.QueryAsync<Cortes>(
        @"SELECT [CorteID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[TotalVendido]
      ,[TotalVentas]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Cortes] WHERE FechaHora BETWEEN @FechaInicio AND @FechaFin",
        new { FechaInicio = fechaInicio, FechaFin = fechaFin }).ConfigureAwait(false);
}

/// <summary>
/// Implementación de reportes y vistas.
/// </summary>
public async Task<IEnumerable<VentasPorDia>> ObtenerVentasPorDia(DateTime fechaInicio, DateTime fechaFin)
{
    return await _con.QueryAsync<VentasPorDia>(
        "SELECT CONVERT(DATE, FechaHora) AS Fecha, COUNT(*) AS TotalVentas, SUM(Total) AS TotalVendido " +
        "FROM Ventas WHERE FechaHora BETWEEN @FechaInicio AND @FechaFin GROUP BY CONVERT(DATE, FechaHora)",
        new { FechaInicio = fechaInicio, FechaFin = fechaFin }).ConfigureAwait(false);
}

public async Task<IEnumerable<DetalleDeVentas>> ObtenerDetalleDeVentas(int ventaId)
{
    return await _con.QueryAsync<DetalleDeVentas>(
        @"SELECT dv.VentaID, dbo.ufntolocaltime(v.FechaHora) AS [FechaHora], p.Nombre AS Producto, dv.Cantidad, dv.Subtotal 
        FROM DetalleVentas dv JOIN Ventas v ON dv.VentaID = v.VentaID JOIN Productos p ON dv.ProductoID = p.ProductoID  
        WHERE dv.VentaID = @VentaID",
        new { VentaID = ventaId }).ConfigureAwait(false);
}

public async Task<IEnumerable<Cortes>> ObtenerResumenDeCortesPorDia(DateTime fechaInicio, DateTime fechaFin)
{
    return await _con.QueryAsync<Cortes>(
        @"SELECT [CorteID]
      ,dbo.ufntolocaltime([FechaHora]) AS [FechaHora]
      ,[TotalVendido]
      ,[TotalVentas]
  FROM [Medical.Office.SqlLocalDB].[dbo].[Cortes] WHERE FechaHora BETWEEN @FechaInicio AND @FechaFin",
        new { FechaInicio = fechaInicio, FechaFin = fechaFin }).ConfigureAwait(false);
}

#endregion

    }
}
