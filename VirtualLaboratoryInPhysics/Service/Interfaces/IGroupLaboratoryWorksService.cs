using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IGroupLaboratoryWorksService
    {
        Task<bool> Create(GroupLaboratoryWorks groupLaboratoryWorks);
        Task<bool> Update(GroupLaboratoryWorks groupLaboratoryWorks);
        Task<bool> Delete(Guid id);
    }
}
