using DAL.Interfaces;
using Domain.Entity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ChangeGrade(int grade, Guid reportId)
        {
            var report = await _repository.GetById(reportId);

            if(report == null)
            {
                return false;
            }

            report.Grade = grade;

            return await _repository.Update(report);
        }

        public Task<bool> Create(Report report)
        {
            return _repository.Create(report);
        }

        public async Task<bool> Delete(Guid id)
        {
            var report = await _repository.GetById(id);

            if(report == null)
            {
                return false;
            }

            return await _repository.Delete(report);
        }

        public Task<Report> Get(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
