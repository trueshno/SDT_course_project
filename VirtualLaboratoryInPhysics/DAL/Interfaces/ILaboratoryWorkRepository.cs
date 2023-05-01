using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILaboratoryWorkRepository : IBaseRepository<LaboratoryWork>
    {
        Task<List<LaboratoryWork>> GetRange(List<Guid> workIds);
    }
}
