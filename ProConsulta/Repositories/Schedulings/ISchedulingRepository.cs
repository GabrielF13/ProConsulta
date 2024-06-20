using ProConsulta.Models;

namespace ProConsulta.Repositories.Schedulings
{
    public interface ISchedulingRepository
    {
        Task<List<Scheduling>> GetAllAsync();

        Task AddAsync(Scheduling scheduling);

        Task DeleteAsync(int id);

        Task<Scheduling?> GetByIdAsync(int id);
    }
}