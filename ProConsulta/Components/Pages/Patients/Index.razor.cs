using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Patients;

namespace ProConsulta.Components.Pages.Patients
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IPatientRepository repository { get; set; } = null;

        [Inject]
        public IDialogService Dialog { get; set; } = null;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null;

        public List<Patient> Patients { get; set; } = new List<Patient>();

        public async Task DeletePatient(Patient patient)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                    (
                        "Atenção",
                        $"Deseja excluir o paciente {patient.Name} ?",
                        yesText: "SIM",
                        cancelText: "NÃO"
                    );

                if (result is true)
                {
                    await repository.DeleteByIdAsync(patient.Id);
                    Snackbar.Add($"Paciente {patient.Name} Excluido com sucesso", Severity.Success);
                }
            }
            catch (Exception)
            {
                Snackbar.Add($"Paciente {patient.Name} Não foi Excluido", Severity.Error);
            }
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/patients/update/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            Patients = await repository.GetAllAsync();
        }
    }
}