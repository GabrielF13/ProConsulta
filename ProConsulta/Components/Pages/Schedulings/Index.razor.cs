using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Schedulings;

namespace ProConsulta.Components.Pages.Schedulings
{
    public class IndexSchedulingPage : ComponentBase
    {
        [Inject]
        private ISchedulingRepository SchedulingRepository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public List<Scheduling> Schedulings { get; set; } = new();

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public bool HideButtons { get; set; }

        public async Task DeleteAgendamento(Scheduling scheduling)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                    "Attention",
                    "Do you want to delete this schedule?",
                    yesText: "YES",
                    cancelText: "NO"
                );

                if (result is true)
                {
                    await SchedulingRepository.DeleteAsync(scheduling.Id);
                    Snackbar.Add("schedule deleted successfully!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;
            HideButtons = !auth.User.IsInRole("Atendente");

            Schedulings = await SchedulingRepository.GetAllAsync();
        }
    }
}
