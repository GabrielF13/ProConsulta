using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Schedulings
{
    public class SchedulingRepository : ISchedulingRepository
    {
        private readonly ApplicationDbContext _context;

        public SchedulingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Scheduling scheduling)
        {
            _context.Schedulings.Add(scheduling);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var scheduling = await GetByIdAsync(id);
            _context.Schedulings.Remove(scheduling);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Scheduling>> GetAllAsync()
        {
            return await _context.Schedulings
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Scheduling?> GetByIdAsync(int id)
        {
            return await _context.Schedulings
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AnnualSchedules>?> GetReportAsync()
        {
            var result = _context.Database.SqlQuery<AnnualSchedules>
                ($"SELECT MONTH(ConsultationDate) AS Month, COUNT(*) AS NumberAppointments FROM Schedulings WHERE YEAR(ConsultationDate) = {DateTime.Today.Year} GROUP BY MONTH(ConsultationDate) ORDER BY Month;");

            return await Task.FromResult(result.ToList());
        }
    }
}