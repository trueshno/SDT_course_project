using DAL.Interfaces;
using Domain.Entity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;

        public GroupService(IGroupRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Create(Group group)
        {
            if (group == null)
            {
                return Task.FromResult(false);
            }

            return _repository.Create(group);
        }

        public async Task<bool> Delete(Guid id)
        {
            var group = await _repository.GetById(id);

            if (group == null)
            {
                return false;
            }

            return await _repository.Delete(group);
        }

        public async Task<List<User>> GetUsers(Guid id)
        {
            var group = await _repository.GetById(id);

            if (group == null)
            {
                return null;
            }

            return group.Users.ToList();
        }
    }
}
