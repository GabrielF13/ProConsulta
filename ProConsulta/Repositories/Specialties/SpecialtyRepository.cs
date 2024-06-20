using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Specialties
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialtyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Specialty>> GetAllAsync()
        {
            return await _context
                .Specialties
                .AsNoTracking()
                .ToListAsync();
        }
    }
}