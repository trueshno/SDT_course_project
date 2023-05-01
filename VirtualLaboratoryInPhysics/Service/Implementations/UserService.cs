using DAL.Interfaces;
using Domain.Entity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILaboratoryWorkRepository _laboratoryWorkRepository;

        public UserService(IUserRepository userRepository, ILaboratoryWorkRepository laboratoryWorkRepository)
        {
            _userRepository = userRepository;
            _laboratoryWorkRepository = laboratoryWorkRepository;
        }

        public Task<bool> Authorization(string login, string password)
        {
            if(login == null || password == null)
            {
                return Task.FromResult(false);
            }

            var user = _userRepository.GetByLogin(login);

            if(user == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(user.Result.Password == password);
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if(user == null)
            {
                return false;
            }

            return await _userRepository.Delete(user);
        }

        public async Task<List<LaboratoryWork>> GetLaboratoryWorks(Guid userId)
        {
            var user = await _userRepository.GetById(userId);

            if(user == null)
            {
                return null;
            }

            return await _laboratoryWorkRepository.GetRange(user.GroupNavigation.GroupLaboratoryWorks.Where(x => x.GroupId == user.GroupId).Select(x => x.LaboratoryWorkId).ToList());
        }

        public async Task<List<Report>> GetReports(Guid userId)
        {
            var user = await _userRepository.GetById(userId);

            if( user == null )
            {
                return null;
            }

            return user.Reports.ToList();
        }

        public Task<bool> Registration(User user)
        {
            if(user == null)
            {
                return Task.FromResult(false);
            }

            return _userRepository.Create(user);
        }

        public Task<bool> UpdateInfo(User user)
        {
            if (user == null)
            {
                return Task.FromResult(false);
            }

            return _userRepository.Update(user);
        }
    }
}
