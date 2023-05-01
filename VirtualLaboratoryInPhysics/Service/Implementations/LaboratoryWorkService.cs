using DAL.Interfaces;
using Domain.Entity;
using Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class LaboratoryWorkService : ILaboratoryWorkService
    {
        private readonly ILaboratoryWorkRepository _repository;

        public LaboratoryWorkService(ILaboratoryWorkRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Create(LaboratoryWork laboratoryWork)
        {
            if (laboratoryWork == null)
            {
                return Task.FromResult(false);
            }

            return _repository.Create(laboratoryWork);
        }

        public async Task<bool> Delete(Guid id)
        {
            var work = await _repository.GetById(id);

            if (work == null)
            {
                return false;
            }

            return await _repository.Delete(work);
        }

        public Task<LaboratoryWork> GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Task<bool> Update(LaboratoryWork laboratoryWork)
        {
            if (laboratoryWork == null)
            {
                return Task.FromResult(false);
            }

            return _repository.Update(laboratoryWork);
        }
    }
}
