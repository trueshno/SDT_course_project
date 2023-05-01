using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IGroupService
    {
        Task<List<User>> GetUsers(Guid id);
        Task<bool> Create(Group group);
        Task<bool> Delete(Guid id);
    }
}
