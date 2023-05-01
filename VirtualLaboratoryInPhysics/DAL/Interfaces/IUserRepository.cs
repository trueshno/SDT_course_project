using Domain.Entity;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByLogin(string login);
    }
}
