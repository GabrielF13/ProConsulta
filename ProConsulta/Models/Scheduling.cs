namespace ProConsulta.Models
{
    public class Scheduling
    {
        public int Id { get; set; }
        public string? Observation { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public TimeSpan ConsultationTime { get; set; }
        public DateTime ConsultationDate { get; set; }

        public Patient Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
    }
}
