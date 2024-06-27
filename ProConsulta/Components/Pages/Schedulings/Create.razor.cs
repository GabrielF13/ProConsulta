using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Doctors;
using ProConsulta.Repositories.Patients;
using ProConsulta.Repositories.Schedulings;

namespace ProConsulta.Components.Pages.Schedulings
{
    public class CreateSchedulingPage : ComponentBase
    {
        [Inject]
        private ISchedulingRepository SchedulingRepository { get; set; } = null!;

        [Inject]
        private IDoctorRepository DoctorRepository { get; set; } = null!;

        [Inject]
        private IPatientRepository PatientRepository { get; set; } = null!;

        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        public SchedulingViewModel InputModel { get; set; } = new();
        public List<Doctor> Doctors { get; set; } = new();
        public List<Patient> Patients { get; set; } = new();

        public TimeSpan? time = new TimeSpan(09, 00, 00);
        public DateTime? date { get; set; } = DateTime.Now.Date;
        public DateTime? MinDate { get; set; } = DateTime.Now.Date;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is SchedulingViewModel model)
                {
                    var agendamento = new Scheduling
                    {
                        Observation = model.Observation,
                        PatientId = model.PatientId,
                        DoctorId = model.DoctorId,
                        ConsultationTime = time!.Value,
                        ConsultationDate = date!.Value
                    };

                    await SchedulingRepository.AddAsync(agendamento);
                    Snackbar.Add("Scheduling completed successfully!", Severity.Success);
                    NavigationManager.NavigateTo("/scheduling");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Doctors = await DoctorRepository.GetAllAsync();
            Patients = await PatientRepository.GetAllAsync();
        }
    }
}
