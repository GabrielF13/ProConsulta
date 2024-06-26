using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Patients;

namespace ProConsulta.Components.Pages.Patients
{
    public class CreatePatientPage : ComponentBase
    {
        [Inject]
        public IPatientRepository repository { get; set; } = null;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null;

        public PatientInputModel InputModel { get; set; } = new PatientInputModel();

        public DateTime? Birthday { get; set; } = DateTime.Today;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PatientInputModel model)
                {
                    var paitent = new Patient()
                    {
                        Name = model.Name,
                        Document = model.Document.CharactersOnly(),
                        Cellphone = model.Cellphone.CharactersOnly(),
                        Email = model.Email,
                        Birthday = Birthday.Value
                    };

                    await repository.UpdateAsync(paitent);

                    Snackbar.Add("Paciente cadasttrado com sucesso", Severity.Success);
                    NavigationManager.NavigateTo("/patients");
                }
            }
            catch (Exception ex)
            {

                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
