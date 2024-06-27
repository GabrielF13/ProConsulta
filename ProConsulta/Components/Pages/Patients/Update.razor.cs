using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Patients;

namespace ProConsulta.Components.Pages.Patients
{
    public class UpdatePatientPage : ComponentBase
    {
        [Parameter]
        public int PatientId { get; set; }

        [Inject]
        public IPatientRepository repository { get; set; } = null;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null;

        public PatientInputModel InputModel { get; set; } = new PatientInputModel();
        private Patient? CurrentPatient { get; set; }
        public DateTime? Birthday { get; set; } = DateTime.Today;
        public DateTime? MaxDate { get; set; } = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            CurrentPatient = await repository.GetByIdAsync(PatientId);

            if (CurrentPatient == null)
                return;

            InputModel = new PatientInputModel
            {
                Id = CurrentPatient.Id,
                Name = CurrentPatient.Name,
                Cellphone = CurrentPatient.Cellphone,
                Birthday = CurrentPatient.Birthday,
                Email = CurrentPatient.Email,
                Document = CurrentPatient.Document,
            };

            Birthday = CurrentPatient?.Birthday;
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PatientInputModel model)
                {
                    CurrentPatient.Name = model.Name;
                    CurrentPatient.Cellphone = model.Cellphone.CharactersOnly();
                    CurrentPatient.Birthday = Birthday.Value;
                    CurrentPatient.Email = model.Email;
                    CurrentPatient.Document = model.Document.CharactersOnly();
                }

                await repository.UpdateAsync(CurrentPatient);

                Snackbar.Add($"Patient {CurrentPatient} update successfully.", Severity.Success);
                NavigationManager.NavigateTo("/patients");
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}