using DAL.Interfaces;
using Domain;
using Domain.Entity;
using Domain.Helpers.Interfaces;
using Service.Interfaces;

namespace Service.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        private readonly IWordHelper _wordHelper;
        private readonly IParseHelper _parseHelper;

        public ReportService(IReportRepository repository, IWordHelper wordHelper, IParseHelper parseHelper)
        {
            _wordHelper = wordHelper;
            _repository = repository;
            _parseHelper = parseHelper;
        }

        public async Task<bool> Create(Report entity, Dictionary<string, string> items, string mainDirectoryPath)
        {
            var sampleReport = _wordHelper.OpenFile(entity.IdLaboratoryWorkNavigation.SampleReport);
            var reportName = "";
            var reportPath = string.Concat(mainDirectoryPath, Resources.ReportDirectory, reportName, Resources.ReportFileType);


            _wordHelper.FillFile(sampleReport, items);
            _wordHelper.SaveDocument(sampleReport.ActiveDocument, reportPath);
            _wordHelper.CloseDocument(sampleReport.ActiveDocument);
            _wordHelper.CloseApplication(sampleReport);

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

        public async Task<IEnumerable<Report>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Report?> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> Update(Report entity)
        {
            return await _repository.Update(entity);
        }
    }
}
