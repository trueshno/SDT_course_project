using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IReportService
    {
        Task<bool> Create(Report report, Dictionary<string, string> fileItems);
        Task<Report> Get(Guid id);
        Task<bool> ChangeGrade(int grade, Guid reportId);
        Task<bool> Delete(Guid id);
    }
}
