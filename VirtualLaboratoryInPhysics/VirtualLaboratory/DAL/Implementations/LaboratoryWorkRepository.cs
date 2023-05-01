using DAL.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class LaboratoryWorkRepository : ILaboratoryWorkRepository
    {
        private readonly VirtualLaboratoryInPhysicsContext _context;

        public LaboratoryWorkRepository(VirtualLaboratoryInPhysicsContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(LaboratoryWork entity)
        {
            await _context.LaboratoryWorks.AddAsync(entity);

            if (await _context.SaveChangesAsync() == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(LaboratoryWork entity)
        {
            _context.LaboratoryWorks.Remove(entity);

            if (await _context.SaveChangesAsync() == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<LaboratoryWork>> GetAll()
        {
            return await _context.LaboratoryWorks.ToListAsync();
        }

        public async Task<LaboratoryWork?> GetById(int id)
        {
            return await _context.LaboratoryWorks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Update(LaboratoryWork entity)
        {
            _context.LaboratoryWorks.Update(entity);

            if (await _context.SaveChangesAsync() == 0)
            {
                return false;
            }

            return true;
        }
    }
}
