using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Patients
{
    public class PatientInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name must be provided")]
        [MaxLength(100, ErrorMessage = "{0} must have a maximum of {1} characters") ]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Document must be provided")]
        public string Document { get; set; } = null!;

        [Required(ErrorMessage = "Email must be provided")]
        [EmailAddress(ErrorMessage ="E-mail invalid")]
        [MaxLength(100, ErrorMessage = "{0} must have a maximum of {1} characters")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Cellphone must be provided")]
        public string Cellphone { get; set; } = null!;

        [Required(ErrorMessage = "Birtday must be provided")]
        public DateTime Birthday { get; set; }

    }
}
