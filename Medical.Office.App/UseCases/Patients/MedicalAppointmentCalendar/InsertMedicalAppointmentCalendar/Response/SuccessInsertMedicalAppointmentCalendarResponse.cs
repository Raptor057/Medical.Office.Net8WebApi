﻿using Common.Common;
using Medical.Office.App.Dtos.Patients;

namespace Medical.Office.App.UseCases.Patients.MedicalAppointmentCalendar.InsertMedicalAppointmentCalendar.Response
{
    public record SuccessInsertMedicalAppointmentCalendarResponse(MedicalAppointmentCalendarDto Calendar) : InsertMedicalAppointmentCalendarResponse, ISuccess;
}
