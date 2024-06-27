using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Schedulings
{
    public class SchedulingViewModel
    {
        [MaxLength(250, ErrorMessage = "Field {0} must contain a maximum of {1} characters")]
        public string? Observation { get; set; }

        [Required(ErrorMessage = "{0} must be provided")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Selected value is invalid")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "{0} must be provided")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Selected value is invalid")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "{0} must be provided")]
        public TimeSpan ConsultationTime { get; set; }

        [Required(ErrorMessage = "{0} must be provided")]
        public DateTime ConsultationDate { get; set; }
    }
}
