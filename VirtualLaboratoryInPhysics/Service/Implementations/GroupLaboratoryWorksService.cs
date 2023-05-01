using DAL.Interfaces;
using Domain.Entity;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class GroupLaboratoryWorksService : IGroupLaboratoryWorksService
    {
        private readonly IGroupLaboratoryWorksRepository _repository;

        public GroupLaboratoryWorksService(IGroupLaboratoryWorksRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Create(GroupLaboratoryWorks groupLaboratoryWorks)
        {
            if (groupLaboratoryWorks == null)
            {
                return Task.FromResult(false);
            }

            return _repository.Create(groupLaboratoryWorks);
        }

        public async Task<bool> Delete(Guid id)
        {
            var groupLaboratoryWorks = await _repository.GetById(id);

            if (groupLaboratoryWorks == null)
            {
                return false;
            }

            return await _repository.Delete(groupLaboratoryWorks);
        }

        public Task<bool> Update(GroupLaboratoryWorks groupLaboratoryWorks)
        {
            if (groupLaboratoryWorks == null)
            {
                return Task.FromResult(false);
            }

            return _repository.Update(groupLaboratoryWorks);
        }
    }
}
