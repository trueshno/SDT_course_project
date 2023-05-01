using DAL.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class ReportRepository : IReportRepository
    {
        private readonly VirtualLaboratoryInPhysicsContext _context;

        public ReportRepository(VirtualLaboratoryInPhysicsContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Report entity)
        {
            await _context.Reports.AddAsync(entity);

            if (await _context.SaveChangesAsync() == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(Report entity)
        {
            _context.Reports.Remove(entity);

            if (await _context.SaveChangesAsync() == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Report>> GetAll()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<Report?> GetById(int id)
        {
            return await _context.Reports.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(Report entity)
        {
            _context.Reports.Update(entity);

            if (await _context.SaveChangesAsync() == 0)
            {
                return false;
            }

            return true;
        }
    }
}
