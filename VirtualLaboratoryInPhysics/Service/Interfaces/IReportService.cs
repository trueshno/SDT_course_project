using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IReportService
    {
        Task<bool> Create(Report report);
        Task<Report> Get(Guid id);
        Task<bool> ChangeGrade(int grade, Guid reportId);
        Task<bool> Delete(Guid id);
    }
}
