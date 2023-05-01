using DAL.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(Report entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Reports.Add(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> Delete(Report entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Reports.Remove(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<List<Report>> GetAll()
        {
            return _context.Reports.ToListAsync();
        }

        public Task<Report> GetById(Guid id)
        {
            return _context.Reports.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(Report entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Reports.Update(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
