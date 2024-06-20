using ProConsulta.Models;

namespace ProConsulta.Repositories.Doctors
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor doctor);

        Task UpdateAsync(Doctor doctor);

        Task<List<Doctor>> GetAllAsync();

        Task<Doctor> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
    }
}
