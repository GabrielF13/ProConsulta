using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var doctor = await GetByIdAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors
                .Include(x => x.Specialty)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _context.Doctors.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            try
            {
                _context.Update(doctor);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.ChangeTracker.Clear();
                throw;
            }
        }
    }
}