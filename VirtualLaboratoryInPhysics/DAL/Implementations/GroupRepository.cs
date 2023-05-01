using DAL.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(Group entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Groups.Add(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> Delete(Group entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Groups.Remove(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<List<Group>> GetAll()
        {
            return _context.Groups.ToListAsync();
        }

        public Task<Group> GetById(Guid id)
        {
            return _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(Group entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Groups.Update(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
