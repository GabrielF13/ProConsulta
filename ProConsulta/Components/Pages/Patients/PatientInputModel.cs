using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Patients
{
    public class PatientInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome deve ser fornecido")]
        [MaxLength(100, ErrorMessage ="{0} deve ter no maximo {1} caracteres") ]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Documento deve ser fornecido")]
        public string Document { get; set; } = null!;

        [Required(ErrorMessage = "Email deve ser fornecido")]
        [EmailAddress(ErrorMessage ="E-mail invalido")]
        [MaxLength(100, ErrorMessage = "{0} deve ter no maximo {1} caracteres")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Celular deve ser fornecido")]
        public string Cellphone { get; set; } = null!;

        [Required(ErrorMessage = "Data de nascimento deve ser fornecido")]
        public DateTime Birthday { get; set; }

    }
}
