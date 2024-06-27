using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Doctors;
using ProConsulta.Repositories.Specialties;

namespace ProConsulta.Components.Pages.Doctors
{
    public class CreateDoctorPage : ComponentBase
    {
        [Inject]
        private ISpecialtyRepository SpecialtyRepository { get; set; } = null!;

        [Inject]
        public IDoctorRepository repository { get; set; } = default!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Specialty> Specialties { get; set; } = new();
        public DoctorInputModel InputModel { get; set; } = new();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is DoctorInputModel model)
                {
                    var medico = new Doctor
                    {
                        Name = model.Name,
                        Documentt = model.Document.CharactersOnly(),
                        CellPhone = model.CellPhone.CharactersOnly(),
                        Crm = model.Crm.CharactersOnly(),
                        SpecialtyId = model.SpecialtyId,
                        DateRegister = model.DateRegister
                    };

                    await repository.AddAsync(medico);
                    Snackbar.Add("Médico cadastrado com sucesso!", Severity.Success);
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
            Specialties = await SpecialtyRepository.GetAllAsync();
        }
    }
}