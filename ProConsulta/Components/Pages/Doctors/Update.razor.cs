using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Doctors;
using ProConsulta.Repositories.Specialties;

namespace ProConsulta.Components.Pages.Doctors
{
    public class UpdateDoctorPage : ComponentBase
    {
        [Parameter]
        public int DoctorId { get; set; }

        [Inject]
        private ISpecialtyRepository SpecialtyRepository { get; set; } = null!;

        [Inject]
        public IDoctorRepository repository { get; set; } = default!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public Doctor? CurrentDoctor { get; set; }
        public DoctorInputModel InputModel { get; set; } = new();
        public List<Specialty> Specialties { get; set; } = new();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (CurrentDoctor is null) return;

                if (editContext.Model is DoctorInputModel model)
                {
                    CurrentDoctor.Id = DoctorId;
                    CurrentDoctor.Name = model.Name;
                    CurrentDoctor.Documentt = model.Document.CharactersOnly();
                    CurrentDoctor.Crm = model.Crm.CharactersOnly();
                    CurrentDoctor.CellPhone = model.CellPhone.CharactersOnly();
                    CurrentDoctor.SpecialtyId = model.SpecialtyId;

                    await repository.UpdateAsync(CurrentDoctor);
                    Snackbar.Add("Doctor successfully updated!", Severity.Success);
                    NavigationManager.NavigateTo("/doctors");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            CurrentDoctor = await repository.GetByIdAsync(DoctorId);
            Specialties = await SpecialtyRepository.GetAllAsync();

            if (CurrentDoctor is null) return;

            InputModel = new DoctorInputModel
            {
                Name = CurrentDoctor.Name,
                Document = CurrentDoctor.Documentt,
                Crm = CurrentDoctor.Crm,
                CellPhone = CurrentDoctor.CellPhone,
                SpecialtyId = CurrentDoctor.SpecialtyId
            };
        }
    }
}