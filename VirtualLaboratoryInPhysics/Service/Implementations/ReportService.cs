using DAL.Interfaces;
using Domain.Entity;
using Domain.Helper.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        private readonly IWordHelper _wordHelper;

        public ReportService(IReportRepository repository, IWordHelper wordHelper)
        {
            _repository = repository;
            _wordHelper = wordHelper;
        }

        public async Task<bool> ChangeGrade(int grade, Guid reportId)
        {
            var report = await _repository.GetById(reportId);

            if (report == null)
            {
                return false;
            }

            report.Grade = grade;

            return await _repository.Update(report);
        }

        public Task<bool> Create(Report report, Dictionary<string, string> fileItems) //TODO мб нужно переделать
        {
            if (report == null)
            {
                return Task.FromResult(false);
            }

            var application = _wordHelper.OpenFile(report.LaboratoryWorkNavigation.SampleReport);

            _wordHelper.FillFile(application, fileItems);
            _wordHelper.SaveDocument(application.ActiveDocument, report.Content);
            _wordHelper.CloseDocument(application.ActiveDocument);
            _wordHelper.CloseApplication(application);

            return _repository.Create(report);
        }

        public async Task<bool> Delete(Guid id)
        {
            var report = await _repository.GetById(id);

            if (report == null)
            {
                return false;
            }

            return await _repository.Delete(report);
        }

        public Task<Report> Get(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
