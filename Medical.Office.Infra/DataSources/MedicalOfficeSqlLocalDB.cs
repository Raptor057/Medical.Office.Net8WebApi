using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient;

namespace Medical.Office.Infra.DataSources
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicalOfficeSqlLocalDB
    {
        private readonly ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> _con;

        public MedicalOfficeSqlLocalDB(ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> con)
        {
            _con = con;
        }
        
        #region Configuracion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<OfficeSetup> GetOfficeSetup()
            => await _con.QueryFirstAsync<OfficeSetup>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[OfficeSetup]").ConfigureAwait(false);

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
                    #region Users
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="Id"></param>
                    /// <returns></returns>
                    public async Task<Users> GetDataUserById(long Id) =>
                        await _con.QuerySingleAsync<Users>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Id = @Id;", new { Id }).ConfigureAwait(false);

                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <returns></returns>
                    public async Task<Users> GetDataUserByUsr(string Usr) =>
                    await _con.QuerySingleAsync<Users>("SELECT top 1 * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr;", new { Usr }).ConfigureAwait(false);

                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <returns></returns>
                    public async Task<IEnumerable<Users>> GetDataUserByUsrList(string Usr) =>
                    await _con.QueryAsync<Users>("SELECT top 1 * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr Like @Usr;", new { Usr = $"%{Usr}%" }).ConfigureAwait(false);

                    /// <summary>
                    /// 
                    /// </summary>
                    /// <returns></returns>
                    public async Task<IEnumerable<Users>> GetUsers() =>
                                await _con.QueryAsync<Users>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Users];", new { }).ConfigureAwait(false);

                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="Usr"></param>
                    /// <param name="Psswd"></param>
                    /// <returns></returns>
                    public async Task<Users> LoginUser(string Usr, string Psswd) =>
                        await _con.QuerySingleAsync<Users>("SELECT TOP (1) * FROM [Medical.Office.SqlLocalDB].[dbo].[Users] WHERE Usr = @Usr AND Psswd = @Psswd;", new { Usr, Psswd }).ConfigureAwait(false);

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

                    /// <summary>
                    /// 
                    /// </summary>
                    /// <returns></returns>
                    public async Task<IEnumerable<LoginHistory>> GetLoginHistory()
                        => await _con.QueryAsync<LoginHistory>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] ORDER BY DateTimeSnap DESC;").ConfigureAwait(false);

                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="Param"></param>
                    /// <param name="StartDate"></param>
                    /// <param name="EndDate"></param>
                    /// <returns></returns>
                    public async Task<IEnumerable<LoginHistory>> GetLoginHistoryByParams(string Param, DateTime StartDate, DateTime EndDate)
                        => await _con.QueryAsync<LoginHistory>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] " +
                            "WHERE (Usr LIKE @Param OR UsrName LIKE @Param) " +
                            "AND (@StartDate IS NULL OR @EndDate IS NULL OR DateTimeSnap BETWEEN @StartDate AND @EndDate) " +
                            "ORDER BY DateTimeSnap ASC;", new { Param = $"%{Param}%", StartDate, EndDate }).ConfigureAwait(false);

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
                        => await _con.QueryAsync<UsersMovements>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[UsersMovements];").ConfigureAwait(false);

                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="Param"></param>
                    /// <param name="StartDate"></param>
                    /// <param name="EndDate"></param>
                    /// <returns></returns>
                    public async Task<IEnumerable<UsersMovements>> GetUsersMovementsByParams(string Param, DateTime StartDate, DateTime EndDate)
                        => await _con.QueryAsync<UsersMovements>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[LoginHistory] " +
                            "WHERE (Usr LIKE @Param OR UsrName LIKE @Param) " +
                            "AND (@StartDate IS NULL OR @EndDate IS NULL OR DateTimeSnap BETWEEN @StartDate AND @EndDate) " +
                            "ORDER BY DateTimeSnap ASC", new { Param = $"%{Param}%", StartDate, EndDate }).ConfigureAwait(false);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NameOfOffice"></param>
        /// <param name="Address"></param>
        /// <param name="OpeningTime"></param>
        /// <param name="ClosingTime"></param>
        /// <returns></returns>
        public async Task InsertOfficeSetup(string NameOfOffice, string Address, TimeSpan OpeningTime, TimeSpan ClosingTime)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[OfficeSetup]" +
                "([NameOfOffice],[Address],[OpeningTime],[ClosingTime])" +
                "VALUES(@NameOfOffice, @Address, @OpeningTime, @ClosingTime )", 
                new { NameOfOffice, Address, OpeningTime, ClosingTime }).ConfigureAwait(false);

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Doctors>> GetDoctors()
            => await _con.QueryAsync<Doctors>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[Doctors]").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="IDDoctor"></param>
        /// <param name="AppointmentDateTime"></param>
        /// <param name="ReasonForVisit"></param>
        /// <param name="AppointmentStatus"></param>
        /// <param name="Notes"></param>
        /// <param name="TypeOfAppointment"></param>
        /// <returns></returns>
        public async Task InsertMedicalAppointmentCalendar(long IDPatient, long IDDoctor, DateTime AppointmentDateTime, string ReasonForVisit, string AppointmentStatus, string Notes, string TypeOfAppointment)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[MedicalAppointmentCalendar]" +
                "([IDPatient],[IDDoctor],[AppointmentDateTime],[ReasonForVisit],[AppointmentStatus],[Notes],[TypeOfAppointment])" +
                "VALUES(@IDPatient, @IDDoctor, @AppointmentDateTime, @ReasonForVisit, @AppointmentStatus, @Notes, @TypeOfAppointment)", 
                new { IDPatient, IDDoctor, AppointmentDateTime, ReasonForVisit, AppointmentStatus, Notes, TypeOfAppointment }).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendar()
            => await _con.QueryAsync<MedicalAppointmentCalendar>("SELECT * FROM MedicalAppointmentCalendar ").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MedicalAppointmentCalendar>> GetMedicalAppointmentCalendarByIDPatient(long IDPatient)
            => await _con.QueryAsync<MedicalAppointmentCalendar>("SELECT * FROM MedicalAppointmentCalendar WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

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
             => await _con.QuerySingleAsync<PatientData>("SELECT TOP 1 * FROM [Medical.Office.SqlLocalDB].[dbo].[PatientData] ORDER BY ID DESC").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PatientData>> GetPatientsDataList()
            => await _con.QueryAsync<PatientData>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[PatientData]").ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<PatientData> GetPatientDataByIDPatient(long ID)
            => await _con.QuerySingleAsync<PatientData>("SELECT * FROM [Medical.Office.SqlLocalDB].[dbo].[PatientData] WHERE ID = @ID", new {ID}).ConfigureAwait(false);

        #endregion

        #region AntecedentPatient

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="AactiveMedicationsData"></param>
        /// <returns></returns>
        public async Task InsertActiveMedications(long IDPatient, string AactiveMedicationsData)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[ActiveMedications] " +
                "([IDPatient],[AactiveMedicationsData]) " +
                "VALUES (@IDPatient,@AactiveMedicationsData)", 
                new {IDPatient, AactiveMedicationsData }).ConfigureAwait(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>
        public async Task<ActiveMedications> GetActiveMedicationsByIDPatient(long IDPatient)
            => await _con.QuerySingleAsync<ActiveMedications>("SELECT * FROM ActiveMedications WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

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
        public async Task InsertFamilyHistory(long IDPatient, int Diabetes, int Cardiopathies, int Hypertension, int ThyroidDiseases, int ChronicKidneyDisease, int Others, string OthersData)
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
            => await _con.QuerySingleAsync<FamilyHistory>("SELECT * FROM FamilyHistory WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

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
            => await _con.QuerySingleAsync<MedicalHistoryNotes>("SELECT * FROM MedicalHistoryNotes WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

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
        public async Task InsertNonPathologicalHistory(long IDPatient, int PhysicalActivity, int Smoking, int Alcoholism, int SubstanceAbuse, string SubstanceAbuseData, int RecentVaccination, string RecentVaccinationData, int Others, string OthersData)
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
            => await _con.QuerySingleAsync<NonPathologicalHistory>("SELECT * FROM NonPathologicalHistory WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

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
        public async Task InsertPathologicalBackground(long IDPatient, int PreviousHospitalization, int PreviousSurgeries, int Diabetes, int ThyroidDiseases, int Hypertension, int Cardiopathies, int Trauma, int Cancer, int Tuberculosis, int Transfusions, int RespiratoryDiseases, int GastrointestinalDiseases, int STDs, string STDsData, int ChronicKidneyDisease, string Others)
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
            => await _con.QuerySingleAsync<PathologicalBackground>("SELECT * FROM PathologicalBackground WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

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
            => await _con.QuerySingleAsync<PatientAllergies>("SELECT * FROM PatientAllergies WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

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
        public async Task InsertPsychiatricHistory(long IDPatient, int FamilyHistory, string FamilyHistoryData, string AffectedAreas, string PastAndCurrentTreatments, int FamilySocialSupport, string FamilySocialSupportData, string WorkLifeAspects, string SocialLifeAspects, string AuthorityRelationship, string ImpulseControl, string FrustrationManagement)
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
            => await _con.QuerySingleAsync<PsychiatricHistory>("SELECT * FROM PsychiatricHistory WHERE IDPatient = @IDPatient", new { IDPatient }).ConfigureAwait(false);

        #region Update Methods

        /// <summary>
        /// Actualiza la información de los medicamentos activos de un paciente.
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <param name="AactiveMedicationsData"></param>
        /// <param name="DateTimeSnap"></param>
        /// <returns></returns>
        public async Task UpdateActiveMedications(long IDPatient, string AactiveMedicationsData, DateTime? DateTimeSnap)
        {
            await _con.ExecuteAsync(@"UPDATE [dbo].[ActiveMedications]
                              SET AactiveMedicationsData = @AactiveMedicationsData,
                                  DateTimeSnap = @DateTimeSnap
                              WHERE IDPatient = @IDPatient;",
                                      new { IDPatient, AactiveMedicationsData, DateTimeSnap }).ConfigureAwait(false);
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
        public async Task UpdateFamilyHistory(long IDPatient, int Diabetes, int Cardiopathies, int Hypertension,
            int ThyroidDiseases, int ChronicKidneyDisease, int Others, string OthersData, DateTime? DateTimeSnap)
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
    }
}
