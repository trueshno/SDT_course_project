using Domain.Entity;

namespace Service.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetAll();
        Task<Report?> GetById(int id);
        Task<bool> Create(Report entity, Dictionary<string, string> items, string mainDirectoryPath);
        Task<bool> Update(Report entity);
        Task<bool> Delete(int id);
    }
}
