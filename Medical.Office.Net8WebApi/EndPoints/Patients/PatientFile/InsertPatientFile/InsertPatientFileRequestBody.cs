namespace Medical.Office.Net8WebApi.EndPoints.Patients.PatientFile.InsertPatientFile
{
    public class InsertPatientFileRequestBody
    {
        public long IDPatient { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileExtension { get; set; }
        public string Description { get; set; }
        public string FileData { get; set; } // Chunk en Base64
        public int ChunkIndex { get; set; } // Índice del chunk actual
        public int TotalChunks { get; set; } // Número total de chunks
    }

}
