using Domain.Entity;

namespace Service.Interfaces
{
    public interface ILaboratoryWorkService
    {
        Task<IEnumerable<LaboratoryWork>> GetAll();
        Task<LaboratoryWork?> GetById(int id);
        Task<bool> Create(LaboratoryWork entity);
        Task<bool> Update(LaboratoryWork entity);
        Task<bool> Delete(int id);
    }
}
