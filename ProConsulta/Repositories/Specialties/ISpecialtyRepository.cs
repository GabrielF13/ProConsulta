using ProConsulta.Models;

namespace ProConsulta.Repositories.Specialties
{
    public interface ISpecialtyRepository
    {
        Task<List<Specialty>> GetAllAsync();
    }
}
