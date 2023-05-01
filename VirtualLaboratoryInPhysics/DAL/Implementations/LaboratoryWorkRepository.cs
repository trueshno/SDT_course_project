using DAL.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class LaboratoryWorkRepository : ILaboratoryWorkRepository
    {
        private readonly ApplicationDbContext _context;

        public LaboratoryWorkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(LaboratoryWork entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.LaboratoryWorks.Add(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> Delete(LaboratoryWork entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.LaboratoryWorks.Remove(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<List<LaboratoryWork>> GetAll()
        {
            return _context.LaboratoryWorks.ToListAsync();
        }

        public Task<LaboratoryWork> GetById(Guid id)
        {
            return _context.LaboratoryWorks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<LaboratoryWork>> GetRange(List<Guid> workIds)
        {
            if (workIds == null)
            {
                return null;
            }

            var works = new List<LaboratoryWork>();

            for (int i = 0; i < workIds.Count; i++)
            {
                if (_context.LaboratoryWorks.Any(x => x.Id == workIds[i]))
                {
                    works.Add(_context.LaboratoryWorks.FirstOrDefault(x => x.Id == workIds[i]));
                }
            }

            return Task.FromResult(works);
        }

        public Task<bool> Update(LaboratoryWork entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.LaboratoryWorks.Update(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
