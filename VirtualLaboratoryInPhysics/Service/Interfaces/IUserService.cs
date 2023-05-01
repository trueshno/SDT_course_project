using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> Registration(User user);
        Task<bool> Authorization(string login, string password);
        Task<bool> UpdateInfo(User user);
        Task<List<Report>> GetReports(Guid userId);
        Task<bool> Delete(Guid id);
        Task<List<LaboratoryWork>> GetLaboratoryWorks(Guid userId);
    }
}
