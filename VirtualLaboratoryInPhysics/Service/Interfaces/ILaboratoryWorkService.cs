using Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ILaboratoryWorkService
    {
        Task<bool> Create(LaboratoryWork laboratoryWork);
        Task<bool> Update(LaboratoryWork laboratoryWork);
        Task<bool> Delete(Guid id);
        Task<LaboratoryWork> GetById(Guid id);
    }
}
