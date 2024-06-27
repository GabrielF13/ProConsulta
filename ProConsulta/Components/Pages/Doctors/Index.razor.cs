using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Doctors;

namespace ProConsulta.Components.Pages.Doctors
{
    public class IndexDoctorPage : ComponentBase
    {
        [Inject]
        public IDoctorRepository Repository { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public List<Doctor> Doctors { get; set; } = new();

        public async Task DeleteMedicoAsync(Doctor doctor)
        {
            try
            {
                var result = await DialogService.ShowMessageBox
                (
                    "attention",
                    $"Do you want to delete the doctor {doctor.Name}?",
                    yesText: "YES",
                    cancelText: "NO"
                );

                if (result is true)
                {
                    await Repository.DeleteByIdAsync(doctor.Id);
                    Snackbar.Add("Doctor deleted successfully!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public bool HideButtons { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public void GoToUpdate(int id)
            => Navigation.NavigateTo($"/doctors/update/{id}");

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Atendente");

            Doctors = await Repository.GetAllAsync();
        }
    }
}