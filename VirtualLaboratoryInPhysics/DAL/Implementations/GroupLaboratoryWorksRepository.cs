using DAL.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class GroupLaboratoryWorksRepository : IGroupLaboratoryWorksRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupLaboratoryWorksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(GroupLaboratoryWorks entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.GroupLaboratoryWorks.Add(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> Delete(GroupLaboratoryWorks entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.GroupLaboratoryWorks.Remove(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<List<GroupLaboratoryWorks>> GetAll()
        {
            return _context.GroupLaboratoryWorks.ToListAsync();
        }

        public Task<GroupLaboratoryWorks> GetById(Guid id)
        {
            return _context.GroupLaboratoryWorks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(GroupLaboratoryWorks entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
