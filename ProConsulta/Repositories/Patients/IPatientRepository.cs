using ProConsulta.Models;

namespace ProConsulta.Repositories.Patients
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);

        Task UpdateAsync(Patient patient);

        Task<List<Patient>> GetAllAsync();

        Task<Patient> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
    }
}