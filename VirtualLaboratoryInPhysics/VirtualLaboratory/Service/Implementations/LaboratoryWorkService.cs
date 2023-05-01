using DAL.Interfaces;
using Domain.Entity;
using Domain.Helpers.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class LaboratoryWorkService : ILaboratoryWorkService
    {
        private readonly ILaboratoryWorkRepository _repository;
        private readonly IParseHelper _parseHelper;

        public LaboratoryWorkService(ILaboratoryWorkRepository repository, IParseHelper parseHelper)
        {
            _repository = repository;
            _parseHelper = parseHelper;
        }

        public async Task<bool> Create(LaboratoryWork entity)
        {
            return await _repository.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _repository.GetById(id);

            if (_parseHelper.IsNull(entity))
            {
                return false;
            }

            return await _repository.Delete(entity);
        }

        public async Task<IEnumerable<LaboratoryWork>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<LaboratoryWork?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> Update(LaboratoryWork entity)
        {
            return await _repository.Update(entity);
        }
    }
}
