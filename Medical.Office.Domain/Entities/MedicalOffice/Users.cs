﻿namespace Medical.Office.Domain.Entities.MedicalOffice 
{ 
    public class Users
    {
        public long Id { get; set; }

        public string Usr { get; set; }

        public string Psswd { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Role { get; set; }

        public string Position { get; set; }

        public string Status { get; set; }

        public string Specialtie { get; set; }

        public DateTime TimeSnap { get; set; }

    }
}
