using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Doctors
{
    public class DoctorInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} must be provided")]
        [MaxLength(50, ErrorMessage = "{0} must contain a maximum of {1} characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "{0} must be provided")]
        public string Document { get; set; } = null!;
        public string Crm { get; set; } = null!;
        public DateTime DateRegister { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "{0} must be provided")]
        public string CellPhone { get; set; } = null!;

        [Required(ErrorMessage = "{0} must be provided")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Selected value is invalid")]
        public int SpecialtyId { get; set; }
    }
}
